using HahnTestAppService.Domain;
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
    public class BaseRepository<TContext> : IRepository where TContext : DbContext
    {
        public BaseRepository(TContext dbContext, IUnitOfWork unitOfWork = null)
        {
            DbContext = dbContext;
            UnitOfWork = unitOfWork ?? new DbContextUnitOfWork(dbContext);
        }


        public TContext DbContext { get; private set; }

        public IUnitOfWork UnitOfWork { get; private set; }

        public async Task Add<T>(T entity) where T : class 
        {
           DbContext.Add(entity);
        }

        public IQueryable<T> GetWithExpression<T>(Func<T,bool> expression) where T : class
        {
            return DbContext.Set<T>().Where(expression).AsQueryable();
        }

        public async Task Remove<T>(T entity) where T : class
        {
            DbContext.Remove(entity);
        }

        public async Task Update<T>(T entity) where T : class
        {
            DbContext.Update(entity);
        }
    }
}
