using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Contracts.Helpers
{
    public class IncludeFromDb
    {
        public const string MANUFACTURER = "Manufacturer";
        public const string BRANDS = "Brand";
        public const string PART_TYPE = "PartType";
        public static string IncludeAsString(params string[] includes)
        {
            return string.Join(",", includes);
        }
    }
}
