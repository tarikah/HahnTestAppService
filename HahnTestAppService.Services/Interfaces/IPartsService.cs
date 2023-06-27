using HahnTestAppService.Contracts.Request;
using HahnTestAppService.Contracts.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Services.Interfaces
{
    public interface IPartsService
    {
        Task<List<GetPartResponse>> GetParts(CancellationToken token); 
        Task<GetPartResponse> GetPart(int id, CancellationToken token); 
        Task Add(AddUpdatePartRequest part); 
        Task Delete(int id); 
        Task Update(AddUpdatePartRequest part); 
        Task ReservePart(ReservePartRequest part); 
    }
}
