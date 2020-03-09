using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

using ExampleFunctionProject.Helpers;
using ExampleFunctionProject.Models;

namespace ExampleFunctionProject
{
    public static class HttpTriggerTableInputBinding3
    {
        [FunctionName(nameof(HttpTriggerTableInputBinding3))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Table(nameof(SomeEntity), SomeEntity.PARTITION_KEY, Connection = "scs")] CloudTable table,
            ILogger log)
        {
            var result = await TableStorageHelper.GetEntitiesFromTable<SomeEntity>(table);

            return new OkObjectResult(result);
        }
    }
}