using MediatR;

namespace TicTacToe.Contracts
{
    public class CreateGameCommand : IRequest<int>
    {
    }
}
