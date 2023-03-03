using be.MbDevelompent.Greenmaster.WebServices.Database;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.EntityFrameworkCore;
// ReSharper disable TooManyChainedReferences

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
        c.RoutePrefix = String.Empty;
    });
}
app.UseHttpsRedirection();

var species = app.MapGroup("/species");

species.MapGet("/", GetAllSpecies).WithName("GetAllSpecies").WithOpenApi();
species.MapGet("/{id}", GetSpecieWithId).WithName("GetSpecieWithId").WithOpenApi();
species.MapPost("/", AddSpecie).WithName("AddSpecie").Accepts<SpecieDTO>("application/json").WithOpenApi();
species.MapPut("/{id}", UpdateSpecie).WithName("UpdateSpecie").WithOpenApi();
species.MapDelete("/{id}", DeleteSpecie).WithName("DeleteSpecie").WithOpenApi();

static async Task<IResult> GetAllSpecies(SpecieDb db)
{
    return TypedResults.Ok(await db.Species.Select(x => new SpecieDTO(x)).ToArrayAsync());
}

static async Task<IResult> GetSpecieWithId(int id, SpecieDb db)
{
    return await db.Species.FindAsync(id)
        is Specie specie
        ? Results.Ok(new SpecieDTO(specie))
        : Results.NotFound();
}

static async Task<IResult> AddSpecie(SpecieDTO specieDTO,SpecieDb db)
{
    var specieItem = new Specie()
    {
        ScientificName = specieDTO.ScientificName,
        Name = specieDTO.Name,
        Type = specieDTO.Type,
        Cycle = specieDTO.Cycle
    };
    
    db.Species.Add(specieItem);
    await db.SaveChangesAsync();

    specieDTO = new SpecieDTO(specieItem);

    return Results.Created($"/species/{specieDTO.Id}", specieDTO);
}

static async Task<IResult> UpdateSpecie(int id, SpecieDTO specieDTO, SpecieDb db)
{
    var specie = await db.Species.FindAsync(id);

    if (specie is null) return TypedResults.NotFound();

    specie.Name = specieDTO.Name;
    specie.ScientificName = specieDTO.ScientificName;
    specie.Type = specieDTO.Type;
    specie.Cycle = specieDTO.Cycle;

    await db.SaveChangesAsync();

    return TypedResults.Ok();
}

static async Task<IResult> DeleteSpecie(int id, SpecieDb db)
{
    if (await db.Species.FindAsync(id) is Specie specie)
    {
        db.Species.Remove(specie);
        await db.SaveChangesAsync();
        return TypedResults.Ok(specie);
    }

    return TypedResults.NotFound();
}

app.Run();