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
        private static readonly Greeter Names = new Greeter();
        private static readonly CSVFileIO CSVFileIO = new CSVFileIO();
        private const string _filePath = @"Files/users.csv";

        public static void StartWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .Configure(app =>
                {
                    app.Run(async context =>
                    {
                        var currentDateTime = DateTime.Now;
                        await Foo(context, currentDateTime);
                    });
                }).Build().Run();

        private static async Task Foo(HttpContext context, DateTime dateTime)
        {
            context.Response.StatusCode = 200;
            switch (context.Request.Method)
            {
                case "GET":
                {
                    var fileContent = CSVFileIO.ReadFileContent(_filePath);
                    Names.SetCurrentNames(fileContent);
                    
                    var greeting = Names.Greet(dateTime);
                    await context.Response.WriteAsync(greeting);
                    break;
                }
                case "POST":
                {
                    var newName = new StreamReader(context.Request.Body).ReadToEnd();
                    Names.AddName(newName);
                    CSVFileIO.RewriteFileWithNewContent(_filePath, Names.CurrentNames);

                    var greeting = Names.Greet(dateTime);
                    await context.Response.WriteAsync(greeting);
                    break;
                }
                case "DELETE":
                {
                    var nameToBeDeleted = new StreamReader(context.Request.Body).ReadToEnd();
                    Names.RemoveName(nameToBeDeleted);
                    CSVFileIO.RewriteFileWithNewContent(_filePath, Names.CurrentNames);

                    var greeting = Names.Greet(dateTime);
                    await context.Response.WriteAsync(greeting);
                    break;
                }
                case "PUT":
                {
                    var nameToBeUpdated = context.Request.Path.Value.Trim('/');
                    var newName = new StreamReader(context.Request.Body).ReadToEnd();
                    Names.UpdateUser(nameToBeUpdated, newName);
                    CSVFileIO.RewriteFileWithNewContent(_filePath, Names.CurrentNames);

                    var greeting = Names.Greet(dateTime);
                    await context.Response.WriteAsync(greeting);
                    break;
                }
            }
        }
    }
}