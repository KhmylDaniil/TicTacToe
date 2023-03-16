using Microsoft.EntityFrameworkCore;
using TicTacToe.Abstractions;
using TicTacToe.Models;

namespace TicTacToe.PostqreSQL
{
    public static class Entry
    {
        public static IServiceCollection AddPostgreSql
            (this IServiceCollection services,
            PostgreSqlOptions options)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (string.IsNullOrWhiteSpace(options?.ConnectionString))
                throw new ArgumentNullException(nameof(options));

            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(options.ConnectionString));
            services.AddTransient<IAppDbContext, AppDbContext>();

            return services;
        }

        public static void MigrateDB(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

            if (dbContext == null)
                throw new ArgumentException("This should never happen, the DbContext couldn't recolve!");

            dbContext.Database.Migrate();
        }
    }
}
