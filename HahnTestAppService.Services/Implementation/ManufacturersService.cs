using HahnTestAppService.Domain.Entities;
using HahnTestAppService.Repository.Interfaces;
using HahnTestAppService.Services.Interfaces;

namespace HahnTestAppService.Services.Implementation
{
    public class ManufacturersService : IManufacturerService
    {
        private readonly IManufacturerRepository _repo;

        public ManufacturersService(IManufacturerRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Manufacturer>> GetManufacturers(CancellationToken token)
        {
            var manufacturers= await _repo.GetAllManufacturers(token);
            return manufacturers.ToList();
        }
    }
}
