using HahnTestAppService.Contracts.Helpers;
using HahnTestAppService.Contracts.Request;
using HahnTestAppService.Contracts.Response;
using HahnTestAppService.Domain.Entities;
using HahnTestAppService.Repository.Interfaces;
using HahnTestAppService.Services.Interfaces;

namespace HahnTestAppService.Services.Implementation
{
    public class PartsService : IPartsService
    {
        private readonly IPartsRepository _partsRepo;
        private readonly IBrandsRepository _brandsRepo;

        public PartsService(IPartsRepository partsRepo, IBrandsRepository brandsRepo)
        {
            _partsRepo = partsRepo;
            _brandsRepo = brandsRepo;
        }

        public async Task Add(AddUpdatePartRequest part)
        {
            var partDb = new CarPart()
            {
                Name = part.Name,
                Composition = part.Composition,
                SerialNumber = part.SerialNumber,
                MadeOn = part.MadeOn,
                ValidTill = part.MadeOn.AddYears(10),
                ManufacturerId = part.ManufacturerId,
                ReservedQuantity = part.ReservedQuantity,
                TotalQuantity = part.TotalQuantity,

            };
            await _partsRepo.Add(partDb);
        }

        public async Task Delete(int id)
        {
            var part = _partsRepo.GetPart(id, CancellationToken.None);
            await _partsRepo.Remove(part);
        }

        public async Task<GetPartResponse> GetPart(int id, CancellationToken token)
        {
            var part = await _partsRepo.GetPart(id, token, IncludeFromDb.IncludeAsString(IncludeFromDb.MANUFACTURER,IncludeFromDb.BRANDS));
            var brands = await _brandsRepo.GetAllBrands(x => x.PartId == id, token);

            return new GetPartResponse()
            {
                Id = part.Id,
                Name = part.Name,
                ManufacturerName = part.Manufacturer.Name,
                ValidTill = part.ValidTill,
                IsAvailable = part.AVAILABLE_QUANTITY > 0,
                BrandNames = brands.Select(x => x.Name).ToList(),
                MadeOn = part.MadeOn,
                SerialNumber = part.SerialNumber,
                Composition = part.Composition
            };
        }

        public async Task<List<GetPartResponse>> GetParts(CancellationToken token)
        {
            var parts = await _partsRepo.GetAllParts(token,IncludeFromDb.IncludeAsString(IncludeFromDb.MANUFACTURER,IncludeFromDb.BRANDS));
            return parts.Select(x => new GetPartResponse()
            {
                Id = x.Id,
                Name = x.Name,
                MadeOn = x.MadeOn,
                ManufacturerName = x.Manufacturer.Name,
                ValidTill = x.ValidTill,
                Composition = x.Composition,
                SerialNumber = x.SerialNumber,
                IsAvailable = x.AVAILABLE_QUANTITY > 0,
                BrandNames = x.Brands.Select(x => x.Name).ToList(),

            }).ToList();
        }

        public async Task ReservePart(ReservePartRequest part)
        {
            var partDb = await _partsRepo.GetPart(part.Id, CancellationToken.None);
            partDb.TotalQuantity -= part.Quantity;
            partDb.ReservedQuantity += part.Quantity;
            await _partsRepo.Update(partDb);
        }

        public async Task Update(AddUpdatePartRequest part)
        {
            var partDb = new CarPart()
            {
                Name = part.Name,
                Composition = part.Composition,
                SerialNumber = part.SerialNumber,
                MadeOn = part.MadeOn,
                ValidTill = part.ValidTill,
                ManufacturerId = part.ManufacturerId,
                ReservedQuantity = part.ReservedQuantity,
                TotalQuantity = part.TotalQuantity,
            };
            await _partsRepo.Update(partDb);
        }
    }
}
