using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VermiCompost.Models;

namespace VermiCompost.Data
{
    public class SampleData2
    {
        public static void Initialize(IServiceProvider sp)
        {
            var db = sp.GetService<ApplicationDbContext>();
            db.Database.EnsureCreated();

            #region seed Composter
            if (!db.Composters.Any())
            {
                var composters = new Composter[]
                {
                    new Composter { Name="Yelm Earthworm & Castings Farm", Website="www.yelmworms.com" },
                    new Composter { Name="Seattle Tilth", Website="www.seattletilth.org" },
                    new Composter { Name="Uncle Jim's Worm Farm", Website="www.unclejimswormfarm.com" },
                    new Composter { Name="Amazon", Website="www.amazon.com" },
                    new Composter { Name="3 in 1 Worm Ranch", Website="www.3in1wormranch.com" },
                    new Composter { Name="Red Worm Composting", Website="www.redwormcomposting.com" },

                };//end of var composters

                db.Composters.AddRange(composters);
                db.SaveChanges();
            }//end of if Composters
            #endregion

            #region seed Product
            if (!db.Products.Any())
            {
                var products = new Product[]
                {
                    new Product {Name="Red Wigglers" },
                    new Product {Name="Worm Factory 360" },
                    new Product {Name="Castings & Soils" },
                    new Product {Name="Compost Tea" },
                    new Product {Name="Garden Tower" },
                    new Product {Name="Bedding" },
                    new Product {Name="Starter Kits" },
                };//end of var products

                db.Products.AddRange(products);
                db.SaveChanges();
            }//end of if Products
            #endregion

            #region seed CompostersProducts
            if (!db.CompostersProducts.Any())
            {
                var compostersProducts = new ComposterProduct[] 
                {
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Yelm Earthworm & Castings Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Red Wigglers").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Yelm Earthworm & Castings Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Castings & Soils").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Yelm Earthworm & Castings Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Compost Tea").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Seattle Tilth").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Castings & Soils").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Uncle Jim's Worm Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Red Wigglers").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Uncle Jim's Worm Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Worm Factory 360").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Uncle Jim's Worm Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Castings & Soils").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Uncle Jim's Worm Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Compost Tea").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Uncle Jim's Worm Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Garden Tower").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Uncle Jim's Worm Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Bedding").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Uncle Jim's Worm Farm").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Starter Kits").Id
                    },
                     new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Amazon").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Red Wigglers").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Amazon").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Worm Factory 360").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Amazon").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Castings & Soils").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="Amazon").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Compost Tea").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="3 in 1 Worm Ranch").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Garden Tower").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="3 in 1 Worm Ranch").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Bedding").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="3 in 1 Worm Ranch").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Compost Tea").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="3 in 1 Worm Ranch").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Red Wigglers").Id
                    },
                    new ComposterProduct
                    {
                        ComposterId =db.Composters.FirstOrDefault(c=>c.Name=="3 in 1 Worm Ranch").Id,
                        ProductId = db.Products.FirstOrDefault(p=>p.Name=="Castings & Soils").Id
                    },
                };//end of var compostersProducts
                db.CompostersProducts.AddRange(compostersProducts);
                db.SaveChanges();
            }//end of if CompostersProducts
            #endregion
        }
    }
}
