using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Contracts.Helpers
{
    public class IncludeFromDb
    {
        public const string MANUFACTURER = "Manufacturers";
        public const string BRANDS = "Brands";
        public static string IncludeAsString(params string[] includes)
        {
            return string.Join(",", includes);
        }
    }
}
