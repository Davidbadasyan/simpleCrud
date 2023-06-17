namespace simpleCrud.Application;

public abstract class BaseCommand<TResponse> : IRequest<TResponse>// where TResponse : IResponseDto
{
    public abstract class BaseCommandHandler<TRequest> : IRequestHandler<TRequest, TResponse>
        where TRequest : BaseCommand<TResponse>
    {
        protected readonly IMapper Mapper;
        protected BaseCommandHandler(IMapper mapper)
        {
            Mapper = mapper;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    }
}