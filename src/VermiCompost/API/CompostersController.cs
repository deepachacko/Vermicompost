using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VermiCompost.Data;
using VermiCompost.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace VermiCompost.API
{
    [Route("api/[controller]")]
    public class CompostersController : Controller
    {
        private ApplicationDbContext _db;

        public CompostersController(ApplicationDbContext db)
        {
            _db = db;
        }


        // GET: api/values Get all Composters
        [HttpGet]
        public IActionResult Get()
        {
            var composters = _db.Composters.ToList();
            return Ok(composters);
        }

        // GET api/values/5 Based on the ComposterId, get all Products sold by the Composter
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var products = _db.CompostersProducts.Where(cp => cp.ComposterId == id).Select(cp => cp.Product).ToList();
            return Ok(products);
        }

        // Custom Route because you are using the same Get Method with the same parameter Id
        [HttpGet]
        [Route("getComposter/{id}")]
        public IActionResult GetComposter(int id)
        {
            var composter = _db.Composters.Where(c => c.Id == id).FirstOrDefault();
            return Ok(composter);
        }


        // POST api/values
        //create a new Product and add to a Composter, pass the ComposterId and the name of the Product
        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody]Product product)
        {
            //create and save the product first if it is a new product
            //add product to existing composter using the junction object
            var productToSave = _db.Products.FirstOrDefault(p => p.Name == product.Name);
            if (productToSave.Id != 0)
            {
                _db.CompostersProducts.Add(new ComposterProduct
                {
                    ComposterId = id,
                    ProductId = productToSave.Id
                });
            }
            else if (productToSave== null)
            {
                _db.Products.Add(product);
                _db.CompostersProducts.Add(new ComposterProduct
                {
                    ComposterId = id,
                    ProductId = productToSave.Id
                });
            }
            _db.SaveChanges();
            return Ok();
        }


        //Create a new Composter
        [HttpPost]
        public IActionResult Post([FromBody] Composter composter)
        {
            if (composter.Id == 0)
            {
                _db.Composters.Add(composter);
                _db.SaveChanges();
            }
            else
            {
                var composterToEdit = _db.Composters.FirstOrDefault(c => c.Id == composter.Id);
                composterToEdit.Name = composter.Name;
                composterToEdit.Website = composter.Website;
                _db.SaveChanges();
            }
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 Based on the Composter Id, delete the composter and the related Products
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var composter = _db.Composters.Where(c => c.Id == id).FirstOrDefault();
            var composterWithProducts = _db.CompostersProducts.Where(cp => cp.ComposterId == id).Include(cp => cp.Product).FirstOrDefault();
            _db.CompostersProducts.Remove(composterWithProducts);
            _db.Composters.Remove(composter);// it was deleting the Products but retaining the Composter
            _db.SaveChanges();
            return Ok();
        }
    }
}

