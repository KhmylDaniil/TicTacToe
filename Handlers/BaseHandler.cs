using AutoMapper;
using MediatR;
using TicTacToe.Abstractions;

namespace TicTacToe.Handlers
{
    public abstract class BaseHandler<TRequest, Tout> : IRequestHandler<TRequest, Tout> where TRequest : IRequest<Tout>
    {
        protected readonly IAppDbContext _appDbContext;
        protected readonly IMapper _mapper;

        protected BaseHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public abstract Task<Tout> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
