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
using System.Linq;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using AbpBlog.HttpApi.Hosting.Filters;
using AbpBlog.BackgroundJobs;
using Microsoft.AspNetCore.HttpOverrides;

namespace AbpBlog.Web
{
    [DependsOn(
           typeof(AbpAspNetCoreMvcModule),
           typeof(AbpAutofacModule),
           typeof(AbpBlogHttpApiModule),
           typeof(AbpBlogBackgroundJobsModule),
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
            //context.Services.AddTransient<IHostedService, HelloWorldJob>();
            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                //移除abp异常Filter
                options.Filters.Remove(filterMetadata);
                // 添加自己实现的 MeowvBlogExceptionFilter
                options.Filters.Add(typeof(AbpBlogExceptionFilter));
            });
            //设置swagger中的url
            context.Services.AddRouting(options => 
            {
                // 设置URL为小写
                options.LowercaseUrls = true;
                // 在生成的URL后面添加斜杠
                options.AppendTrailingSlash = true;
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

            //该中间件添加了严格传输安全头
            app.UseHsts();

            //使用默认跨域配置
            app.UseCors();

            //HTTP请求转HTTPS
            app.UseHttpsRedirection();

            //转发将标头代理到当前请求，配合 Nginx 使用，获取用户真实IP
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

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
