﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace HIBP.Toolkit
{
    /// <summary>
    /// This sets up all you need to utilize the Have I beeen Pwned Toolkit. Just enter your API key
    /// </summary>
    public static class IServiceCollectionExtensions
    {
        public static void AddHibpToolkit(this IServiceCollection services, string apiKey)
        {
            ValidateString(apiKey);
            services.AddTransient<IHibpClient, HibpClient>();
            services.AddLogging();
            services.AddHttpClient("Have I been Pwned", client =>
            {
                client.DefaultRequestHeaders.Add("hibp-api-key", apiKey);
                client.DefaultRequestHeaders.Add("user-agent", "HIBP.Toolkit");
            });
        }

        private static void ValidateString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("String argument must contain a value");
            }
        }
    }
}