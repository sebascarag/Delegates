using Delegate.Api.Entities;
using Delegate.Api.Repositories;
using Delegate.Api.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Project services
builder.Services.AddHttpClient();

builder.Services.AddTransient<IRepository<City>, CityRepository>();
builder.Services.AddTransient<IRepository<Country>, CountryRepository>();

builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IRequestService, RequestService>();

// Add Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = nameof(Delegate.Api), Version = "v2" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", nameof(Delegate.Api));
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
