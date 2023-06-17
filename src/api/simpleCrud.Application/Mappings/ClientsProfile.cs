namespace simpleCrud.Application.Mappings;

public class ClientsProfile : Profile
{
    public ClientsProfile()
    {
        #region Domain -> DTO

        CreateMap<Client, ClientDto>()
            .IgnoreAllNonExisting();

        CreateMap<Address, AddressDto>()
            .IgnoreAllNonExisting();

        CreateMap<PaginatedResult<Client>, PaginatedResult<ClientDto>>();

        #endregion

        #region DTO -> DTO

        #endregion

        //NOTE: DO NOT MAP DTO -> DOMAIN
    }
}