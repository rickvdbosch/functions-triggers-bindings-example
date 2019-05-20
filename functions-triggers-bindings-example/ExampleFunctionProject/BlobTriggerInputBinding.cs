using System.IO;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;

using ExampleFunctionProject.Helpers;

namespace ExampleFunctionProject
{
    public static class BlobTriggerInputBinding
    {
        [FunctionName("BlobTriggerInputBinding")]
        public static async Task Run(
            [BlobTrigger("upload/{name}", Connection = "scs")]Stream addedBlob,
            string name, ILogger log)
        {
            // The below code is the 'normal' way of uploading a file to storage:
            // - Connect to a Storage Account
            // - Create a BlobClient
            // - Get a reference to a container (and create it if it doesn't exist)
            // - Get a reference to a blob
            // - Upload the file
            log.LogInformation("We're starting our complex copy action here!");
            var connectionString = SettingsHelper.GetEnvironmentVariable("scs");
            var storageAccount = CloudStorageAccount.Parse(connectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("copied");
            await container.CreateIfNotExistsAsync();
            var blob = container.GetBlockBlobReference(name);

            await blob.UploadFromStreamAsync(addedBlob);
        }
    }
}