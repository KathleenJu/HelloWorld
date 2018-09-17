using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class WebHostBuilder
{
    //rename function name to Run? Build?
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .Configure(app =>
            {
                app.Run(async context =>
                {
                    var requestMethod = context.Request.Method;
                    await GetResponse(requestMethod, context);
                });
            });

    private static async Task GetResponse(string requestMethod, HttpContext context)
    { 
        switch (requestMethod)
        {
            case "GET":
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync("Hello Kathleen");
                break;
            case "POST":
                context.Response.StatusCode = 200;                
                await context.Response.WriteAsync("new user sdkdfghdgh");
                break;
        }
    }
}