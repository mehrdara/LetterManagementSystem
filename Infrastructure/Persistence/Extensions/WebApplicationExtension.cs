using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Data;
namespace Infrastructure.Persistence.Extensions
{
    public static class WebApplicationExtension
    {
        public static WebApplication ApplyMigrations(this WebApplication app)
        {
            Console.WriteLine("--> Starting Migration...");
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
            if (dbContext is null)
            {
                Console.WriteLine("--> Migration failed.");
                return app;
            }

            dbContext.Database.Migrate();

            Console.WriteLine("--> Migration Complete...");

            return app;
        }
    }
}