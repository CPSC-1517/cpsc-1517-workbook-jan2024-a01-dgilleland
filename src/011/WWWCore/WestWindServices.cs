using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestWindWholesale.DAL;

namespace WestWindWholesale;

public static class WestWindServices
{
    public static void WWBackendDependencies(this IServiceCollection services,
        Action<DbContextOptionsBuilder> options)
    {
        services.AddDbContext<WestWindContext>(options);

        services.AddTransient<CustomerServices>((serviceProvider) =>
        {
            var context = serviceProvider.GetService<WestWindContext>();
            return new CustomerServices(context!);
        });

        services.AddTransient<CategoryServices>((serviceProvider) =>
        {
            var context = serviceProvider.GetService<WestWindContext>();
            return new CategoryServices(context!);
        });

        services.AddTransient<SupplierServices>((serviceProvider) =>
        {
            var context = serviceProvider.GetService<WestWindContext>();
            return new SupplierServices(context!);
        });

        services.AddTransient<ProductServices>((serviceProvider) =>
        {
            var context = serviceProvider.GetService<WestWindContext>();
            return new ProductServices(context!);
        });
    }
}
