using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplicationLab06.Models
{
    public class Enrollment
    {
        [DisplayName("Enrollment ID")]
        public virtual int EnrollmentId { get; set; }

        [DisplayName("Student ID")]
        public virtual int StudentId { get; set; }

        [DisplayName("Course ID")]
        public virtual int CourseId { get; set; }

        [Required]
        [RegularExpression(@"[A-F]$", ErrorMessage = "Valid values are A, B, C, D, E, F")]
        public virtual string Grade { get; set; }

        [DisplayName("Student Object")]
        public virtual string StudentObject { get; set; }

        [DisplayName("Course Object")]
        public virtual string CourseObject { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
        public virtual bool IsActive { get; set; }

        [Required]
        [DisplayName("Assigned Campus")]
        public virtual string AssignedCampus { get; set; }

        [Required]
        [DisplayName("Enrolled in Semester")]
        public virtual string EnrollmentSemester { get; set; }

        [Required]
        [Range(2018, Int32.MaxValue, ErrorMessage = "Cannot be before 2018")]
        public virtual int EnrollmentYear { get; set; }

        [InvalidChar("*", ErrorMessage = "Notes contains unacceptable characters!")]
        public virtual string Notes { get; set; }

    }
}