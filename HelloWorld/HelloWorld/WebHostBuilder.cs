using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace HelloWorld
{
    public static class WebHostBuilder
    {
        public static void StartWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .Configure(app =>
                {
                    app.Run(async context =>
                    {
                        var requestMethod = context.Request.Method;
                        await GetResponse(requestMethod, context);
                    });
                }).Build().Run();

        private static async Task GetResponse(string requestMethod, HttpContext context)
        { 
            switch (requestMethod)
            {
                case "GET":
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Hello Kathleen - the time on the server is");
                    break;
                case "POST":
                    context.Response.StatusCode = 200;
                    var body = new StreamReader(context.Request.Body).ReadToEnd();
                    await context.Response.WriteAsync("new userr " + body);
                    break;
            }
        }
    }
}