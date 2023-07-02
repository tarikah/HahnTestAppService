using HahnTestAppService.Domain.Entities;
using HahnTestAppService.Repository.DB;
using HahnTestAppService.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Repository.Concretes
{
    public class BrandRepository : BaseRepository<ApplicationDbContext>, IBrandsRepository
    {
        public BrandRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Brand>> GetAllBrands(CancellationToken token)
        {
            return await DbContext.Brands.ToListAsync(token);
        }

        public async Task<IEnumerable<Brand>> GetAllBrands(Expression<Func<Brand, bool>> filter, CancellationToken token)
        {
            var parts = DbContext.Brands.Where(filter).AsQueryable();
            return await parts.ToListAsync(token);
        }

        public async Task<Brand> GetBrand(Expression<Func<Brand, bool>> predicate, CancellationToken token)
        {
            return await DbContext.Brands.FirstOrDefaultAsync(predicate, token);
        }

        public async Task<Brand> GetBrand(int id, CancellationToken token)
        {
            return await DbContext.Brands.FirstOrDefaultAsync(x => x.Id == id, token);
        }
    }
}
