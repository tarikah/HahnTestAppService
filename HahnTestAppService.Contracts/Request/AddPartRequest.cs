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
        public string ManufacturerId { get; set; }
        public int TotalQuantity { get; set; }
        public string PartTypeId { get; set; }
        public List<string> Brands { get; set; }
    }
}
