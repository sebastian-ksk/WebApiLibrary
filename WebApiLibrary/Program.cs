using WebApiLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var startup = new Startup(builder.Configuration);

startup.ConfigurationServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);


app.Run();
