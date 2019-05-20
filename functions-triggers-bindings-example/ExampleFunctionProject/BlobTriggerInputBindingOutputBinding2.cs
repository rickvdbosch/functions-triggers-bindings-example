using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ExampleFunctionProject
{
    public static class BlobTriggerInputBindingOutputBinding2
    {
        [FunctionName("BlobTriggerInputBindingOutputBinding2")]
        public static async Task Run(
            [BlobTrigger("upload/{name}", Connection = "scs")]Stream addedBlob,
            [ServiceBus("process", Connection = "sbcs", EntityType = EntityType.Queue)]ICollector<string> queueCollector,
            ILogger log)
        {
            log.LogInformation("Here we go... Messages!");
            using (var reader = new StreamReader(addedBlob))
            {
                // The ServiceBus Output binding using an ICollector<T> which enables you to write a 
                // message to the queue/topic you bind to EACH TIME YOU CALL Add()!
                var words = (await reader.ReadToEndAsync()).Split(' ');
                Parallel.ForEach(words.Distinct(), (word) =>
                {
                    queueCollector.Add(word);
                });
            }
        }
    }
}