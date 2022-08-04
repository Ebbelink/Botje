using Botje.Mtg.ScryfallClient;
using Logger.AzureTableStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure services
Configure(app);

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services, ConfigurationManager configurationManager)
{
    // Add the application specific environment variables
    configurationManager.AddEnvironmentVariables("SCRYFALL_BOTJE-");

    services.AddControllers();
    services.AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .RegisterScryfallClient(
            new Uri(configurationManager.GetSection("ScryfallBaseAddress").Value),
            configurationManager.GetSection("CardCachePath").Value)
        .AddTableStorageLogger()
        ;
}

static void Configure(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else
    {
        app.UseTableStorageLogger(
            app.Configuration.GetValue<string>("AzureStorageAccountConfig:AccountName"),
            app.Configuration.GetValue<string>("LOGGING_ACCESS_KEY"),
            new Uri(app.Configuration.GetValue<string>("AzureStorageAccountConfig:Url")),
            app.Configuration.GetValue<string>("AzureStorageAccountConfig:TableName"));
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();
}