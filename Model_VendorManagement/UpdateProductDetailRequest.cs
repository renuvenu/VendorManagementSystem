﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_VendorManagement
{
    public class UpdateProductDetailRequest
    {
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public string? Price { get; set; }
    }
}
