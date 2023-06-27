using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Domain.Entities
{
    public class PartBrand
    {
        public CarPart Part { get; set; }
        public int PartId { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
    }
}
