using AlbaPizzaApp.Infraestructure.Abstractions;
using AlbaPizzaApp.Infraestructure.Data;
using AlbaPizzaApp.Infraestructure.Repositories;
using AlbaPizzaApp.Domain.Abstractions;
using AlbaPizzaApp.Domain.Products;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AlbaPizzaApp.Domain.Customers;
using AlbaPizzaApp.Domain.Addresses;
using AlbaPizzaApp.Domain.Orders;
using AlbaPizzaApp.Domain.OrderDetails;

namespace AlbaPizzaApp.Infraestructure;
public static class DIContainer
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AlbaPizzaDb") ?? throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<ApplicationDbContext>());
        services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

        return services;
    }
}
