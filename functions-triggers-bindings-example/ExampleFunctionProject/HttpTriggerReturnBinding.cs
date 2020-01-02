using System.Threading.Tasks;
using System.Threading;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using ExampleFunctionProject.Models;

namespace ExampleFunctionProject
{
    public static class HttpTriggerReturnBinding
    {
        [FunctionName(nameof(HttpTriggerReturnBinding))]
        [return: Blob("copied/{sys.randguid}.txt", Connection = "scs")]
        public static async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] RequestModel req,
            ILogger log,
            CancellationToken cancellationToken)
        {
            // There are two important things here:
            // 1. The HttpTrigger isn't bound to a generic HttpRequest, but is TYPED.
            //    The platform takes care of the deserialization of the message body for you.
            // 2. The return binding above the Function also does a couple of things for you:
            //    - It creates a Blob in the 'copied' container with a random GUID as the filename
            //    - It automatically writes the output of the Function call into that Blob
            return req.Message;
        }
    }
}
