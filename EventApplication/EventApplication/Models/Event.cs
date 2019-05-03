using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EventApplication.CustomValidation;

namespace EventApplication.Models
{
    public class Event
    {

        public virtual int EventId { get; set; }

        [Display(Name = "Event Type")]
        public virtual int EventTypeId { get; set; }

        [Display(Name = "Event Type")]
        public virtual EventType EventType { get; set; }

        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        [Required(ErrorMessage = "Title cannot empty.")]
        public virtual string Title { get; set; }

        [StringLength(150, ErrorMessage = "Description cannot exceed 150 characters.")]
        public virtual string Description { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date cannot be empty")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public virtual DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date cannot be empty")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public virtual DateTime EndDate { get; set; }

        [Range(1,100, ErrorMessage ="Max Tickets allowed is 100. Minimum is 1")]
        [Display(Name = "Max Tickets")]
        public virtual int MaxTickets { get; set; }

        [Range(0,100, ErrorMessage = "At least one ticket needs to be available.")]
        [Display(Name = "Available Tickets")]
        public virtual int AvailableTickets { get; set; }

        public virtual string Organizer { get; set; }

        [Display(Name = "Organizer Contact Info")]
        public virtual string OrganizerContactInfo { get; set; }

        [Required(ErrorMessage = "City cannot be empty")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "State cannot be empty")]
        public virtual string State { get; set; }
    }
}