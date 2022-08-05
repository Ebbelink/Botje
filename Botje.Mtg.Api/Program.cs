using Botje.Mtg.Api;
using Botje.Mtg.ScryfallClient;
using Logger.AzureTableStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

var app = builder.Build();

// Configure services
Configure(app);

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services, ConfigurationManager configurationManager, IWebHostEnvironment environment)
{
    // Add the applications secrets to the configuration
    //configurationManager.AddEnvironmentVariables("SCRYFALL_BOTJE-");
    if (!environment.IsDevelopment())
    {
        configurationManager.SetupSecrets();
    }

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
        Console.WriteLine("~~~~~~~~~~LOGGING_ACCESS_KEY~~~~~~~~~~");
        Console.WriteLine(app.Configuration.GetValue<string>("SCRYFALL_BOTJE-logging-access-key-2"));
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        app.UseTableStorageLogger(
            app.Configuration.GetValue<string>("AzureStorageAccountConfig:AccountName"),
            app.Configuration.GetValue<string>("SCRYFALL_BOTJE-logging-access-key-2"),
            new Uri(app.Configuration.GetValue<string>("AzureStorageAccountConfig:Url")),
            app.Configuration.GetValue<string>("AzureStorageAccountConfig:TableName"));
    }

    app.UseAuthorization();
}