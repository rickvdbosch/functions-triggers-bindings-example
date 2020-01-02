using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ExampleFunctionProject
{
    public static class BlobTriggerInputBindingOutputBinding3
    {
        [FunctionName("BlobTriggerInputBindingOutputBinding3")]
        public static async Task Run(
            [BlobTrigger("upload/{name}", Connection = "scs")]Stream addedBlob,
            Binder binder, ILogger log)
        {
            // And if you want to determine where to bind at runtime, for instance to make the
            // decision for one container or the other in code, you can use the Binder class to 
            // bind dynamically!
            log.LogInformation("Dynamic output binding");
            BlobAttribute blobAttribute;

            // Determine which blob to actually use
            // In this case: one in the folder 'even-length', or one in the folder odd-length.
            if (addedBlob.Length % 2 == 0)
            {
                // Create the BlobAttribute dynamically during Function execution
                blobAttribute = new BlobAttribute("even-length/{name}", FileAccess.Write);
            }
            else
            {
                // Create the BlobAttribute dynamically during Function execution
                blobAttribute = new BlobAttribute("odd-length/{name}", FileAccess.Write);
            }

            // Use the dynamically created binding to bind and then use the stream.
            using var output = await binder.BindAsync<Stream>(blobAttribute);
            await addedBlob.CopyToAsync(output);
        }
    }
}