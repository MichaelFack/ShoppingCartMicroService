using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartMicroService.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public ShoppingCart()
        {
            Basket = new List<ShoppingCartEntry>();
        }
        public List<ShoppingCartEntry> Basket { get; }
    }

    public class ShoppingCartEntry
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }

        public ShoppingCartEntry() { /* Empty! */ }
    }
}
