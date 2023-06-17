namespace simpleCrud.Application.UseCases.Clients.Queries;

public class GetClientByIdQuery : BaseQuery<ClientDto>
{
    public long Id { get; set; }
    public GetClientByIdQuery(long id)
    {
        Id = id;
    }

    public class GetSimpleAByIdQueryHandler : BaseQueryHandler<GetClientByIdQuery>
    {
        private readonly IClientQueryRepository _clientQueryRepository;

        public GetSimpleAByIdQueryHandler(
            IMapper mapper,
            IClientQueryRepository clientQueryRepository) : base(mapper)
        {
            _clientQueryRepository = clientQueryRepository;
        }

        public override async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var simpleA = await _clientQueryRepository.GetByIdAsync(request.Id);

            return Mapper.Map<ClientDto>(simpleA);
        }
    }
}