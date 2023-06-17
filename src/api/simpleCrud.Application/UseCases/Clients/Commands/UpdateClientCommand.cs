namespace simpleCrud.Application.UseCases.Clients.Commands;

public class UpdateClientCommand : BaseCommand<bool>
{
    public long Id { get; set; }
    public ClientDto Client { get; set; }

    public UpdateClientCommand(long id, ClientDto client)
    {
        Id = id;
        Client = client;
    }

    public class UpdateClientCommandHandler : BaseCommandHandler<UpdateClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        public UpdateClientCommandHandler(
            IMapper mapper,
            IClientRepository clientRepository)
            : base(mapper)
        {
            _clientRepository = clientRepository;
        }

        public override async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client is null)
            {
                throw new ClientDomainException($"there is no data with id {request.Id}");
            }

            client.Update(
                request.Client.Name,
                request.Client.EntityType,
                request.Client.DateInception,
                request.Client.DateTermination,
                request.Client.TerminationReason,
                request.Client.Email,
                request.Client.Phone,
                request.Client.IdTeam,
                new Address(
                    request.Client.Address?.Address1,
                    request.Client.Address?.Address2,
                    request.Client.Address?.City,
                    request.Client.Address?.State,
                    request.Client.Address?.ZipCode));

            return true;
        }
    }
}