namespace simpleCrud.AutofacModules;

public class ApplicationModule : Autofac.Module
{
    public ApplicationModule()
    {
    }

    protected override void Load(ContainerBuilder builder)
    {
        #region repos
        builder.RegisterType<ClientRepository>()
            .As<IClientRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<ClientQueryRepository>()
            .As<IClientQueryRepository>()
            .InstancePerLifetimeScope();
        #endregion

        #region services
        #endregion
    }
}