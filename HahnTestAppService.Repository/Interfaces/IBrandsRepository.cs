using HahnTestAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Repository.Interfaces
{
    public interface IBrandsRepository:IRepository
    {
        Task<IEnumerable<Brand>> GetAllBrands(CancellationToken token);
        Task<IEnumerable<Brand>> GetAllBrands(Expression<Func<Brand, bool>> filter, CancellationToken token);
        Task<Brand> GetBrand(Expression<Func<Brand, bool>> predicate, CancellationToken token);
        Task<Brand> GetBrand(int id, CancellationToken token);
    }
}
