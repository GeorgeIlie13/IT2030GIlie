using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplicationLab06.Models
{
    public class Course
    {
        [DisplayName("Course ID")]
        public virtual int CourseId { get; set; }

        [Required]
        [DisplayName("Course Title")]
        [StringLength(150)]
        public virtual string CourseTitle { get; set; }

        [DisplayName("Description")]
        public virtual string CourseDescription { get; set; }

        [Required]
        [DisplayName("Number Of Credits")]
        [Range(typeof(decimal), "1", "4")]
        public virtual decimal CourseCredits { get; set; }
    }
}