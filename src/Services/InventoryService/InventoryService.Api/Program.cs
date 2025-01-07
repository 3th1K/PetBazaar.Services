using Ethik.Utility.Api.Extensions;
using InventoryService.Infrastructure.DependencyInjection;
using InventoryService.Application.DependencyInjection;
using Serilog;
using Ethik.Utility.Common.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));
LogExtensions.SetApplicationName("InventoryService.Api");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//logging
builder.Services.AddLogging();

builder.Services
    .AddApplication() //application layer
    .AddInfrastructure(); //infrastructure layer

//global exception handler
builder.Services.AddGlobalExceptionHandler();

//enforce lower case routes
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
