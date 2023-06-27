using HahnTestAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Repository.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<IEnumerable<Manufacturer>> GetAllManufacturers(CancellationToken token);
        Task<IEnumerable<Manufacturer>> GetAllManufacturers(Expression<Func<Manufacturer, bool>> filter, CancellationToken token);
        Task<Manufacturer> GetManufacturer(Expression<Func<Manufacturer, bool>> predicate, CancellationToken token);
        Task<Manufacturer> GetManufacturer(int id, CancellationToken token);
    }
}
