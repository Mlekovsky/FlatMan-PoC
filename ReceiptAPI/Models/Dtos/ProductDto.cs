using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Models.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
