using Auth.JWT.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Auth.JWT.API.Configurations
{
    public static class SQLConfig
    {
        public static IServiceCollection AddSqlCongiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            return services;
        }
    }
}
