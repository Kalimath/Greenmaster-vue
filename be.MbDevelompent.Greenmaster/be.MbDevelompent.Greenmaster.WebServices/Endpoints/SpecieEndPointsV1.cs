using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using be.MbDevelompent.Greenmaster.WebServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace be.MbDevelompent.Greenmaster.WebServices.Endpoints;

public static class SpecieEndPointsV1
{
    public static RouteGroupBuilder MapSpeciesApiV1(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllSpecies).WithName("GetAllSpecies").WithOpenApi();
        group.MapGet("/{id}", GetSpecieWithId).WithName("GetSpecieWithId").WithOpenApi();
        group.MapGet("/Details/{scientificName}", GetSpecieByScientificName).WithName("GetSpecieByScientificName").WithOpenApi();
        group.MapPost("/", AddSpecie).WithName("AddSpecie").Accepts<SpecieDTO>("application/json").WithOpenApi();
        group.MapPut("/{id}", UpdateSpecie).WithName("UpdateSpecie").WithOpenApi();
        group.MapDelete("/{id}", DeleteSpecie).WithName("DeleteSpecie").WithOpenApi();

        return group;
    }

    public static async Task<IResult> GetAllSpecies(ISpecieService specieService)
    {
        return TypedResults.Ok((await specieService.GetAll()).Select(x => new SpecieDTO(x)).ToArray());
    }

    public static async Task<IResult> GetSpecieWithId(int id, ISpecieService specieService)
    {
        var specie = await specieService.Find(id);
        return specie != null ? Results.Ok(new SpecieDTO(specie)) : Results.NotFound();
    }
    
    /// <summary>
    /// GET Specie by its scientific name.
    /// </summary>
    /// <param name="scientificName">Passed in the querystring</param>
    /// <param name="specieService"></param>
    /// <returns></returns>
    public static async Task<IResult> GetSpecieByScientificName(string scientificName, ISpecieService specieService)
    {
        var specie = await specieService.Find(scientificName.TrimAndLower());
        return specie != null ? Results.Ok(new SpecieDTO(specie)) : Results.NotFound();
    }
    
    public static async Task<IResult> AddSpecie(SpecieDTO specieDTO, ISpecieService specieService)
    {
        var specieItem = new Specie(specieDTO);

        if (await specieService.ExistsWithScientificName(specieItem.ScientificName))
            return Results.Conflict($"Specie with {nameof(specieItem.ScientificName)} already exists");
        
        await specieService.Add(specieItem);
        specieDTO = new SpecieDTO(specieItem);
        return Results.Created($"/species/{specieDTO.Id}", specieDTO);
    }

    public static async Task<IResult> UpdateSpecie(int id, SpecieDTO specieDTO, ISpecieService specieService)
    {
        var specie = await specieService.Find(id);
        if (specie is null) return TypedResults.NotFound();
        var foundSpecieWithName = (await specieService.Find(specieDTO.ScientificName)); //TODO: should not return null
        if (foundSpecieWithName!=null && foundSpecieWithName.Id != id)
            return Results.Conflict($"Specie with {nameof(specieDTO.ScientificName)} already exists");

        await specieService.Update(UpdateSpecieModel(specieDTO, specie));
        return TypedResults.Ok();
    }
    
    public static async Task<IResult> DeleteSpecie(int id, ISpecieService specieService)
    {
        var specie = await specieService.Find(id);
        if (specie == null) return TypedResults.NotFound();
        
        await specieService.Remove(specie);
        return TypedResults.NoContent();
    }
    
    /// <summary>
    /// Updates the Specie object based on the SpecieDTO values
    /// </summary>
    /// <param name="specieDTO"></param>
    /// <param name="specie"></param>
    /// <returns></returns>
    private static Specie UpdateSpecieModel(SpecieDTO specieDTO, Specie specie)
    {
        specie.ScientificName = specieDTO.ScientificName;
        specie.Name = specieDTO.Name;
        specie.Cycle = specieDTO.Cycle;
        specie.Type = specieDTO.Type;
        return specie;
    }

}