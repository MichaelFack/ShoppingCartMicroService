using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartMicroService.Models
{
    public interface IShoppingCart
    {
        int id { get; }
        Dictionary<IItem, int> Basket { get; }
    }

    class ShoppingCart : IShoppingCart
    {
        public int id => throw new NotImplementedException();

        public Dictionary<IItem, int> Basket => throw new NotImplementedException();
    }
}
