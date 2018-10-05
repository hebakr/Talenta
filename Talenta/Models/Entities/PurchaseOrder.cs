using System;

namespace Talenta.Models.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}