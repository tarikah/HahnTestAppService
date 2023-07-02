using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
