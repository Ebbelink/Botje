using Botje.Mtg.Api;
using Botje.Mtg.Application;
using Botje.Mtg.ScryfallClient;
using Logger.AzureTableStorage;

const string LOGGING_ACCESS_KEY_CONFIG_NAME = "SCRYFALL_BOTJE-logging-access-key-2";
const string SLACK_BOT_TOKEN_CONFIG_NAME = "SCRYFALL_BOTJE-slack-bot-token";

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
            configurationManager.GetSection("CardCachePaths").Get<string[]>())
        .AddTableStorageLogger(environment.IsDevelopment())
        .AddApplicationHandlers(configurationManager.GetValue<string>(SLACK_BOT_TOKEN_CONFIG_NAME))
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
            app.Configuration.GetValue<string>(LOGGING_ACCESS_KEY_CONFIG_NAME),
            new Uri(app.Configuration.GetValue<string>("AzureStorageAccountConfig:Url")),
            app.Configuration.GetValue<string>("AzureStorageAccountConfig:TableName"));
    }

    app.UseAuthorization();
}