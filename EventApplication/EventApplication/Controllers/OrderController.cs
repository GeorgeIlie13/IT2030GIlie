using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models;
using EventApplication.Models.ViewModels;

namespace EventApplication.Controllers
{
    public class OrderController : Controller
    {
        EventApplicationDb db = new EventApplicationDb();

        // GET: Order
        public ActionResult Index()
        {   
            OrderCart cart = OrderCart.GetOrder(this.HttpContext);

            if (cart.GetOrderCount() > 0)
            {
                OrderCartViewModel vm = new OrderCartViewModel()
                {

                    OrderItems = cart.GetOrderItems(),
                    OrderTotal = cart.GetOrderTotal()
                };

                return View(vm);

            }
            else
            {
                OrderCartViewModel vm = new OrderCartViewModel()
                {

                    OrderItems = cart.GetOrderItems(),
                    OrderTotal = cart.GetOrderTotal(),
                    Message = "No tickets ordered."
                };

                return View(vm);


            }


        }

        [Authorize]
        public ActionResult AddToOrder(int id, int NumberOfTickets)
        {
            int routeId = id;

            OrderCart cart = OrderCart.GetOrder(this.HttpContext);
            if (cart.TicketsAreAvailable(id, NumberOfTickets))
            {
                cart.AddToCart(id, NumberOfTickets);

                return RedirectToAction("/OrderSummary", new { id = routeId });
            }
            else
            {

                CheckOutViewModel vm = new CheckOutViewModel
                {
                    CheckOutEvent = db.Events.SingleOrDefault(a => a.EventId == id),
                    Message = "because your order exceeds available Tickets"

                };

                return View("CannotRegister", vm);

            }


        }

        [HttpPost]
        public ActionResult RemoveFromOrder(int id) {

            OrderCart cart = OrderCart.GetOrder(this.HttpContext);

            string eventTitle = db.Orders.SingleOrDefault(a => a.RecordId == id).EventSelected.Title;

            cart.RemoveFromCart(id);


            OrderCartRemoveViewModel vm = new OrderCartRemoveViewModel()
            {

                DeleteId = id,
                Message = "Your order for " + eventTitle + " has been cancelled.",
                Status = "Cancelled"

            };

            return Json(vm);

        }

        public ActionResult CheckOut(int id) {

            Event DesiredEvent = db.Events.Find(id);

            CheckOutViewModel vm = new CheckOutViewModel()
            {
                CheckOutEvent = DesiredEvent,
                NumberOfTickets = 0
            };

            if (DesiredEvent.StartDate < DateTime.Now)
            {
                vm.Message = "because Event registration is in the past.";
                return View("CannotRegister", vm);
            }
            else if (DesiredEvent.AvailableTickets == 0)
            {
                vm.Message = "because Event is full.";
                return View("CannotRegister", vm);

            }
            else
            {

                return View(vm);

            }

        }


        public ActionResult OrderSummary(int id){

            OrderCart cart = OrderCart.GetOrder(this.HttpContext);
            List <Order> myitems = cart.GetOrderItems();

            Order myorder = (Order) myitems.SingleOrDefault(m => m.EventId == id);

            CheckOutViewModel vm = new CheckOutViewModel()
            {

                CheckOutEvent = myorder.EventSelected,
                NumberOfTickets = myorder.NumberOfTickets,
                OrderNumber = myorder.OrderNumber

            };

            return View(vm);

        }

        public ActionResult OrderDetails(int id) {

            Order myOrder = db.Orders.Find(id);

            return View(myOrder);

        }

    }
}