using System;
using System.Collections.Generic;

namespace Talenta.Models.Dto
{
    public class CreateOrderDto
    {
        public int VendorId { get; set; }
        public DateTime Date { get; set; }

        public List<LineItemDto> Items { get; set; }
        public decimal Discount { get; set; }
    }
}