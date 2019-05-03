using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EventApplication.Models;


namespace EventApplication.Models
{
    public class ShoppingCart
    {
        private string OrderCartId;

        private const string OrderSessionKey = "OrderId";

        EventApplicationDb db = new EventApplicationDb();

        public void AddToCart(int id) {



            Order orderItem = db.Orders.SingleOrDefault(o => o.OrderId == OrderCartId && o.EventId == id);


        }


        public static ShoppingCart GetCart(HttpContextBase context) {

            ShoppingCart cart = new ShoppingCart();
            cart.OrderCartId = cart.GetCartId(context);
            return cart;


        }

        public string GetCartId(HttpContextBase context) {

            string cartId = null;

            if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
                cartId = context.User.Identity.Name;
                context.Session[OrderSessionKey] = cartId;
                return cartId;
            }
            else
            {
                return cartId;

            }


        }

        public List<Order> GetOrderItems() {

            return null;

        }


        public decimal GetOrderTotal() {

            return decimal.Zero;

        }
      
    }
}