using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyPlanner.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        services.Configure<MongoDbSettings>(options =>
        {
            options.ConnectionString = configuration
                .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
            options.Database = configuration
                .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
        });

        services.AddScoped<IUserRepository, UserRepository>();
       
        services.AddScoped<ICardRepository, CardRepository>();
        services.AddScoped(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));


        return services;
    }
}
}
