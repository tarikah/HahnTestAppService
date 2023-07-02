using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Contracts.Response
{
    public class GetDataForAddUpdateFormResponse
    {
        public GetDataForAddUpdateFormResponse()
        {
            Brands = new List<FormData>();
            PartTypes = new List<FormData>();
            Manufacturers = new List<FormData>();
            
        }
        public List<FormData> Brands { get; set; }
        public List<FormData> PartTypes { get; set; }
        public List<FormData> Manufacturers { get; set; }
    }
    public class FormData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
