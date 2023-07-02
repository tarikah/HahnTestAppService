using HahnTestAppService.Domain.Entities;
using HahnTestAppService.Repository.Concretes;
using HahnTestAppService.Repository.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Repository.Interfaces
{
    public interface IPartBrandsRepository:IRepository
    {
        Task<IEnumerable<PartBrand>> GetAllPBrands(CancellationToken token);
        Task<IEnumerable<PartBrand>> GetAllPBrands(Expression<Func<PartBrand, bool>> filter, CancellationToken token);
        Task<PartBrand> GetPBrand(Expression<Func<PartBrand, bool>> predicate, CancellationToken token);
        Task<PartBrand> GetPBrand(int pid,int bid, CancellationToken token);
    }
}
