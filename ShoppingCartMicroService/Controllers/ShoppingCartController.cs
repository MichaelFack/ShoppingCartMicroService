using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCartMicroService.Models;
using System;

namespace ShoppingCartMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ILogger<ShoppingCartController> _logger;

        public ShoppingCartController(ILogger<ShoppingCartController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IShoppingCart Cart()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void AddItem(IItem item)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public void RemoveItem(IItem item)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void ChangeQuantity(IItem item, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
