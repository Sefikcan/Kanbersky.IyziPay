using AutoMapper;
using Kanbersky.IyziPay.Business.Abstract;
using Kanbersky.IyziPay.Business.Concrete;
using Kanbersky.IyziPay.Business.Mappings.AutoMapper;
using Kanbersky.IyziPay.Core.Extensions;
using Kanbersky.IyziPay.Core.Settings.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Kanbersky.IyziPay.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kanbersky.IyziPay Microservice",
                    Version = "v1",
                    Description = "An API to perform IyziPay operations"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //services.Configure<ElasticSearchSettings>(Configuration.GetSection("ElasticSearchSettings"));
            //services.AddSingleton(typeof(ElasticClientProvider));

            var ýyziPaySettings = Configuration.GetSection("IyziPaySettings").Get<IyziPaySettings>();
            services.AddSingleton(ýyziPaySettings);

            services.AddTransient<IIyziPayService, IyziPayService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BusinessProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseExceptionMiddleware();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kanbersky.IyziPay v1");
            });
        }
    }
}
