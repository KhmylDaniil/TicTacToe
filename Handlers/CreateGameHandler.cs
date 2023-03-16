using AutoMapper;
using TicTacToe.Abstractions;
using TicTacToe.Contracts;
using TicTacToe.Models;

namespace TicTacToe.Handlers
{
    public class CreateGameHandler : BaseHandler<CreateGameCommand, int>
    {
        public CreateGameHandler(IAppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
        }

        public override async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            Game game = new();

            _appDbContext.Games.Add(game);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return game.Id;
        }
    }
}
