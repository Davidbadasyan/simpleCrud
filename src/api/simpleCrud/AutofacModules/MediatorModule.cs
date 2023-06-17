namespace simpleCrud.AutofacModules;

public class MediatorModule : Autofac.Module
{
    public MediatorModule()
    {
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
            .AsImplementedInterfaces();

        builder.RegisterAssemblyTypes(typeof(CreateClientCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));

        builder.RegisterAssemblyTypes(typeof(CreateClientCommand.CreateClientCommandHandler).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<>));

        //builder.RegisterAssemblyTypes(typeof(ClientSomeFieldUpdatedDomainEventHandler).GetTypeInfo().Assembly)
        //    .AsClosedTypesOf(typeof(INotificationHandler<>));

        builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
    }
}