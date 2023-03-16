using MediatR;

namespace TicTacToe.Contracts
{
    public class DeleteGameByIdCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
