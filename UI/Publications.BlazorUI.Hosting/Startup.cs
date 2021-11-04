using System;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Publications.DAL.Context;
using Publications.DAL.Repositories;
using Publications.DAL.Sqlite;
using Publications.DAL.SqlServer;

namespace Publications.BlazorUI.Hosting
{
    public record Startup(IConfiguration Configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var db_type = Configuration["Database"];

            switch (db_type)
            {
                default: throw new InvalidOperationException($"База данных {db_type} не поддерживается");

                case "InMemory":
                    services.AddDbContext<PublicationsDB>(opt => opt.UseInMemoryDatabase("PublicationsDb"))
                       .AddTransient<IDbInitializer>(
                            s => new PublicationsDBInitializer(
                                s.GetRequiredService<PublicationsDB>(), 
                                s.GetRequiredService<ILogger<PublicationsDBInitializer>>()) 
                                { Ignore = true })
                       .AddPublicationsRepositories();
                    break;

                case "SqlServer":
                    services.AddPublicationsDbContextSqlServer(Configuration.GetConnectionString(db_type));
                    break;

                case "Sqlite":
                    services.AddPublicationsDbContextSqlite(Configuration.GetConnectionString(db_type));
                    break;
            }

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                //opt.ApiVersionReader = new MediaTypeApiVersionReader("x-api-version");
                //opt.ApiVersionReader = new QueryStringApiVersionReader("x-api-version");
                opt.ApiVersionReader = new HeaderApiVersionReader("x-api-version");

            });

            services.AddSignalR();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Publications.WEB.API", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Publications.WEB.API v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            //app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
