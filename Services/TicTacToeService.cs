using AutoMapper;
using Grpc.Core;
using MediatR;
using TicTacToe;
using TicTacToe.Contracts;

namespace TicTacTo.Services
{
    public class TicTacToeService : Greeter.GreeterBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TicTacToeService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public override async Task<GetGameByIdResponseGRPC> GetGameById(GetGameByIdCommandGRPC request, ServerCallContext context)
        {
            var command = _mapper.Map<GetGameByIdCommand>(request);
            var response =  await _mediator.Send(command is null
                ? throw new ArgumentNullException(nameof(command))
                : command, default);

            return _mapper.Map<GetGameByIdResponseGRPC>(response);
        }
    }
}