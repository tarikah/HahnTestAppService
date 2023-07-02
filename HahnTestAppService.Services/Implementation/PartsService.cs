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
        private readonly IManufacturerRepository _manufacturerRepo;

        public PartsService(IPartsRepository partsRepo, IBrandsRepository brandsRepo, IManufacturerRepository manufacturerRepo)
        {
            _partsRepo = partsRepo;
            _brandsRepo = brandsRepo;
            _manufacturerRepo = manufacturerRepo;
        }

        public async Task Add(AddPartRequest part)
        {
            var partDb = new CarPart()
            {
                Name = part.Name,
                Composition = part.Composition,
                SerialNumber = part.SerialNumber,
                MadeOn = DateTime.Now,
                ValidTill = DateTime.Now.AddYears(10),
                ManufacturerId = Convert.ToInt32(part.ManufacturerId),
                TotalQuantity = part.TotalQuantity,
                PartTypeId = Convert.ToInt32(part.PartTypeId)
            };
            await _partsRepo.Add(partDb);

            await _partsRepo.UnitOfWork.CommitAsync();

            partDb.partBrands = part.Brands.Select(x => new PartBrand() { PartId = partDb.Id, BrandId = Convert.ToInt32(x) }).ToList();
            await _partsRepo.Update(partDb);

            await _partsRepo.UnitOfWork.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var part = await _partsRepo.GetPart(id, CancellationToken.None);
            await _partsRepo.Remove(part);
            await _partsRepo.UnitOfWork.CommitAsync();
        }

        public async Task<GetDataForAddUpdateFormResponse> GetFormData()
        {
            var brands = await _brandsRepo.GetAllBrands(CancellationToken.None);
            var manufacturers = await _manufacturerRepo.GetAllManufacturers(CancellationToken.None);
            return new GetDataForAddUpdateFormResponse()
            {
                Brands = brands.Select(x => new FormData { Id = x.Id, Name = x.Name }).ToList(),
                Manufacturers = manufacturers.Select(x => new FormData { Id = x.Id, Name = x.Name }).ToList(),
            };
        }

        public async Task<GetPartResponse> GetPart(int id, CancellationToken token)
        {
            var part = await _partsRepo.GetPart(id, token);

            return new GetPartResponse()
            {
                Id = part.Id,
                Name = part.Name,
                ManufacturerName = part.Manufacturer.Name,
                ValidTill = part.ValidTill,
                IsAvailable = part.AVAILABLE_QUANTITY > 0,
                BrandNames = part.partBrands.Select(x => x.Brand.Name).ToList(),
                MadeOn = part.MadeOn,
                SerialNumber = part.SerialNumber,
                Composition = part.Composition,
                PartTypeName = part.PartType.Name,

            };
        }

        public async Task<GetPartFormResponse> GetPartForm(int id)
        {
            var part = await _partsRepo.GetPart(id, CancellationToken.None);

            return new GetPartFormResponse()
            {
                Id = part.Id,
                Name = part.Name,
                ManufacturerId = part.Manufacturer.Id,
                Brands = part.partBrands.Where(x => x.PartId == id).Select(x => x.Brand.Id).ToList(),
                SerialNumber = part.SerialNumber,
                Composition = part.Composition,
                PartTypeId = part.PartType.Id,
                TotalQuantity = part.TotalQuantity,

            };
        }

        public async Task<List<GetPartResponse>> GetParts(CancellationToken token)
        {
            var parts = await _partsRepo.GetAllParts(token);

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
                PartTypeName = x.PartType.Name,
                BrandNames = x.partBrands.Select(x => x.Brand.Name).ToList()

            }).ToList();
        }

        public async Task ReservePart(ReservePartRequest part)
        {

            var partDb = await _partsRepo.GetPart(part.Id, CancellationToken.None);

            if (part.Quantity > partDb.TotalQuantity) throw new Exception("Part not available!");

            partDb.TotalQuantity -= part.Quantity;
            partDb.ReservedQuantity += part.Quantity;
            await _partsRepo.Update(partDb);
        }

        public async Task Update(UpdatePartRequest part)
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
                PartTypeId = part.PartTypeId,
            };
            await _partsRepo.Update(partDb);

            await _partsRepo.UnitOfWork.CommitAsync();
        }
    }
}
