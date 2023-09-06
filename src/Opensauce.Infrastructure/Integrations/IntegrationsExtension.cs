using Microsoft.Extensions.DependencyInjection;
using Opensauce.Infrastructure.Data.MongoDb;
using Opensauce.Infrastructure.Integrations.Refit.Handlers;
using Refit;


public static class IntegrationExtension
{
    public static void AddMongoDb(this IServiceCollection services)
    {
        services.AddSingleton<IMongoConnector, MongoDBConnector>();
        services.AddSingleton<IMongoBase,MongoBase>();
    }
    public static void AddRefitClients(this IServiceCollection services)
    {
        services
        .AddRefitClient<IGitHubUserApi>()
        .ConfigureHttpClient(c=> c
        .BaseAddress = new Uri("https://api.github.com"));
       // .AddHttpMessageHandler(() => new TokenAuthHandler());
    }
}