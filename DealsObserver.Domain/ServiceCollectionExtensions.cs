using DealsObserver.Domain.Abstract;
using DealsObserver.Domain.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace DealsObserver.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IDealsCsvParser, DealsCsvParser>();
            services.AddTransient<IDealsService, DealsService>();
            services.AddTransient<IDealToDealDtoConverter, DealToDealDtoConverter>();
            services.AddTransient<IFormFileReader, FormFileReader>();
        }
    }
}
