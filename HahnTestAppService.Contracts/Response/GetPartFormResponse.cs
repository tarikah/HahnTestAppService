using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Contracts.Response
{
    public class GetPartFormResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public string SerialNumber { get; set; }
        public int ManufacturerId { get; set; }
        public int TotalQuantity { get; set; }
        public int PartTypeId { get; set; }
        public List<int> Brands { get; set; }
    }
}
