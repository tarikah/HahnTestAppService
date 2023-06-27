using HahnTestAppService.Repository.Concretes;
using HahnTestAppService.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HahnTestAppService.DI
{
    public static class RepositoryResolution
    {
        public static IServiceCollection RegisterRepos(this IServiceCollection services)
        {
            services.AddTransient<IPartsRepository, PartsRepository>();
            services.AddTransient<IBrandsRepository, BrandRepository>();
            services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
            services.AddTransient<IPartBrandsRepository, PartBrandsRepository>();
            return services;
        }
    }
}
