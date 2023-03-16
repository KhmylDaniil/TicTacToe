using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicTacToe.PostqreSQL;

namespace TicTacToe
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(Program));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            ConfigureDBContext(services, configuration);
        }

        private static void ConfigureDBContext(IServiceCollection services, IConfiguration configuration)
            => services.AddPostgreSql(options: configuration.Get<PostgreSqlOptions>());
    }
}
