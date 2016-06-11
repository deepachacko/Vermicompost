using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VermiCompost.Data;
using VermiCompost.ViewModels.Composters;

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
        
        
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var composters = _db.Composters.Select(c => new CompostersViewModel
            {
                Name = c.Name,
                Website = c.Website,
                Products = c.CompostersProducts.Select(cp => cp.Product).ToList()
                
            });
            return Ok(composters);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
