using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talenta.Models;
using Talenta.Models.Dto;
using Talenta.Models.Entities;

namespace Talenta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new ApplicationDbContext();

            var orders = db.PurchaseOrders
                .Include(x => x.Items)
                .Include(x => x.Vendor)
                .OrderByDescending(o => o.DateTime)
                .ToList(); 

            return View(orders);
        }


        public ActionResult Reports(int? vendorId)
        {
            var db = new ApplicationDbContext();
            var model = new ReportsViewModel {Vendors = db.Vendors.OrderBy(v => v.Name).ToList()};

            if (vendorId.HasValue)
                model.PurchaseOrders = db.PurchaseOrders.Where(po => po.VendorId == vendorId.Value).ToList();

            return View(model);
        }

        public ActionResult CreateOrder()
        {
            var db = new ApplicationDbContext();
            var model = new CreateOrderViewModel
            {
                Products = db.Products.OrderBy(p => p.Title).ToList(),
                Vendors = db.Vendors.OrderBy(p => p.Name).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateOrder(CreateOrderDto input)
        {
            var order = new PurchaseOrder
            {
                DateTime = input.Date,
                VendorId = input.VendorId,
                Discount = input.Discount,
                Items = new List<LineItem>()
            };

            input.Items.ForEach(x =>
            {
                order.Items.Add(new LineItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                });
            });

            var db = new ApplicationDbContext();

            db.PurchaseOrders.Add(order);
            db.SaveChanges();
            
            return Json(new { sucess = true });
        }

    }

    public class ReportsViewModel
    {
        public List<Vendor> Vendors { get; set; }
        public IList<PurchaseOrder> PurchaseOrders { get; set; }
    }
}