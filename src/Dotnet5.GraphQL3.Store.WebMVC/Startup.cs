using System;
using Dotnet5.GraphQL3.Store.WebMVC.Clients;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dotnet5.GraphQL3.Store.WebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton(provider
                => new GraphQLHttpClient(
                    endPoint: new Uri(Configuration["HttpClient:Store"]),
                    serializer: new SystemTextJsonSerializer(options =>
                    {
                        options.PropertyNameCaseInsensitive = true;
                        options.IgnoreNullValues = true;
                    })));

            services.AddSingleton<IStoreGraphClient, StoreGraphClient>();
        }
    }
}