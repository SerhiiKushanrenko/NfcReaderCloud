﻿using BLL.Services;
using BLL.Services.Interfaces;
using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class Extensions
    {
        public static void AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayer(configuration);

            services.AddSingleton(opt => new Dictionary<Guid, string>());
            services.AddScoped<IAddGuidService, AddGuidService>();
            services.AddScoped<ICheckDataService, CheckDataService>();
            services.AddScoped<IAppStatusService, AppStatusService>();
        }
    }
}
