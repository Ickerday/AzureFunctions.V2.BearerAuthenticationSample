using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AuthenticationSample.Functions
{
    public static class AuthenticateFunction
    {
        [FunctionName(nameof(AuthenticateFunction))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods), Route = "auth")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var bearer = req?.Headers["Bearer"];

            return await Task.FromResult(new JsonResult(bearer))
                .ConfigureAwait(false);
        }
    }
}
