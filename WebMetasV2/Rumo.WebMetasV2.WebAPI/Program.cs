using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Elmah.Io;
using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Rumo.WebMetasV2.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((ctx, logging) =>
                {
                    logging.Services.Configure<ElmahIoProviderOptions>(ctx.Configuration.GetSection("ElmahIo"));
                    logging.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Information);
                    logging.AddConfiguration(ctx.Configuration.GetSection("Logging"));
                    logging.AddElmahIo();
                })
                .Build();
    
    }
}
