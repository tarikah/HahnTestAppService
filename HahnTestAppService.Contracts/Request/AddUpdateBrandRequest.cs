﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnTestAppService.Contracts.Request
{
    public class AddUpdateBrandRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
