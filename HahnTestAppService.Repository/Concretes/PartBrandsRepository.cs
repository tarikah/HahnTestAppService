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
    public class PartBrandsRepository : BaseRepository<ApplicationDbContext>, IPartBrandsRepository
    {
        public PartBrandsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<PartBrand>> GetAllPBrands(CancellationToken token)
        {
           return await DbContext.PartBrands.ToListAsync(token);
        }

        public async Task<IEnumerable<PartBrand>> GetAllPBrands(Expression<Func<PartBrand, bool>> filter, CancellationToken token)
        {
            var parts = DbContext.PartBrands.Where(filter).AsQueryable();
            return await parts.ToListAsync(token);
        }

        public async Task<PartBrand> GetPBrand(Expression<Func<PartBrand, bool>> predicate, CancellationToken token)
        {
            return await DbContext.PartBrands.FirstOrDefaultAsync(predicate, token);
        }

        public async Task<PartBrand> GetPBrand(int pid,int bid, CancellationToken token)
        {
            return await DbContext.PartBrands.FirstOrDefaultAsync(x => x.PartId == pid && x.BrandId==bid, token);
        }
    }
}
