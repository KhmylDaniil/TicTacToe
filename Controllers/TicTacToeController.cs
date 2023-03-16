using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Contracts;

namespace TicTacToe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicTacToeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicTacToeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetGameById")]
        public async Task<GetGameByIdResponse> GetGameById([FromQuery] GetGameByIdCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command is null
                ? throw new ArgumentNullException(nameof(command))
                : command, cancellationToken);
        }

        [HttpPost("CreateGame")]
        public async Task<int> CreateGame([FromQuery] CreateGameCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command is null
                ? throw new ArgumentNullException(nameof(command))
                : command, cancellationToken);
        }

        [HttpPut("MakeTurn")]
        public async Task<GetGameByIdResponse> MakeTurn([FromQuery] MakeTurnCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command is null
                ? throw new ArgumentNullException(nameof(command))
                : command, cancellationToken);
        }

        [HttpDelete("DeleteGame")]
        public async Task<Unit> DeleteGameById([FromQuery] DeleteGameByIdCommand command, CancellationToken cancellationToken)
        {
            return await _mediator.Send(command is null
                ? throw new ArgumentNullException(nameof(command))
                : command, cancellationToken);
        }
    }
}