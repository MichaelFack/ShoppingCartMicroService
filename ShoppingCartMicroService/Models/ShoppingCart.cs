using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartMicroService.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Basket = new Dictionary<Item, int>();
        }
        public Dictionary<Item, int> Basket { get; }
    }
}
