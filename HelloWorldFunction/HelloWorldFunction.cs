using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function.HelloWorld
{
    public class HelloWorldFunction
    {
        private readonly ILogger<HelloWorldFunction> _logger;

        public HelloWorldFunction(ILogger<HelloWorldFunction> logger)
        {
            _logger = logger;
        }

        [Function("HelloWorldFunction")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("HelloWorld function processed a request.");

            // Retrieve the "page" query parameter
            string page = req.Query["page"];

            // Handle different pages based on the query parameter
            switch (page)
            {
                case "1":
                    return new OkObjectResult("Hello World");
                case "2":
                    return new OkObjectResult("Page 2");
                case "add":
                    return AddTwoDigits(req);
                default:
                    return new OkObjectResult("Welcome to our Azure Function App! Please specify a page.");
            }
        }

        private IActionResult AddTwoDigits(HttpRequest req)
        {
            // Retrieve the two digits from the query parameters
            string num1Str = req.Query["num1"];
            string num2Str = req.Query["num2"];

            if (int.TryParse(num1Str, out int num1) && int.TryParse(num2Str, out int num2))
            {
                int sum = num1 + num2;
                return new OkObjectResult($"The sum of {num1} and {num2} is {sum}.");
            }
            else
            {
                return new BadRequestObjectResult("Please provide valid integers for num1 and num2.");
            }
        }
    }
}
