// ========================================= Add services to the container. ========================================= //
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddAutoMapper(c =>
{
    c.AddProfile(new ClientsProfile());
});

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<WritableDbContext, AppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.MigrationsAssembly(typeof(AppContext).GetTypeInfo().Assembly.GetName().Name);
        }));

builder.Services.AddDbContext<AppQueryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.MigrationsAssembly(typeof(AppQueryContext).GetTypeInfo().Assembly.GetName().Name);
        }));

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(b =>
        b.WithOrigins(builder.Configuration["WebSpaHostName"])
         .AllowAnyHeader()
         .AllowAnyMethod()
         .AllowCredentials()));
		 
builder.Host.ConfigureContainer<ContainerBuilder>(b => b
    .RegisterModule(new ApplicationModule())
    .RegisterModule(new MediatorModule()));


// ========================================= Configure the HTTP request pipeline ========================================= //
var app = builder.Build();

app.UseGlobalExceptionHandler();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();