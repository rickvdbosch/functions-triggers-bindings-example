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
            if (addedBlob.Length % 2 == 0)
            {
                blobAttribute = new BlobAttribute("even-length/{name}", FileAccess.Write);
            }
            else
            {
                blobAttribute = new BlobAttribute("odd-length/{name}", FileAccess.Write);
            }

            using (var output = await binder.BindAsync<Stream>(blobAttribute))
            {
                await addedBlob.CopyToAsync(output);
            }
        }
    }
}