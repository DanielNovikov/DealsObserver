using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DealsObserver.Data.Repositories.Abstract;
using DealsObserver.Data.Repositories.Concrete;

namespace DealsObserver.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDealsRepository, DealsRepository>();

            services.AddDbContext<DealsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DealsDatabase")));
        }
    }
}
