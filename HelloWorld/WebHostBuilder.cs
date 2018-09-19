using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;

namespace HelloWorld
{
    public static class WebHostBuilder
    {
        private static readonly CSVFileParser _csvFileParser = new CSVFileParser(@"Files/users.csv");

        public static void StartWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .Configure(app =>
                {
                    app.Run(async context =>
                    {
                        var requestMethod = context.Request.Method;
                        await Foo(requestMethod, context);
                    });
                }).Build().Run();

        private static async Task Foo(string requestMethod, HttpContext context)
        {
            switch (requestMethod)
            {
                case "GET":
                    await GetResponseForGETRequest(context);
                    break;
                case "POST":
                    await GetResponseForPOSTRequest(context);
                    break;
                case "DELETE":
                    await GetResponseForDELETERequest(context);
                    break;
                case "PUT":
                    await GetResponseForPUTRequest(context);
                    break;
            }
        }

        private static async Task GetResponseForPUTRequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            var test = context.Request;
            var name = context.Request.Query.Keys.First();
            var body = new StreamReader(context.Request.Body).ReadToEnd();
            _csvFileParser.UpdateUser(name, body);
            await context.Response.WriteAsync(_csvFileParser.GetUsers());
        }

        private static async Task GetResponseForDELETERequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            var body = new StreamReader(context.Request.Body).ReadToEnd();
            _csvFileParser.RemoveUser(body);

            await context.Response.WriteAsync(_csvFileParser.GetUsers());
        }

        private static async Task GetResponseForGETRequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(_csvFileParser.GetUsers());
        }

        //doing two things in switch statement, it says post but function is getting something(from its name)
        private static async Task GetResponseForPOSTRequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            var body = new StreamReader(context.Request.Body).ReadToEnd();
            _csvFileParser.AddNewUser(body);
            await context.Response.WriteAsync(_csvFileParser.GetUsers());
        }
    }
}