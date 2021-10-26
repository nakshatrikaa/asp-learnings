using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Learn.Routing
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(option =>
            {
                option.ConstraintMap.Add("myCustom", typeof(MyCustomConstraint));
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/hello/{name:alpha:minlength(3)?}", async context =>
                {
                    var name = context.GetRouteValue("name");
                    await context.Response.WriteAsync($"Hello {name}");
                });

                endpoints.MapGet("/hello/{name:myCustom}", async context =>
                {
                    var name = context.GetRouteValue("name");
                    await context.Response.WriteAsync($"Hello from Custom {name}");
                });
                endpoints.MapControllers();
            });
        }
    }
}
