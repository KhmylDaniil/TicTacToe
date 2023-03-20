using AutoMapper;
using TicTacToe.Contracts;
using TicTacToe.Models;

namespace TicTacToe
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Game, GetGameByIdResponse>();

            CreateMap<GetGameByIdCommandGRPC, GetGameByIdCommand>();
            CreateMap<GetGameByIdResponse, GetGameByIdResponseGRPC>();
        }
    }
}
