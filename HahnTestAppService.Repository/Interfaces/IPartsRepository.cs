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
    public interface IPartsRepository:IRepository
    {
        Task<IEnumerable<CarPart>> GetAllParts(CancellationToken token,string includes = "");
        Task<IEnumerable<CarPart>> GetAllParts(Expression<Func<CarPart, bool>> filter, CancellationToken token);
        Task<CarPart> GetPart(Expression<Func<CarPart, bool>> predicate,CancellationToken token);
        Task<CarPart> GetPart(int id, CancellationToken token,string includes = "");

    }
}
