using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Abstractions;
using TicTacToe.Contracts;
using TicTacToe.Logic;

namespace TicTacToe.Handlers
{
    public class GetGameByIdHandler : BaseHandler<GetGameByIdCommand, GetGameByIdResponse>
    {
        public GetGameByIdHandler(IAppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
        }

        public override async Task<GetGameByIdResponse> Handle(GetGameByIdCommand request, CancellationToken cancellationToken)
        {
            var game = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new ArgumentException("Game not found.");

            var response = _mapper.Map<GetGameByIdResponse>(game);

            response.Message = game.NextTurnMessage();

            return response;
        }
    }
}
