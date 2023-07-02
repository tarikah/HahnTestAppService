using HahnTestAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Services.Interfaces
{
    public interface IManufacturerService
    {
        Task<List<Manufacturer>> GetManufacturers(CancellationToken token);
    }
}
