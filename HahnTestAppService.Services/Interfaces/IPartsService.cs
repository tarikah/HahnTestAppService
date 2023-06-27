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
        Task Add(UpdatePartRequest part); 
        Task Delete(int id); 
        Task Update(UpdatePartRequest part); 
        Task ReservePart(ReservePartRequest part); 
    }
}
