using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VermiCompost.Models;

namespace VermiCompost.ViewModels.Composters
{
    public class CompostersViewModel
    {
        public string Name { get; set; }
        public string Website { get; set; }
        public List<Product> Products { get; set; }
    }
}
