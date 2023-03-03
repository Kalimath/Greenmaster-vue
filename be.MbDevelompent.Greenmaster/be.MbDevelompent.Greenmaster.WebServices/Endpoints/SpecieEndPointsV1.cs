using be.MbDevelompent.Greenmaster.WebServices.Database;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace be.MbDevelompent.Greenmaster.WebServices.Endpoints;

public static class SpecieEndPointsV1
{
    public static RouteGroupBuilder MapSpeciesApiV1(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllSpecies).WithName("GetAllSpecies").WithOpenApi();
        group.MapGet("/{id}", GetSpecieWithId).WithName("GetSpecieWithId").WithOpenApi();
        group.MapPost("/", AddSpecie).WithName("AddSpecie").Accepts<SpecieDTO>("application/json").WithOpenApi();
        group.MapPut("/{id}", UpdateSpecie).WithName("UpdateSpecie").WithOpenApi();
        group.MapDelete("/{id}", DeleteSpecie).WithName("DeleteSpecie").WithOpenApi();

        return group;
    }

    public static async Task<IResult> GetAllSpecies(SpecieDb db)
    {
        return TypedResults.Ok(await db.Species.Select(x => new SpecieDTO(x)).ToArrayAsync());
    }

    public static async Task<IResult> GetSpecieWithId(int id, SpecieDb db)
    {
        return await db.Species.FindAsync(id)
            is Specie specie
            ? Results.Ok(new SpecieDTO(specie))
            : Results.NotFound();
    }

    public static async Task<IResult> AddSpecie(SpecieDTO specieDTO, SpecieDb db)
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

    public static async Task<IResult> UpdateSpecie(int id, SpecieDTO specieDTO, SpecieDb db)
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

    public static async Task<IResult> DeleteSpecie(int id, SpecieDb db)
    {
        if (await db.Species.FindAsync(id) is Specie specie)
        {
            db.Species.Remove(specie);
            await db.SaveChangesAsync();
            return TypedResults.Ok(specie);
        }

        return TypedResults.NotFound();
    }
}