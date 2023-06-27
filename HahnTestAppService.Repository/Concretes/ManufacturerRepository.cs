using HahnTestAppService.Domain.Entities;
using HahnTestAppService.Repository.DB;
using HahnTestAppService.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HahnTestAppService.Repository.Concretes
{
    public class ManufacturerRepository : BaseRepository<ApplicationDbContext>, IManufacturerRepository
    {
        protected ManufacturerRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork = null) : base(dbContext, unitOfWork)
        {
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturers(CancellationToken token)
        {
            return await DbContext.Manufacturers.ToListAsync(token);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturers(Expression<Func<Manufacturer, bool>> filter, CancellationToken token)
        {
            var parts = DbContext.Manufacturers.Where(filter).AsQueryable();
            return await parts.ToListAsync(token);

        }

        public async Task<Manufacturer> GetManufacturer(Expression<Func<Manufacturer, bool>> predicate, CancellationToken token)
        {
            return await DbContext.Manufacturers.FirstOrDefaultAsync(predicate, token);
        }

        public async Task<Manufacturer> GetManufacturer(int id, CancellationToken token)
        {
            return await DbContext.Manufacturers.FirstOrDefaultAsync(x => x.Id == id, token);
        }
    }
}
