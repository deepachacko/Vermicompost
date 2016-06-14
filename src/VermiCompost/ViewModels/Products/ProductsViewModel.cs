using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VermiCompost.Models;

namespace VermiCompost.ViewModels.Products
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Composter> Composters { get; set; }
    }
}
