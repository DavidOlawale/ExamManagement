using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ExamManagement.Models
{
    [Table("Students")]
    public class Student : IdentityUser
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
    }
}
