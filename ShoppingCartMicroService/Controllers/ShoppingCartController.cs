using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartMicroService.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShoppingCartMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly ShoppingCart _cart;

        public ShoppingCartController(ILogger<ShoppingCartController> logger)
        {
            _logger = logger;
            _cart = new ShoppingCart();
        }

        [HttpGet]
        public ReadOnlyDictionary<Item, int> Basket()
        {
            return new ReadOnlyDictionary<Item, int>(_cart.Basket);
        }

        [HttpPost]
        public void AddItem(Item item)
        {
            _cart.Basket.Add(item, 1);
        }

        [HttpDelete]
        public bool RemoveItem(Item item)
        {
            return _cart.Basket.Remove(item);
        }

        [HttpPut]
        public bool ChangeQuantity(Item item, int quantity)
        {
            if (!_cart.Basket.ContainsKey(item)) { return false; }

            _cart.Basket[item] = quantity;
            return true;
        }
    }
}
