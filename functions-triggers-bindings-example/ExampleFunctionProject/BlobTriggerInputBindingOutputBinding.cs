using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ExampleFunctionProject
{
    public static class BlobTriggerInputBindingOutputBinding
    {
        [FunctionName("BlobTriggerInputBindingOutputBinding")]
        public static async Task Run(
            [BlobTrigger("upload/{name}", Connection = "scs")]Stream addedBlob,
            [Blob("copied/{name}", FileAccess.Write, Connection = "scs")]Stream stream,
            ILogger log)
        {
            // When using an Output binding, connecting to the storage account has been abstracted
            // away: you can simply use the Stream called 'stream' to write to.
            log.LogInformation("We're starting our simple copy action here!");
            await addedBlob.CopyToAsync(stream);
        }
    }
}