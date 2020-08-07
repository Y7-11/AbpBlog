﻿using AbpBlog.BackgroundJobs.Jobs.Hangfire;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;
using Hangfire;
using AbpBlog.BackgroundJobs.Jobs.Wallpapers;
using AbpBlog.BackgroundJobs.Jobs.HotNews;

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

        /// <summary>
        /// 壁纸数据抓取
        /// </summary>
        /// <param name="service"></param>
        public static void UseWallpaperJob(this IServiceProvider service)
        {
            var job = service.GetService<WallpaperJob>();

            RecurringJob.AddOrUpdate("壁纸数据抓取", () => job.ExecuteAsync(), CronType.Hour(1, 3));
        }

        /// <summary>
        /// 每日热点数据抓取
        /// </summary>
        /// <param name="context"></param>
        public static void UseHotNewsJob(this IServiceProvider service)
        {
            var job = service.GetService<HotNewsJob>();

            RecurringJob.AddOrUpdate("每日热点数据抓取", () => job.ExecuteAsync(), CronType.Hour(1, 2));
        }
    }
}
