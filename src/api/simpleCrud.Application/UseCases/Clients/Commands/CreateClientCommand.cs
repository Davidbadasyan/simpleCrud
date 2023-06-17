namespace simpleCrud.Application.UseCases.Clients.Commands;

public class CreateClientCommand : BaseCommand<bool>
{
    public ClientDto ClientCreation { get; set; }
    public CreateClientCommand(ClientDto clientCreation)
    {
        ClientCreation = clientCreation;
    }

    public class CreateClientCommandHandler : BaseCommandHandler<CreateClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientQueryRepository _clientQueryRepository;
        public CreateClientCommandHandler(
            IMapper mapper,
            IClientRepository clientRepository, IClientQueryRepository clientQueryRepository)
            : base(mapper)
        {
            _clientRepository = clientRepository;
            _clientQueryRepository = clientQueryRepository;
        }

        public override async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await Client.Create(
                _clientQueryRepository,
                request.ClientCreation.Code,
                request.ClientCreation.Name,
                request.ClientCreation.EntityType,
                request.ClientCreation.DateInception,
                request.ClientCreation.DateTermination,
                request.ClientCreation.TerminationReason,
                request.ClientCreation.Email,
                request.ClientCreation.Phone,
                request.ClientCreation.IdTeam,
                new Address(
                    request.ClientCreation.Address?.Address1,
                    request.ClientCreation.Address?.Address2,
                    request.ClientCreation.Address?.City,
                    request.ClientCreation.Address?.State,
                    request.ClientCreation.Address?.ZipCode));

            await _clientRepository.AddAsync(client);

            return true;
        }
    }
}