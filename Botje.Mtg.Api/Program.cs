using Botje.Mtg.ScryfallClient;

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
    services.AddControllers();
    services.AddEndpointsApiExplorer()
        .AddSwaggerGen()
        // TODO: Get the uri base address from config
        .RegisterScryfallClient(new Uri(configurationManager.GetSection("ScryfallBaseAddress").Value),
            configurationManager.GetSection("CardCachePath").Value)
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

    app.UseHttpsRedirection();

    app.UseAuthorization();
}