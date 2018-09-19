using System;
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
        private static readonly UserManager UserManager = new UserManager(@"Files/users.csv");

        public static void StartWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .Configure(app =>
                {
                    app.Run(async context =>
                    {
                        await Foo(context);
                    });
                }).Build().Run();

        private static async Task Foo(HttpContext context)
        {
            switch (context.Request.Method)
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

        //greet(){ "Hi x.GetUsers(fileContent) - time on the server..."}
        private static async Task GetResponseForPUTRequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            var nameToBeUpdated = context.Request.Path.Value.Trim('/');
            var newName = new StreamReader(context.Request.Body).ReadToEnd();
            UserManager.UpdateUser(nameToBeUpdated, newName);
            await context.Response.WriteAsync(UserManager.GetUsers());
        }

        private static async Task GetResponseForDELETERequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            var body = new StreamReader(context.Request.Body).ReadToEnd();
            UserManager.RemoveUser(body);

            await context.Response.WriteAsync(UserManager.GetUsers());
        }

        private static async Task GetResponseForGETRequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(UserManager.GetUsers());
        }

        //doing two things in switch statement, it says post but function is getting something(from its name)
        private static async Task GetResponseForPOSTRequest(HttpContext context)
        {
            context.Response.StatusCode = 200;
            var newName = new StreamReader(context.Request.Body).ReadToEnd();
            UserManager.AddNewUser(newName);
            await context.Response.WriteAsync(UserManager.GetUsers());
        }
    }
}