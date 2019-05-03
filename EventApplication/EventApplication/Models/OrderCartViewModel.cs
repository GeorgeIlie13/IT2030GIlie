using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace EventApplication.Models.ViewModels
{
    public class OrderCartViewModel
    {
        public List<Order> OrderItems { get; set; }

        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }

        public string Message { get; set; }


    }
}