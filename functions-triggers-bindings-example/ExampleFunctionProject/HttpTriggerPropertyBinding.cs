using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using ExampleFunctionProject.Models;

namespace ExampleFunctionProject
{
    public static class HttpTriggerPropertyBinding
    {
        // The {Identifier} part in the BlobBinding below will automatically bind the Blob in the
        // OutputBinding to a Blob in the container 'properties' with the value if the Identifier
        // property as the name of the Blob. Binding on Property values...!
        [FunctionName(nameof(HttpTriggerPropertyBinding))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] RequestModel model,
            [Blob("properties/{Identifier}.txt", FileAccess.Write, Connection = "scs")] Stream stream,
            ILogger log)
        {
            using var writer = new StreamWriter(stream);
            await writer.WriteLineAsync($"Message:\t{model.Message}");

            return new OkResult();
        }
    }
}