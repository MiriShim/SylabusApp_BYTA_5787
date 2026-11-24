using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SylabusApp
{
    internal class Student
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        [MaxLength(120) ]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^0(?:5[0-9]|[2-4]|[7-9])-?\\d{7}$") ]
        public string Phone { get; set; }

         public ICollection<Subject > Subject { get; set; }



    }
}
