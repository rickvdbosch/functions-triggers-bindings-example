using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ExampleFunctionProject
{
    public static class ServiceBusTrigger
    {
        [FunctionName("ServiceBusTrigger")]
        public static void Run([ServiceBusTrigger("coolQueue", Connection = "sbcs")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
