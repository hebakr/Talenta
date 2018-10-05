using System.Collections.Generic;
using Talenta.Models.Entities;

namespace Talenta.Models
{
    public class CreateOrderViewModel
    {
        public IList<Product> Products { get; set; }
        public List<Vendor> Vendors { get; set; }
    }
}