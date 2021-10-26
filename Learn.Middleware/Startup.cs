using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace simpleWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ConsoleLoggerMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/favicon.ico", _ => { });
            app.UseMiddleware<ConsoleLoggerMiddleware>();
            app.Map("/map", MapHandler);
            app.UseWhen(context => context.Request.Query.ContainsKey("q"), HandleRequestWithQuery);
            app.Run(async context =>
            {
                Console.WriteLine("Log : Hello World");
                await context.Response.WriteAsync("Hello World");
            });
        }

        private void HandleRequestWithQuery(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Log : Contains Query");
                await next();
            });
        }

        private void MapHandler(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                Console.WriteLine("Log : Hello World from MapHandler");
                await context.Response.WriteAsync("Hello World from Map");
            });
        }
    }
}