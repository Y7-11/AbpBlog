using AbpBlog.EntityFrameworkCore;
using AbpBlog.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Microsoft.IdentityModel.Tokens;
using System;
using AbpBlog.Domain;
using AbpBlog.HttpApi.Hosting.Middleware;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using AbpBlog.HttpApi.Hosting.Filters;

namespace AbpBlog.Web
{
    [DependsOn(
           typeof(AbpAspNetCoreMvcModule),
           typeof(AbpAutofacModule),
           typeof(AbpBlogHttpApiModule),
           typeof(AbpBlogSwaggerModule),
           typeof(AbpBlogFrameworkCoreModule)

        )]
    public class AbpBlogHttpApiHostingModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option => 
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience=true,
                        ValidateLifetime=true,
                        ClockSkew=TimeSpan.FromSeconds(30),
                        ValidateIssuerSigningKey=true,
                        ValidAudience = AppSettings.JWT.Domain,
                        ValidIssuer = AppSettings.JWT.Domain,
                        IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                    };
                });

            context.Services.AddAuthorization();
            context.Services.AddHttpClient();

            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                //移除abp异常Filter
                options.Filters.Remove(filterMetadata);
                // 添加自己实现的 MeowvBlogExceptionFilter
                options.Filters.Add(typeof(AbpBlogExceptionFilter));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();
   
            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 路由
            app.UseRouting();

            // 身份验证
            app.UseAuthentication();

            // 认证授权
            app.UseAuthorization();

            // 异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
