using CRM.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace CRM
{
    public class Startup
    {
        private readonly IConfiguration _Configuration;
        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc();
            services.AddCors(corsoptions =>
            {
                corsoptions.AddPolicy(name: "any", configurePolicy: corsPolicyBulider =>
                {
                    corsPolicyBulider
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
                });
            });
            services.AddDbContext<CRMContext>(options =>
            {
                options.UseSqlServer(_Configuration.GetConnectionString("Conn"));

            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "swagg测试",  //标题
                    Description = "前后端接口",  //描述文字
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "CRM",
                        Email = "@xxx.com",
                        Url = "https://localhost:8085"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //这个就是刚刚配置的xml文件名
                c.IncludeXmlComments(xmlPath, true);
                //默认第二个参数是false,是controller的注释
            });
            //设置Swagger Json UI的注释和路径

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Login}/{action=post}/{id?}");
                routes.MapRoute(
                    name: "Home",
                    template: "api/{controller=Home}/{action=Get}/{id?}");
                routes.MapRoute(
                   name: "Major",
                   template: "api/{controller=Major}/{action=Get}/{id?}");
            });
            //启用中间件服务生成Swagger
            app.UseSwagger();
            app.UseCors("any");
            //启用中间件服务生成Swagger，指定 Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web App V1");
                c.RoutePrefix = string.Empty;
                //路径配置，设置为空，表示直接在根域名（localhost:8005）访问该文件,
                //注意localhost:8005/swagger是访问不到的，去launchSettings.json把launchUrl去掉
            });
        }
    }
}
