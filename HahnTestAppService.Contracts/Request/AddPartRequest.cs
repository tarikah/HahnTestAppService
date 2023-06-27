using HahnTestAppService.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Contracts.Request
{
    public class AddPartRequest
    {
        public string Name { get; set; }
        public string Composition { get; set; }
        public string SerialNumber { get; set; }
        public DateTime MadeOn { get; set; } = DateTime.Now;
        public DateTime? ValidTill { get; set; }
        public int ManufacturerId { get; set; }
        public int TotalQuantity { get; set; }
        public int PartTypeId { get; set; }
        public List<BrandModel> Brands { get; set; }
    }
}
