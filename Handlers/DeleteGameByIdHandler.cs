using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Abstractions;
using TicTacToe.Contracts;

namespace TicTacToe.Handlers
{
    public class DeleteGameByIdHandler : BaseHandler<DeleteGameByIdCommand, Unit>
    {
        public DeleteGameByIdHandler(IAppDbContext appDbContext, IMapper mapper) : base(appDbContext, mapper)
        {
        }

        public override async Task<Unit> Handle(DeleteGameByIdCommand request, CancellationToken cancellationToken)
        {
            var game = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new ArgumentException("Game not found.");

            _appDbContext.Games.Remove(game);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
