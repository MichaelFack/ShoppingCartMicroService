using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartMicroService.Models
{
    /*
     * Interface of the items one can place into basket.
     */
    public class Item
    {
        public string Name { get; set; }

        public Item() { }
        public Item(string name) { this.Name = name; }
    }
}
