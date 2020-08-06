﻿using AbpBlog.Domain;
using AbpBlog.Domain.Shared;
using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;

namespace AbpBlog.BackgroundJobs
{
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class AbpBlogBackgroundJobsModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHangfire(config => 
            {
                config.UseStorage(
                    new SqlServerStorage(AppSettings.ConnectionStrings,
                    new SqlServerStorageOptions 
                    {
                        SchemaName = AbpBlogConsts.DbTablePrefix + "hangfire"
                    }));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseHangfireServer();
            app.UseHangfireDashboard(options: new DashboardOptions 
            {
                Authorization=new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        RequireSsl=false,
                        SslRedirect=false,
                        LoginCaseSensitive=true,
                        Users=new[]
                        {
                            new BasicAuthAuthorizationUser
                            { 
                                Login=AppSettings.Hangfire.Login,
                                PasswordClear=AppSettings.Hangfire.Password
                            }
                        }
                    })
                },
                DashboardTitle="任务调度中心"
            });

            var service = context.ServiceProvider;
            service.UseHangfireTest();
        }
    }
}
