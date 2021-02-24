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
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
