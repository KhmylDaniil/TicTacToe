using Microsoft.EntityFrameworkCore;
using TicTacToe.Models;

namespace TicTacToe.Abstractions
{
    public interface IAppDbContext
    {
        DbSet<Game> Games { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
