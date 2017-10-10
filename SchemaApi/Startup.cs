using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Domain.Contracts;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace SchemaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StorageContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUnitOfWork, EntityFrameworkUnitOfWork>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler(
     builder =>
     {
         builder.Run(
         async context =>
         {
             context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
             context.Response.ContentType = "application/json";
             var ex = context.Features.Get<IExceptionHandlerFeature>();
             if (ex != null)
             {
                 var err = JsonConvert.SerializeObject(new Error()
                 {
                     Stacktrace = ex.Error.StackTrace,
                     Message = ex.Error.Message
                 });
                 await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(err), 0, err.Length).ConfigureAwait(false);
             }
         });
     }
);

            app.UseMvc();
        }
    }

    class Error
    {
        public string Message { get; set; }
        public string Stacktrace { get; set; }
    }
}
