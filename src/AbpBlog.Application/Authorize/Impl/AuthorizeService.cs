﻿using AbpBlog.Domain;
using AbpBlog.Domain.Configurations;
using AbpBlog.ToolKits.Base;
using AbpBlog.ToolKits.Extensions;
using AbpBlog.ToolKits.GitHub;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpBlog.Application.Authorize.Impl
{
    public class AuthorizeService : ApplicationService, IAuthorizeService
    {
        private readonly IHttpClientFactory _httpClient;
        public AuthorizeService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<string>> GenerateTokenAsync(string access_token)
        {
            var result = new ServiceResult<string>();
            if (string.IsNullOrEmpty(access_token))
            {
                result.IsFailed("access_token为空");
                return result;
            }

            var url = $"{GitHubConfig.API_User}?access_token={access_token}";

            using var client = _httpClient.CreateClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.14 Safari/537.36 Edg/83.0.478.13");
            var httpReponse = new HttpResponseMessage();
            try
            {
                httpReponse = await client.GetAsync(url);
            }
            catch (Exception e)
            {

                result.IsFailed(e.Message);
                return result;
            }
            if (httpReponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                result.IsFailed("access_token");
                return result;
            }
            var content = await httpReponse.Content.ReadAsStringAsync();

            var user = content.FromJson<UserResponse>();
            if (user.IsNull())
            {
                result.IsFailed("未获取到用户数据");
                return result;
            }

            if (user.Id != GitHubConfig.UserId)
            {
                result.IsFailed("当前账号未授权");
                return result;
            }

            var claims = new[] {
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email??""),
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.Now.AddMinutes(AppSettings.JWT.Expires)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}")
            };

            var key = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.SerializeUtf8());
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken
            (
                issuer: AppSettings.JWT.Domain,
                audience: AppSettings.JWT.Domain,
                claims: claims,
                expires: DateTime.Now.AddMinutes(AppSettings.JWT.Expires),
                signingCredentials: creds
            );

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            result.IsSuccess(token);
            return await Task.FromResult(result);
        }


        public async Task<ServiceResult<string>> GetAccessTokenAsync(string code)
        {
            var result = new ServiceResult<string>();
            if (string.IsNullOrEmpty(code))
            {
                result.IsFailed("code为空");
                return result;
            }

            var request = new AccessTokenRequest();

            var content = new StringContent($"code={code}&client_id={request.Client_ID}&redirect_uri={request.Redirect_Uri}&client_secret={request.Client_Secret}");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var client = _httpClient.CreateClient();
            var httpResponse = await client.PostAsync(GitHubConfig.API_AccessToken, content);

            var response = await httpResponse.Content.ReadAsStringAsync();

            if (response.StartsWith("access_token"))
                result.IsSuccess(response.Split("=")[1].Split("&").First());
            else
                result.IsFailed("code不正确");

            return result;
        }

        public async Task<ServiceResult<string>> GetLoginAddressAsync()
        {
            var result = new ServiceResult<string>();
            var request = new AuthorizeRequest();

            var address = string.Concat(new string[]
            {
                GitHubConfig.API_Authorize,
                "?client_id=",request.Client_ID,
                "&scope=", request.Scope,
                "&state=", request.State,
                "&redirect_uri=", request.Redirect_Uri
            });

            result.IsSuccess(address);
            return await Task.FromResult(result);
        }
    }
}
