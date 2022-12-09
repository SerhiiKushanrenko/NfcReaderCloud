using DAL.EF;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class Extensions
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<NfcDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("AwcDB")));

            using (var serviceScope = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<NfcDbContext>())
                {
                    context.Database.Migrate();
                }
            }

            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
        }
    }
}
