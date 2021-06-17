using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ExamManagement.Models
{
    [Table("Admins")]
    public class Admin : IdentityUser
    {
        public int Id { get; set; }
    }
}
