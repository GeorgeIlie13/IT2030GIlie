using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace EventApplication.Models.ViewModels
{
    public class CheckOutViewModel
    {
        public Event CheckOutEvent { get; set; }

        [Display(Name = "Number of Tickets")]
        public int NumberOfTickets { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

        public string Message { get; set; }

    }
}