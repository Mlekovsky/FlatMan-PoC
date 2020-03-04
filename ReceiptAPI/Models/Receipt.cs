using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiptAPI.Models
{
    public class Receipt
    {
        public int Id { get; set; }
        public DateTime ReceiptDate { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalValue => Products.Sum(x => x.Value);

        public Receipt() => Products = new List<Product>();
    }
}
