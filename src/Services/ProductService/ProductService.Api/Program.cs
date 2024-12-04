using Ethik.Utility.Api.Extensions;
using ProductService.Application.DependencyInjection;
using ProductService.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//controllers
builder.Services.AddControllers();

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

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();