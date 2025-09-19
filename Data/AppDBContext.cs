using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<ServiceOrderFood> ServiceOrderFood { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<ReservationTable> ReservationTables { get; set; }
        public DbSet<ServiceOrderFood> serviceOrderFoods { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Many-to-many via ReservationTable
            modelBuilder.Entity<ReservationTable>()
                .HasOne(rt => rt.Reservation)
                .WithMany(r => r.ReservationTables)
                .HasForeignKey(rt => rt.ReservationId);


            modelBuilder.Entity<ReservationTable>()
               .HasOne(rt => rt.Table)
               .WithMany()
               .HasForeignKey(rt => rt.TableId);



            modelBuilder.Entity<ServiceOrderFood>()
                .HasKey(sf => new { sf.ServiceOrderId, sf.FoodId });


            modelBuilder.Entity<ServiceOrderFood>()
                .HasOne(sf => sf.ServiceOrder)
                .WithMany(so => so.OrderedFoods)
                .HasForeignKey(sf => sf.ServiceOrderId);

            modelBuilder.Entity<ServiceOrderFood>()
                .HasOne(sf => sf.Food)
                .WithMany()
                .HasForeignKey(sf => sf.FoodId);


            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "Admin", LastName = "User", Email = "admin@restaurant.com", PasswordHash = "hashedpassword123", Role = "Admin" },
                new User { UserId = 2, FirstName = "John", LastName = "Doe", Email = "john@example.com", PasswordHash = "hashedpassword456", Role = "Customer" }
            );


            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, SeatAmount = 2, IsAvailable = true },
                new Table { TableId = 2, SeatAmount = 4, IsAvailable = true },
                new Table { TableId = 3, SeatAmount = 6, IsAvailable = false }
            );


            modelBuilder.Entity<Food>().HasData(
                new Food { FoodId = 1, Name = "Margherita Pizza", Price = 89, Description = "Classic cheese pizza", IsPopular = true, IsVegetarian = true, IsAvailable = true, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c8/Pizza_Margherita_stu_spivack.jpg" },
                new Food { FoodId = 2, Name = "Cheeseburger", Price = 120, Description = "Beef burger with cheese", IsPopular = true, IsVegetarian = false, IsAvailable = true, ImageUrl = "https://assets.epicurious.com/photos/5c745a108918ee7ab68daf79/master/pass/Smashburger-recipe-120219.jpg" },
                new Food { FoodId = 3, Name = "Caesar Salad", Price = 75, Description = "Fresh salad with chicken and dressing", IsPopular = false, IsVegetarian = false, IsAvailable = true, ImageUrl = "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/sbl46xzizeoysgb64buz.jpg" }
            );


            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Alice Johnson", Email = "alice@example.com", PhoneNumber = "0701234567" },
                new Customer { CustomerId = 2, Name = "Bob Smith", Email = "bob@example.com", PhoneNumber = "0709876543" }
            );


            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ReservationId = 1,
                    Customer_FK = 1,
                    status = "Confirmed",
                    BookingDate = new DateOnly(2025, 09, 15),
                    StartTime = new DateTime(2025, 09, 15, 19, 0, 0),
                    Duration = new TimeSpan(2, 0, 0),
                    AmountOfGuests = 2,
                    AmountOfTables = 1
                }
            );


            modelBuilder.Entity<ServiceOrder>().HasData(
                new ServiceOrder
                {
                    ServiceOrderId = 1,
                    Reservation_FK = 1,
                    TotalPriceAmount = 178,
                    Quantity = 2,
                    Note = "Extra cheese"
                }
            );

            modelBuilder.Entity<ReservationTable>().HasData(
               new ReservationTable { Id = 1, ReservationId = 1, TableId = 1 }
            );

            modelBuilder.Entity<ServiceOrderFood>().HasData(
                 new ServiceOrderFood { ServiceOrderId = 1, FoodId = 1, Quantity = 1, Price = 89 },
                 new ServiceOrderFood { ServiceOrderId = 1, FoodId = 2, Quantity = 1, Price = 89 }
            );

        }


    }
}
