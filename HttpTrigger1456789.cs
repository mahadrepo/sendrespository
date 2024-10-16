using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class HttpTrigger1456789
    {
        private readonly ILogger<HttpTrigger1456789> _logger;

        public HttpTrigger1456789(ILogger<HttpTrigger1456789> logger)
        {
            _logger = logger;
        }

        [Function("HttpTrigger1456789")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            // Redirect to the HelloWorldFunction
            string redirectUrl = "https://test-function-app-cicd.azurewebsites.net/api/HttpTrigger1?code=fL2tJjobDDHxjMjw3XTJMsX2E_ZLKhmM98dtHxcVn1wyAzFuz0RmVg%3D%3D/HelloWorldFunction";
            return new RedirectResult(redirectUrl);
        }
    }
}
