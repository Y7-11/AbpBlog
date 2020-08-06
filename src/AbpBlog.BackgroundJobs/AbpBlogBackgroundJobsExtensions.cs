using AbpBlog.BackgroundJobs.Jobs.Hangfire;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using Hangfire;

namespace AbpBlog.BackgroundJobs
{
    public static class AbpBlogBackgroundJobsExtensions
    {
        public static void UseHangfireTest(this IServiceProvider serviceProvider) 
        {
            var job= serviceProvider.GetService<HangfireTestJob>();

            RecurringJob.AddOrUpdate("定时任务测试", () => job.ExecuteAsync(), CronType.Minute());

            //RecurringJob.AddOrUpdate()是定期作业按指定的计划触发任务，同时还有Enqueue、Schedule、ContinueJobWith等等，
            //可以看一下Hangfire官方文档：https://docs.hangfire.io/en/latest/
        }
    }
}
