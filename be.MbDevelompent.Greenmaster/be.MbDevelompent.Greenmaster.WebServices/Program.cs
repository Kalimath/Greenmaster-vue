using be.MbDevelompent.Greenmaster.WebServices.Database;
using be.MbDevelompent.Greenmaster.WebServices.Endpoints;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Services;
using Microsoft.EntityFrameworkCore;
// ReSharper disable TooManyChainedReferences

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ISpecieService, SpecieService>();
builder.Services.AddTransient<DataSeeder>();
builder.Services.AddTransient<DataSeeder>();

// services
services.AddDbContext<SpecieDb>(opt => opt.UseInMemoryDatabase("SpecieList"));
services.AddDatabaseDeveloperPageExceptionFilter();

// app
var app = builder.Build();    

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Greenmaster API V1");
        c.RoutePrefix = string.Empty;
    });
    SeedData(app);
}
app.UseHttpsRedirection();
app.MapGroup("/arboretum").MapSpeciesApiV1().WithTags("Specie Endpoints");
app.Run();


//Seed Data
void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using var scope = scopedFactory?.CreateScope();
    var service = scope?.ServiceProvider.GetService<DataSeeder>();
    service?.Seed();
}