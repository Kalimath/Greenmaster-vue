using be.MbDevelompent.Greenmaster.WebServices.Database;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.EntityFrameworkCore;
// ReSharper disable TooManyChainedReferences

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// services
services.AddDbContext<SpecieDb>(opt => opt.UseInMemoryDatabase("SpecieList"));
services.AddDatabaseDeveloperPageExceptionFilter();

// app
var app = builder.Build();    

var species = app.MapGroup("/species");

species.MapGet("/", GetAllSpecies);
species.MapGet("/{id}", GetSpecieWithId);
species.MapPost("/", AddSpecie);
species.MapPut("/{id}", UpdateSpecie);
species.MapDelete("/{id}", DeleteSpecie);

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

static async Task<IResult> AddSpecie(Specie specie,SpecieDb db)
{
    db.Species.Add(specie);
    await db.SaveChangesAsync();

    return Results.Created($"/species/{specie.Id}", specie);
}

static async Task<IResult> UpdateSpecie(int id, Specie inputSpecie, SpecieDb db)
{
    var specie = await db.Species.FindAsync(id);

    if (specie is null) return TypedResults.NotFound();

    specie.Name = inputSpecie.Name;
    specie.ScientificName = inputSpecie.ScientificName;

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