using Microsoft.EntityFrameworkCore;
using ResturangAPI.Models;

namespace ResturangAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<ServiceOrder> FoodOrders { get; set; }
        public DbSet<Table> Tables { get; set; }

    }
}
