using HahnTestAppService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Repository.Interfaces
{
    public interface IExtendedRepository
    {
        IQueryable<T> GetWithExpression<T>(Func<T,bool> expression) where T:class;
    }
}
