using CommuteApp.Data.Clients;
using CommuteApp.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CommuteApp.Data
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBikeApiClient, BikeApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://beryl-gbfs-production.web.app/v2_2/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<ITrainApiClient, TrainApiClient>(client =>
            {
                client.BaseAddress = new Uri("https://api.rtt.io/api/v1/json/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
