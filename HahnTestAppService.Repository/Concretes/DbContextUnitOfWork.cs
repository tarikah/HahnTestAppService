using Microsoft.EntityFrameworkCore;

namespace HahnTestAppService.Repository.Interfaces
{
    public class DbContextUnitOfWork : IUnitOfWork
    {
        DbContext DbContext { get; set; }
        public DbContextUnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
