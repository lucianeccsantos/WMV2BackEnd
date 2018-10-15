using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using Rumo.WebMetasV2.Infra.Data.CrossCutting;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Elmah.Io.AspNetCore;
using System;

namespace Rumo.WebMetasV2.WebAPI
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("hosting.json", optional: true);

            //if (env.IsDevelopment())
            //{
            //    builder.AddUserSecrets<Startup>();
            //}

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddAutoMapper();

            services.AddMediatR(typeof(Startup));
            services.AddLogging();

            services.AddElmahIo(o =>
            {// Estes dados estão disponíveis em https://app.elmah.io/, acessando com as credenciais de email do webmetas
                o.ApiKey = "56ef02045f044d87b4cb900255c68416";
                o.LogId = new Guid("b5534b47-a638-431b-a090-677df5c8c12b");
            });
            services.Configure<ElmahIoOptions>(Configuration.GetSection("ElmahIo"));
            services.Configure<ElmahIoOptions>(o =>
            {
                o.OnMessage = msg =>
                {
                    msg.Version = "1.0.0";
                };
            });

            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              ILoggerFactory loggerFactory,
                              IHttpContextAccessor accessor)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseElmahIo();
            
            app.UseAuthentication();
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
