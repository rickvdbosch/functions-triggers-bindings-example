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
    public static class HttpTriggerTableInputBinding1
    {
        [FunctionName(nameof(HttpTriggerTableInputBinding1))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Table(nameof(SomeEntity), Connection = "scs")] CloudTable table,
            ILogger log)
        {
            // The instance of CloudTable in this case has a reference to ALL entities in the table.
            // This is across partitions (if they're there).
            var result = await TableStorageHelper.GetEntitiesFromTable<SomeEntity>(table);

            return new OkObjectResult(result);
        }
    }
}