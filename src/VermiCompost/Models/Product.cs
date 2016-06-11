using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VermiCompost.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ComposterProduct> CompostersProducts { get; set; }


    }
}
