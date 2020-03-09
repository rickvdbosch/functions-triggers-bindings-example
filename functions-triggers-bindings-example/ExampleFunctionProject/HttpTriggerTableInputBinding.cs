using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

namespace ExampleFunctionProject
{
    public static class HttpTriggerTableInputBinding
    {
        [FunctionName("HttpTriggerTableInputBinding")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Table("<TABLE-NAME>", Connection = "connstring")] CloudTable table,
            ILogger log)
        {
            var result = await GetEntitiesFromTable(table);

            return new OkObjectResult(result);
        }

        private static async Task<IEnumerable<T>> GetEntitiesFromTable<T>(CloudTable table) where T : ITableEntity, new()
        {
            TableQuerySegment<T> querySegment = null;
            var entities = new List<T>();
            var query = new TableQuery<T>();

            do
            {
                querySegment = await table.ExecuteQuerySegmentedAsync(query, querySegment?.ContinuationToken);
                entities.AddRange(querySegment.Results);
            } while (querySegment.ContinuationToken != null);

            return entities;
        }
    }
}