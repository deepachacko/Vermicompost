using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VermiCompost.Models
{
    public class Blog: AuditObj
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        //Blog has a collection of Comments, Blog has a 1:M relationship with Comment
        public ICollection<Comment> Comments { get; set; }
    }
}
