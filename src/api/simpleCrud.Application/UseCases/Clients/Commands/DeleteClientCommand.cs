namespace simpleCrud.Application.UseCases.Clients.Commands;

public class DeleteClientCommand : BaseCommand<bool>
{
    public long Id { get; set; }

    public DeleteClientCommand(long id)
    {
        Id = id;
    }

    public class DeleteClientCommandHandler : BaseCommandHandler<DeleteClientCommand>
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientCommandHandler(
            IMapper mapper,
            IClientRepository clientRepository)
            : base(mapper)
        {
            _clientRepository = clientRepository;
        }

        public override async Task<bool> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsync(request.Id);
            if (client is null)
            {
                throw new ClientDomainException($"there is no data with id {request.Id}");
            }

            await _clientRepository.DeleteByIdAsync(request.Id);

            return true;
        }
    }
}