using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VermiCompost.Models
{
    public class Comment: AuditObj
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }

        //Need to get the UserId of the logged in user to display comments created by user for editing or deleting
        //Manually created the foreign key
        public string  UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}
