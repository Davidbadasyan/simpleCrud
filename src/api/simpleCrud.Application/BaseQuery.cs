namespace simpleCrud.Application;

public abstract class BaseQuery<TResponse> : IRequest<TResponse>
{
    public abstract class BaseQueryHandler<TRequest> : IRequestHandler<TRequest, TResponse>
        where TRequest : BaseQuery<TResponse>
    {
        protected readonly IMapper Mapper;

        protected BaseQueryHandler(IMapper mapper)
        {
            Mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}