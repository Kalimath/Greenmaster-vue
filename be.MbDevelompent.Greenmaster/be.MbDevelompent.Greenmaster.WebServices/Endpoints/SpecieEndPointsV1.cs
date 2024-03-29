﻿using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;
using be.MbDevelompent.Greenmaster.WebServices.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace be.MbDevelompent.Greenmaster.WebServices.Endpoints;

public static class SpecieEndPointsV1
{
    public static RouteGroupBuilder MapSpeciesApiV1(this RouteGroupBuilder group)
    {
        group.MapGet("/", GetAllSpecies).WithName("GetAllSpecies").WithOpenApi();
        group.MapGet("/genus/{genus}", GetAllSpeciesWithGenus).WithName("GetAllSpeciesWithGenus").WithOpenApi();
        group.MapGet("/planttype/{plantType}", GetAllSpeciesWithType).WithName("GetAllSpeciesWithPlantType").WithOpenApi();
        group.MapGet("/{id}", GetSpecieWithId).WithName("GetSpecieWithId").WithOpenApi();
        group.MapGet("/specie/{scientificName}", GetSpecieByScientificName).WithName("GetSpecieByScientificName").WithOpenApi();
        group.MapPost("/", AddSpecie).WithName("AddSpecie").Accepts<SpecieDTO>("application/json").WithOpenApi();
        group.MapPut("/{id}", UpdateSpecie).WithName("UpdateSpecie").WithOpenApi();
        group.MapDelete("/{id}", DeleteSpecie).WithName("DeleteSpecie").WithOpenApi();

        return group;
    }

    public static async Task<IResult> GetAllSpecies(ISpecieService specieService)
    {
        return TypedResults.Ok((await specieService.GetAll()).Select(x => new SpecieDTO(x)).ToArray());
    }
    
    public static async Task<IResult> GetAllSpeciesWithGenus(string genus, ISpecieService specieService)
    {
        if (string.IsNullOrEmpty(genus?.Trim()))
            return TypedResults.BadRequest("given genus is invalid");
        var allWithGenus = (await specieService.GetAllWithGenus(genus.Capitalise()));
        return TypedResults.Ok(allWithGenus.Select(x => new SpecieDTO(x)).ToArray());
    }
    
    public static async Task<IResult> GetAllSpeciesWithType(string plantType, ISpecieService specieService)
    {
        if (string.IsNullOrEmpty(plantType?.Trim())|| !Enum.IsDefined(typeof(PlantType), plantType.Capitalise()))
            return TypedResults.BadRequest("given plantType is invalid");
        
        var plantTypeEnum = (PlantType)Enum.Parse(typeof(PlantType), plantType, true);
        var allWithType = (await specieService.GetAllWithType(plantTypeEnum));
        return TypedResults.Ok(allWithType.Select(x => new SpecieDTO(x)).ToArray());
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

        if (await specieService.SpecieExistsWith(specieItem.Genus, specieItem.Species))
            return Results.Conflict($"Specie with Scientific-name already exists");
        
        await specieService.Add(specieItem);
        specieDTO = new SpecieDTO(specieItem);
        return Results.Created($"/species/{specieDTO.Id}", specieDTO);
    }

    public static async Task<IResult> UpdateSpecie(int id, SpecieDTO specieDTO, ISpecieService specieService)
    {
        var specie = await specieService.Find(id);
        if (specie is null) return TypedResults.NotFound();
        var foundSpecieWithName = (await specieService.Find(specieDTO.ScientificName));
        if (foundSpecieWithName!=null && foundSpecieWithName.Id != id)
            return Results.Conflict($"Specie with {nameof(specieDTO.ScientificName)} already exists");

        var updatedSpecieModel = UpdateSpecieModel(specieDTO, specie);
        await specieService.Update(updatedSpecieModel);
        return TypedResults.Ok(updatedSpecieModel);
    }
    
    public static async Task<IResult> DeleteSpecie(int id, ISpecieService specieService)
    {
        var specie = await specieService.Find(id);
        if (specie == null) return TypedResults.NotFound();
        
        await specieService.Remove(specie);
        return TypedResults.NoContent();
    }
    
    /// <summary>
    /// Updates the Specie object based on the SpecieDTO values which are updatable.
    /// </summary>
    /// <param name="specieDTO"></param>
    /// <param name="specie"></param>
    /// <returns></returns>
    private static Specie UpdateSpecieModel(SpecieDTO specieDTO, Specie specie)
    {
        specie.CommonName = specieDTO.CommonName;
        specie.Cycle = specieDTO.Cycle;
        specie.Type = (PlantType)Enum.Parse(typeof(PlantType),specieDTO.Type, true);
        return specie;
    }

}