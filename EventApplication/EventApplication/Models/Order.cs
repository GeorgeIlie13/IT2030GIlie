using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.Models
{
    public class Order
    {
        [Key]
        public int RecordId { get; set; }

        //Based on user's name?
        [Display(Name = "Order Id")]
        public string OrderId { get; set; }

        [Display(Name = "Order Status")]
        public string OrderStatus { get; set; }

        [Display(Name = "Event Id")]
        public int EventId { get; set; }

        [Display(Name = "Number of Tickets")]
        public int NumberOfTickets { get; set; }

        [Display(Name = "Event Selected")]
        public virtual Event EventSelected { get; set; }

        [Display(Name = "Date Ordered")]
        [DisplayFormat(DataFormatString = "{0:d}")] 
        public DateTime DateOrdered { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

    }
}