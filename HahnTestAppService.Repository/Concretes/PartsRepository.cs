using HahnTestAppService.Domain.Entities;
using HahnTestAppService.Repository.DB;
using HahnTestAppService.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HahnTestAppService.Repository.Concretes
{
    public class PartsRepository : BaseRepository<ApplicationDbContext>, IPartsRepository
    {
        protected PartsRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork = null) : base(dbContext, unitOfWork)
        {
        }

        public async Task<IEnumerable<CarPart>> GetAllParts(CancellationToken token,string includes = "")
        {
            return await DbContext.Parts.Include(includes).ToListAsync(token);
        }

        public async Task<IEnumerable<CarPart>> GetAllParts(Expression<Func<CarPart, bool>> filter, CancellationToken token)
        {
            var parts = DbContext.Parts.Where(filter).AsQueryable();
            return await parts.ToListAsync(token);

        }

        public async Task<CarPart> GetPart(Expression<Func<CarPart, bool>> predicate, CancellationToken token)
        {
            return await DbContext.Parts.FirstOrDefaultAsync(predicate, token);
        }

        public async Task<CarPart> GetPart(int id, CancellationToken token,string includes = "")
        {
            return await DbContext.Parts.Include(includes).FirstOrDefaultAsync(x => x.Id == id, token);
        }


    }
}
