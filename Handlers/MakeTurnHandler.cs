using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Abstractions;
using TicTacToe.Contracts;
using TicTacToe.Logic;

namespace TicTacToe.Handlers
{
    public class MakeTurnHandler : BaseHandler<MakeTurnCommand, GetGameByIdResponse>
    {
        public MakeTurnHandler(IAppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
        }

        public override async Task<GetGameByIdResponse> Handle(MakeTurnCommand request, CancellationToken cancellationToken)
        {
            var game = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new ArgumentException("Game not found.");

            if (game.Board[request.SpaceNumber] != ' ')
                throw new ArgumentException("This space is already occupied.");

            if (game.NextTurnIsX() != request.IsX)
                throw new ArgumentException("It`s another player`s turn!");

            var message = game.MakeTurn(request, out bool gameOver);

            var response = _mapper.Map<GetGameByIdResponse>(game);
            response.Message = message;

            if (gameOver)
                _appDbContext.Games.Remove(game);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
