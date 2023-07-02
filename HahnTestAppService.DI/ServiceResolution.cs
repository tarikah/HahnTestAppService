using HahnTestAppService.Services.Implementation;
using HahnTestAppService.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.DI
{
    public static class ServiceResolution
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPartsService, PartsService>();
            services.AddScoped<IBrandsService, BrandsService>();
            services.AddScoped<IManufacturerService, ManufacturersService>();
            return services;
        }
    }
}
