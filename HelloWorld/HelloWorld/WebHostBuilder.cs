using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class WebHostBuilder
{
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .Configure(app =>
            {
                app.Run(async context =>
                {
                    await GetResponse(context);
                });
            });

    private static async Task GetResponse(HttpContext context)
    {
        var requestType = context.Request.Method;
        switch (requestType)
        {
            case "GET":
                context.Response.StatusCode = 200;
                await context.Response.WriteAsync($"Hello Kathleen");
                break;
            case "POST":
                context.Response.StatusCode = 200;                
                await context.Response.WriteAsync($"new user sdkdfghdgh");
                break;
        }
    }
}