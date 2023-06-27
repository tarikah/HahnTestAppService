using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.DI
{
    public static class Resolution
    {
        public static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.RegisterRepos();
            services.RegisterServices();
            return services;
        }
    }
}
