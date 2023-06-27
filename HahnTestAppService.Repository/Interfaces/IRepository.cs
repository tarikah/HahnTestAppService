using HahnTestAppService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Repository.Interfaces
{
    public interface IRepository:IExtendedRepository
    {
        IUnitOfWork UnitOfWork { get; }
        Task Add<T>(T entity);
        Task Update<T>(T entity);
        Task Remove<T>(T entity);


    }
}
