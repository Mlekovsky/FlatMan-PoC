using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Models.Dtos
{
    public class ReceiptDto
    {
        public DateTime ReceiptDate { get; set; }

        public List<ProductDto> Products { get; set; }

        public decimal TotalValue
        {
            get { return Products.Sum(x => x.Value * x.Quantity); }
            set { }
        }

        //public decimal TotalValue { get; set; }

        public ReceiptDto()
        {
            Products = new List<ProductDto>();
        }
    }
}
