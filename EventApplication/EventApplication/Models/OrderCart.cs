using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventApplication.Models
{
    public class OrderCart
    {
        private string OrderCartId;
        private const string CartSessionKey = "CartId";

        EventApplicationDb db = new EventApplicationDb();

        public static OrderCart GetOrder(HttpContextBase context) {

            OrderCart cart = new OrderCart();
            cart.OrderCartId = cart.GetOrderId(context);
            return cart;

        }

        public string GetOrderId(HttpContextBase context) {

            string cartId;

            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    cartId = context.User.Identity.Name;
                }
                else { 

                  
                    cartId = Guid.NewGuid().ToString();

                }

                context.Session[CartSessionKey] = cartId;
            }
            else
            {
              
                cartId = context.Session[CartSessionKey].ToString();

            }

            return cartId;

        }

        public void AddToCart(int id)
        {

            Order cartItem = db.Orders.SingleOrDefault(c => c.OrderId == OrderCartId && c.EventId == id);
           
            if (cartItem == null)
            {
                Event album = db.Events.SingleOrDefault(a => a.EventId == id);

             
                cartItem = new Order()
                {
                    OrderId = OrderCartId,
                    EventId = id, 
                    EventSelected = album,
                    NumberOfTickets = 1,
                    DateOrdered = DateTime.Now
                };

                db.Orders.Add(cartItem);

            }
            else
            {
      
                cartItem.NumberOfTickets++;

            }
            db.SaveChanges(); 

        }

        public Boolean TicketsAreAvailable(int id, int amount)
        {
            Event eventRequested = db.Events.SingleOrDefault(a => a.EventId == id);

            if (eventRequested.AvailableTickets < amount)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void AddToCart(int id, int amount)
        {

            Order cartItem = db.Orders.SingleOrDefault(c => c.OrderId == OrderCartId && c.EventId == id);

            Event chosenEvent = db.Events.SingleOrDefault(a => a.EventId == id);
            
            if (cartItem == null)
            {
                

                Random generator = new Random();
                int newOrderIdint = generator.Next(1, 999999);
                string newOrderIdString = newOrderIdint.ToString().PadLeft(6, '0');

                
                cartItem = new Order()
                {
                    OrderId = OrderCartId,
                    EventId = id, 
                    EventSelected = chosenEvent,
                    NumberOfTickets = amount,
                    DateOrdered = DateTime.Now,
                    OrderNumber = newOrderIdString,
                    OrderStatus = "Processed"
            };

                db.Orders.Add(cartItem);
                chosenEvent.AvailableTickets = chosenEvent.AvailableTickets - amount;
            }
            else
            {
                
                cartItem.NumberOfTickets = cartItem.NumberOfTickets + amount;
                cartItem.OrderStatus = "Processed";
                chosenEvent.AvailableTickets = chosenEvent.AvailableTickets - amount;
            }


            db.SaveChanges(); 

        }

        public List<Order> GetOrderItems()
        {

            

            return db.Orders.Where(cart => cart.OrderId == OrderCartId).ToList();

        }

        public decimal GetOrderTotal() {

            return Decimal.Zero;
        }

        public void RemoveFromCart(int id) {

            Order orderItem = db.Orders.SingleOrDefault(order => order.RecordId == id);
            Event removalEvent = db.Events.SingleOrDefault(e => e.EventId == orderItem.EventId);

            if (orderItem != null)
            {
                if (orderItem.NumberOfTickets > 0)
                {
                    removalEvent.AvailableTickets = removalEvent.AvailableTickets + orderItem.NumberOfTickets; //Free up tickets of cancelled order.

                    orderItem.NumberOfTickets = 0;
                    orderItem.OrderStatus = "Cancelled";

                }

                db.SaveChanges();
            }

        }

        public int GetOrderCount()
        {
            List<Order> orders = GetOrderItems();

            return orders.Count;


        }

    }
}