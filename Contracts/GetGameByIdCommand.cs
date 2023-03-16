using MediatR;

namespace TicTacToe.Contracts
{
    public class GetGameByIdCommand : IRequest<GetGameByIdResponse>
    {
        public int Id { get; set; }
    }
}
