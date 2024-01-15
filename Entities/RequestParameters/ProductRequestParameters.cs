﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestParameters
{
	public class ProductRequestParameters : RequestParameters
	{
        public int? CategoryId { get; set; }
        public int MinPrice { get; set; } = 0; // burada int olmasının sebebi, sqlite'da decimal tipi olmadığı için
        public int MaxPrice { get; set; } = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
    }
}
