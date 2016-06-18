using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VermiCompost.Models
{
    //These same properties are used in both Blog and Comment
    abstract public class AuditObj
    {
        public bool IsActive { get; set; }
        public DateTime TimeCreated { get; set; }
        public int Votes { get; set; }
        public int Views { get; set; }
    }
}
