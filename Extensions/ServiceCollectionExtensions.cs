using RestaurantAPI.Repositories.IRepositories;
using RestaurantAPI.Repositories;
using RestaurantAPI.Respositories.IRepositories;
using RestaurantAPI.Respositories;
using RestaurantAPI.Service.IService;
using RestaurantAPI.Service;

namespace RestaurantAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITableRepostory, TableRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IReservationRepository, RerservationRepository>();
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IServiceOrderService, ServiceOrderService>();
            return services;
        }
    }
}
