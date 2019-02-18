using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnrollmentApplication.Models
{
    public class Course
    {
        public virtual int CourseID { get; set; }
        public virtual string Title { get; set; }
        public virtual string DescriptionUrl { get; set; }
        public virtual int Credits { get; set; }
    }
}