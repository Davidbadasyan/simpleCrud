namespace simpleCrud.Application.UseCases.Clients.Queries;

public class GetPaginatedClientsQuery : BaseQuery<PaginatedResult<ClientDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string Search { get; set; }
    public GetPaginatedClientsQuery(
        int pageNumber,
        int pageSize,
        string search)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Search = search;
    }

    public class GetPaginatedClientsQueryHandler : BaseQueryHandler<GetPaginatedClientsQuery>
    {
        private readonly IClientQueryRepository _clientQueryRepository;

        public GetPaginatedClientsQueryHandler(
            IMapper mapper,
            IClientQueryRepository clientQueryRepository) : base(mapper)
        {
            _clientQueryRepository = clientQueryRepository;
        }

        public override async Task<PaginatedResult<ClientDto>> Handle(GetPaginatedClientsQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientQueryRepository.GetPaginatedAsync(
                request.Search,
                request.PageNumber,
                request.PageSize);

            return Mapper.Map<PaginatedResult<ClientDto>>(clients);
        }
    }
}