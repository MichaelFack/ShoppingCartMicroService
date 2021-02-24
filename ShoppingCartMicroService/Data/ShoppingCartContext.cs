using Microsoft.EntityFrameworkCore;
using ShoppingCartMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartMicroService.Data
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {

        }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }
}
