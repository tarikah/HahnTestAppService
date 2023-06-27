using HahnTestAppService.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Services.Interfaces
{
    public interface IBrandsService
    {
        Task<List<GetBrandsRequest>> GetBrands(CancellationToken token);
        Task Add(AddUpdateBrandRequest brand);
        Task Delete(int id);
        Task Update(AddUpdateBrandRequest part);
    }
}
