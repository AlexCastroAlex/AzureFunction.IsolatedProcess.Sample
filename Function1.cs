using System.Collections.Generic;
using System.Net;
using AzureFunction.DependyInjection.Sample.Repository.Books;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AzureFunction.DependyInjection.Sample
{
    public  class Function1
    {
        private  IBookRepository _bookRepository { get; set; }
        public Function1(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [Function("Function1")]
        public  HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Function1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
