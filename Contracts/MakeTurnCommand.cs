using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Contracts
{
    public class MakeTurnCommand : IRequest<GetGameByIdResponse>
    {
        public int Id { get; set; }

        [Range(0, 8)]
        public short SpaceNumber { get; set; }

        public bool IsX { get; set; }
    }
}
