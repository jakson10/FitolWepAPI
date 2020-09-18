using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitOl.WebAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string APIKEYNAME = "ApiKey";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key saglanamadı. (ApiKeyMiddleware kullanilarak)");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<Microsoft.Extensions.Configuration.IConfiguration>();

            // Sadece kurun Microsoft.Extensions.Configuration.Binderve yöntem mevcut olacaktır.
            // Nedeni, GetValue<T> bir uzatma yöntemi olması ve doğrudan IConfigurationarayüzde mevcut olmamasıdır .
            var apiKey = appSettings.GetValue<string>(APIKEYNAME);

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Yetkisiz client. (ApiKeyMiddleware kullanilarak))");
                return;
            }

            await _next(context);

        }
    }
}
