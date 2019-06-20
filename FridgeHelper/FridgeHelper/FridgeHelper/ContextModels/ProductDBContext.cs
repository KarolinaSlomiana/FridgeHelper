using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeHelper.Models;
using Microsoft.EntityFrameworkCore;

namespace FridgeHelper.ContextModels
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
