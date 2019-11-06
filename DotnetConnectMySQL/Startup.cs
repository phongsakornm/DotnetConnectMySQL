using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DotnetConnectMySQL.Contexts;
using DotnetConnectMySQL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace DotnetConnectMySQL
{
    public class Startup
    {
        private readonly string strConnectDataBase = "";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
           .AddJsonFile("message.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables();
            Configuration = builder.Build();

            this.strConnectDataBase = Configuration.GetConnectionString("MySqlDB");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Swagger
            string assemName = "";
            string assemVer = "";
            string dateModified = "";
            try
            {
                var assemblyAll = Assembly.GetEntryAssembly().GetName();
                var assemblyExe = Assembly.GetExecutingAssembly();
                assemName = assemblyAll.Name;
                assemVer = assemblyAll.Version.ToString();

                FileInfo file = new FileInfo(assemblyExe.Location);
                dateModified = file.LastWriteTime.ToString("dd/MM/yyyy : HH:mm:ss");
            }
            catch { }
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Dotnet Connect MySQL (" + DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString() + ")",
                    Description = assemName + " [Version : " + assemVer + ", Date Modified : " + dateModified + "]"
                });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "DotnetConnectMySQL.xml");
                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<DepartmentContext>(options => options.UseMySQL(this.strConnectDataBase));

            services.AddScoped<IDepartmentContext, DepartmentContext>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
