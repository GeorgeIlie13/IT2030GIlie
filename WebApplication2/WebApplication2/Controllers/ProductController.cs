using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product/

        public string Index()
        {
            return "Product/Index is displayed";
        }

        // GET: /Product/Browse/

        public string Browse()
        {
            return "Browse displayed";
        }

        //GET: /Products/Details/105

        public string Details(int id)
        {
            string message = "Details displayed for ID =" + id;

            return message;
        }

        //GET: /Products/Location?zip=44124

        public string Location(int id)
        {
            string message = "Location displayed for zip=" + id;

            return message;
        }
    }
}