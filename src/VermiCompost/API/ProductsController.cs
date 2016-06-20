using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VermiCompost.Data;
using Microsoft.EntityFrameworkCore;
using VermiCompost.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace VermiCompost.API
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }


        // GET: api/values Get all Products
        [HttpGet]
        public IActionResult Get()
        {
            var products = _db.Products.ToList();
            return Ok(products);
        }

        // GET api/values/5 Based on the ProductId, get all Composters that sell this Product
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var composters = _db.CompostersProducts.Where(cp => cp.ProductId == id).Select(cp => cp.Composter).ToList();
            return Ok(composters);
        }

        // Custom Route because you are using the same Get Method with the same parameter Id
        [HttpGet]
        [Route ("getProductName/{id}")]
        public IActionResult GetProductName(int id)
        {
            var product = _db.Products.Where(p=>p.Id==id).FirstOrDefault();
            return Ok(product);
        }

        // POST api/values Update a Product
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (product.Id==0)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
            }
            else
            {
                var productToEdit = _db.Products.FirstOrDefault(p => p.Id == product.Id);
                productToEdit.Name = product.Name;
                _db.SaveChanges();
            }
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _db.Products.Where(p => p.Id == id).FirstOrDefault();
            _db.Products.Remove(product);
            _db.SaveChanges();
            return Ok();
        }
    }
}
