﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlooringOrderingSystem.Model.Responses
{
    public class ProductListResponse : Response
    {
        public List<Product> Products { get; set; }
    }
}
