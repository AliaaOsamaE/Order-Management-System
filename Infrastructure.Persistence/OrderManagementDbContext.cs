using Domain.Entities.Customers;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;

namespace Infrastructure.Persistence
{
    public class OrderManagementDbContext :DbContext
    {
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

    }
}

       