using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplicationLab06.Models
{
    public class Course : IValidatableObject
    {
        [Display(Name = "Course ID")]
        public virtual int CourseId { get; set; }

        [Required(ErrorMessage = "A Course Title is required.")]
        [Display(Name ="Course Title")]
        [StringLength(150, ErrorMessage = "A Course Title cannot be more then 150 characters.")]
        public virtual string CourseTitle { get; set; }

        [Display(Name = "Description")]
        public virtual string CourseDescription { get; set; }

        [Required(ErrorMessage = "A number of credits is required.")]
        [Display(Name ="Number Of Credits")]
        [Range(1 ,4, ErrorMessage = "Course credits must be a value between 1-4")]
        public virtual decimal CourseCredits { get; set; }

        public virtual string InstructorName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            // Validation 1 : Credits have to be between 1-4
            if(CourseCredits < 1 || CourseCredits > 4)
            {
                yield return (new ValidationResult("Credits must be between 1 and 4"));
            }


            throw new NotImplementedException();
        }
    }
}