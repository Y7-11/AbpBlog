﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AbpBlog.Domain
{
    /// <summary>
    /// appsettings.json配置文件数据读取类
    /// </summary>
    public class AppSettings
    {

        /// <summary>
        /// Hangfire
        /// </summary>
        public static class Hangfire
        {
            public static string Login => _config["Hangfire:Login"];

            public static string Password => _config["Hangfire:Password"];
        }
        /// <summary>
        /// 配置文件的根节点
        /// </summary>
        private static readonly IConfigurationRoot _config;

        /// <summary>
        /// Caching
        /// </summary>
        public static class Caching
        {
            /// <summary>
            /// RedisConnectionString
            /// </summary>
            public static string RedisConnectionString => _config["Caching:RedisConnectionString"];
        }

        /// <summary>
        /// 当前API版本，从appsettings.json获取
        /// </summary>
        public static string ApiVersion => _config["ApiVersion"];

        public static class JWT
        {
            public static string Domain => _config["JWT:Domain"];

            public static string SecurityKey => _config["JWT:SecurityKey"];

            public static int Expires => Convert.ToInt32(_config["JWT:Expires"]);
        }

        /// <summary>
        /// GitHub
        /// </summary>
        public static class GitHub
        {
            public static int UserId => Convert.ToInt32(_config["Github:UserId"]);

            public static string Client_ID => _config["Github:ClientID"];

            public static string Client_Secret => _config["Github:ClientSecret"];

            public static string Redirect_Uri => _config["Github:RedirectUri"];

            public static string ApplicationName => _config["Github:ApplicationName"];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        static AppSettings()
        {
            // 加载appsettings.json，并构建IConfigurationRoot
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", true, true);
            _config = builder.Build();
        }

        /// <summary>
        /// EnableDb
        /// </summary>
        public static string EnableDb => _config["ConnectionStrings:Enable"];

        /// <summary>
        /// ConnectionStrings
        /// </summary>
        public static string ConnectionStrings => _config.GetConnectionString(EnableDb);
    }

}
