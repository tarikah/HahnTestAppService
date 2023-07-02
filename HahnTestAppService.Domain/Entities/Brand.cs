using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PartBrand> partBrands { get; set; }


    }
}
