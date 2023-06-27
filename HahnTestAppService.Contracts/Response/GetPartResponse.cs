using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Contracts.Response
{
    public class GetPartResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public int SerialNumber { get; set; }
        public DateTime MadeOn { get; set; }
        public DateTime? ValidTill { get; set; }
        public string ManufacturerName { get; set; }
        public bool IsAvailable { get; set; }
        public List<string> BrandNames { get; set; }
    }
}
