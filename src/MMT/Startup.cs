using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMT.Common.CustomExceptions;
using MMT.Common.Models;
using MMT.Core;
using MMT.Data;
using MMT.Data.Interfaces;
using MMT.Data.Repositories;
using System;

namespace MMT
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();

            services.AddControllers().AddJsonOptions(options =>
            {
                //Added to exclude null values like when doesn't have any "Orders"
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());
            });

            services.Configure<UserAPISettings>(_configuration.GetSection("UserAPI"));

            services.AddDbContext<MMTContext>(o => o.UseSqlServer(_configuration["sqlconnection:connectionString"]));

            services.AddScoped<IMMTHttpClient, MMTHttpClient>();
            services.AddScoped<IUserAPIClient, UserAPIClient>();
            services.AddScoped<IOrderRepo, OrderRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            //For ease i have written Middleware here, this moved to a dedicated class file
            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch (APIException ex)
                {
                    context.Response.StatusCode = ex.StatusCodes;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync($"{ex.Message} - Status code: {ex.StatusCodes}");
                }
                catch (Exception)
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Internla Error");
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
