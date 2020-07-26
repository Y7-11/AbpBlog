﻿using AbpBlog.ToolKits.Base;
using AbpBlog.ToolKits.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AbpBlog.Domain.Shared.AbpBlogConsts;

namespace AbpBlog.Application.Caching.Authorize.Impl
{
    public class AuthorizeCacheService : CachingServiceBase, IAuthorizeCacheService
    {
        private const string KEY_GetLoginAddress = "Authorize:GetLoginAddress";

        private const string KEY_GetAccessToken = "Authorize:GetAccessToken-{0}";

        private const string KEY_GenerateToken = "Authorize:GenerateToken-{0}";

        /// <summary>
        /// 登录成功，生成Token
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GenerateTokenAsync(string access_token, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GenerateToken.FormatWith(access_token), factory, CacheStrategy.ONE_HOURS);
        }

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code"></param>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetAccessTokenAsync(string code, Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetAccessToken.FormatWith(code), factory, CacheStrategy.FIVE_MINUTES);
        }

        /// <summary>
        /// 获取登录地址(GitHub)
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetLoginAddressAsync(Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetLoginAddress, factory, CacheStrategy.NEVER);
        }
    }
}
