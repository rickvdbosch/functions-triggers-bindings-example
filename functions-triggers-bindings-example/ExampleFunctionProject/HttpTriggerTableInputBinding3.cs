using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using ExampleFunctionProject.Models;

namespace ExampleFunctionProject
{
    public static class HttpTriggerTableInputBinding3
    {
        [FunctionName(nameof(HttpTriggerTableInputBinding3))]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "entities/{rowKey}")] HttpRequest req,
            [Table(nameof(SomeEntity), SomeEntity.PARTITION_KEY, "{rowKey}", Connection = "scs")] SomeEntity entity,
            ILogger log)
        {
            // The rowKey specified in the URL for the HttpTrigger is used as the value for the 
            // row key of the entity in the specified partition key we would like to retrieve.
            // 
            // The platform extracts away EVERYTHING about connecting to Table Storage and provides an 
            // instance of SomeEntity with the specified PartitionKey and RowKey.
            return new OkObjectResult(entity);
        }
    }
}