using HahnTestAppService.Contracts.Request;
using HahnTestAppService.Domain.Entities;
using HahnTestAppService.Repository.Interfaces;
using HahnTestAppService.Services.Interfaces;

namespace HahnTestAppService.Services.Implementation
{
    public class BrandsService : IBrandsService
    {
        private readonly IBrandsRepository _brandsRepository;

        public BrandsService(IBrandsRepository brandsRepository)
        {
            _brandsRepository = brandsRepository;
        }

        public async Task Add(AddUpdateBrandRequest brand)
        {
            var brandDb = new Brand() { Name = brand.Name };
            await _brandsRepository.Add(brandDb);
        }

        public async Task Delete(int id)
        {
            var brand = _brandsRepository.GetBrand(id, CancellationToken.None);
            await _brandsRepository.Remove(brand);
        }

        public async Task<List<GetBrandsRequest>> GetBrands(CancellationToken token)
        {
            var brands = await _brandsRepository.GetAllBrands(CancellationToken.None);
            return brands.Select(x => new GetBrandsRequest()
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();
        }

        public async Task Update(AddUpdateBrandRequest part)
        {
            var brand = await _brandsRepository.GetBrand((int)part.Id, CancellationToken.None);
            brand.Name = part.Name;
            await _brandsRepository.Remove(brand);
        }
    }
}
