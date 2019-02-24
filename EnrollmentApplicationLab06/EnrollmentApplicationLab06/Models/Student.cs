using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplicationLab06.Models
{
    public class Student
    {
        [DisplayName("Student ID")]
        public virtual int StudentId { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50)]
        public virtual string StudentLastName { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(50)]
        public virtual string StudentFirstName { get; set; }

    }
}