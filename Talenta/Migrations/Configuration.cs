using System.Collections;
using System.Collections.Generic;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using Talenta.Models.Entities;

namespace Talenta.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Talenta.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Talenta.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var jss = new JavaScriptSerializer();

            //var productsJson =
            //    System.IO.File.ReadAllText(@"E:\2018\Talenica\Talenta\Talenta\Content\json\products.json");

            //var products = jss.Deserialize<List<Product>>(productsJson);
            //context.Products.AddRange(products);

            //var vendorsJson =
            //    System.IO.File.ReadAllText(@"E:\2018\Talenica\Talenta\Talenta\Content\json\vendors.json");



            //var vendors = jss.Deserialize<List<Vendor>>(vendorsJson);
            //context.Vendors.AddRange(vendors);

            //context.SaveChanges();


        }
    }
}
