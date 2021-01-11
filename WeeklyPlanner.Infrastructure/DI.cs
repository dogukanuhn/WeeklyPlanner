using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyPlanner.Application.Common.Interfaces;
using WeeklyPlanner.Domain.Repositories;
using WeeklyPlanner.Infrastructure.Repositories;

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

            services.AddStackExchangeRedisCache(action =>
            {
                action.Configuration = "localhost:6379,DefaultDatabase=1";
            });

            services.AddScoped<IDashboardRepository, DashboardRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRedisHandler, RedisHandler>();


            services.AddScoped(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));


        return services;
    }
}
}
