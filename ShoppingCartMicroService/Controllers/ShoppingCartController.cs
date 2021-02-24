using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartMicroService.Data;
using ShoppingCartMicroService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShoppingCartMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly ShoppingCartContext _context;
        private readonly ShoppingCart _cart;


        public ShoppingCartController(ILogger<ShoppingCartController> logger, ShoppingCartContext context)
        {
            _logger = logger;
            _context = context;
            _cart = _context.ShoppingCart.FirstOrDefault() ?? new ShoppingCart();
        }

        [HttpGet]
        public List<ShoppingCartEntry> Basket()
        {
            return _cart.Basket;
        }

        [HttpPost]
        public bool AddItem(Item item)
        {
            ShoppingCartEntry entry = _cart.Basket.Find(entry => entry.Item == item);
            if (entry is not null) { return false; } /* Already in basket. Change quantity instead. */

            entry = new ShoppingCartEntry();
            entry.Item = item;
            entry.Quantity = 1;

            _cart.Basket.Add(entry);
            _context.SaveChanges();
            return true;
        }

        [HttpDelete]
        public bool RemoveItem(Item item)
        {
            ShoppingCartEntry entry = _cart.Basket.Find(entry => entry.Item == item);
            if (entry is null) { return false; }
            var res = _cart.Basket.Remove(entry);
            if (res) { _context.SaveChanges(); }
            return res;
        }

        [HttpPut]
        public bool ChangeQuantity(Item item, int quantity)
        {
            ShoppingCartEntry entry = _cart.Basket.Find(entry => entry.Item == item);
            if (entry is null) { return false; }

            entry.Quantity = quantity;
            _context.SaveChanges();
            return true;
        }
    }
}
