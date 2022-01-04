using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; }

        public List<ShoppingCartItems> Items { get; set; } = new List<ShoppingCartItems>();

        public ShoppingCart()
        {
            
        }

        public ShoppingCart(string username)
        {
            Username = username;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0.0m;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }

                return totalPrice;
            }
        }
    }
}