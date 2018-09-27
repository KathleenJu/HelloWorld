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
        private static readonly Greeter _greeter = new Greeter();
        private static readonly Names _names = new Names();

        public static void StartWebHost(string[] args) =>        
            WebHost.CreateDefaultBuilder(args)
                .Configure(app =>
                {
                    app.Run(async context =>
                    {
                        var currentDateTime = DateTime.Now;
                        await ExecuteRequestMethod(context, currentDateTime);
                    });
                }).Build().Run();

        private static async Task ExecuteRequestMethod(HttpContext context, DateTime dateTime)
        {            
            context.Response.StatusCode = 200;
            switch (context.Request.Method)
            {
                case "GET":
                {
                    await DisplayResponse(context, dateTime);
                    break;
                }
                case "POST":
                {
                    PostName(context);
                    await DisplayResponse(context, dateTime);
                    break;
                }
                case "DELETE":
                {
                    DeleteName(context);
                    await DisplayResponse(context, dateTime);
                    break;
                }
                case "PUT":
                {
                    UpdateName(context);
                    await DisplayResponse(context, dateTime);
                    break;
                }
            }
        }

        private static async Task DisplayResponse(HttpContext context, DateTime dateTime)
        {
            var greeting = GetGreeting(dateTime);
            await context.Response.WriteAsync(greeting);
        }

        private static void UpdateName(HttpContext context)
        {
            var nameToBeUpdated = context.Request.Path.Value.Trim('/');
            var newName = new StreamReader(context.Request.Body).ReadToEnd();
            _names.Update(nameToBeUpdated, newName);
        }

        private static void DeleteName(HttpContext context)
        {
            var nameToBeDeleted = new StreamReader(context.Request.Body).ReadToEnd();
            _names.Remove(nameToBeDeleted);
        }

        private static void PostName(HttpContext context)
        {
            var newName = new StreamReader(context.Request.Body).ReadToEnd();
            _names.Add(newName);
        }

        private static string GetGreeting(DateTime dateTime)
        {
            var users = _names.GetNames();
            var greeting = _greeter.Greet(users, dateTime);
            
            return greeting;
        }
    }
}