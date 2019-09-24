using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using order.commandservices;
using order.commandservices.Services;
using order.queryservices;
using order.queryservices.Services;

namespace webapi
{
    public class Startup
    {
        private readonly ILogger<Startup> logger;

        public Startup(IConfiguration configuration, ILogger<Startup> _logger)
        {
            Configuration = configuration;
            logger = _logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<queryDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
              );

            services.AddDbContext<commandDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
             );

            services.AddCors(options =>
            {
                options.AddPolicy("AllowUIOrigin",
                                   builder =>
                                   {
                                       builder.WithOrigins(Configuration["AppSettings:webuiUrl"].ToString());
                                       builder.AllowAnyHeader();
                                       builder.AllowAnyMethod();
                                       builder.AllowCredentials();
                                   });

            });

            services.AddTransient<IOrderCommands, OrderCommands>();
            services.AddTransient<IOrderQuery, OrderQuery>();

            services.AddAutoMapper(typeof(Startup));

            services.AddLogging(lb =>
            {
                lb.AddConfiguration(Configuration.GetSection("Logging"));
                lb.AddConsole();
                lb.AddEventSourceLogger();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowUIOrigin");


            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();

                        if (ex != null)
                        {
                            logger.LogError(ex.Error, "unhandled error", null);

                            var err = JsonConvert.SerializeObject(new Error()
                            {
                                Message = "There is an issue with the services. Please contact system admin.",
                                SupportEmail = "arun.madhu@outlook.com"
                            });
                            context.Response.StatusCode = 400;
                            await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(err), 0, err.Length).ConfigureAwait(false);
                        }
                    });
            });

            app.UseMvc();
        }
    }

    public class Error
    {
        public string Message { get; set; }
        public string SupportEmail { get; set; }
    }
}
