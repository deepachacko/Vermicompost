using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VermiCompost.Models
{
    public class ComposterProduct
    {
        public Composter Composter { get; set; }
        public int ComposterId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
