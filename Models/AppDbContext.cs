using Microsoft.EntityFrameworkCore;
using TicTacToe.Abstractions;

namespace TicTacToe.Models
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Game> Games { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
