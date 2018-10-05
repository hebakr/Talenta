using System;
using System.Collections.Generic;
using System.Linq;

namespace Talenta.Models.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public decimal Discount { get; set; }
        public virtual List<LineItem> Items { get; set; }

        public decimal Subtotal
        {
            get
            {
                var total = Items.Sum(x => x.Quantity * x.UnitPrice);

                return total - (total * Discount / 100);
            }
        }
    }
}