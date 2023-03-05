using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Models;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;

namespace be.MbDevelompent.Greenmaster.WebServices.Tests.Helpers;

public static class SpecieTestData
{
    public static readonly Specie SpecieBuxus = new()
    {
        Id = 1,
        Genus = "Buxus",
        ScientificName = "Buxus Sempervirens",
        Name = "European box",
        Type = PlantType.Bush.ToString(),
        Cycle = Lifecycle.Perennial.ToString()
    };
    public static readonly Specie SpecieBuxusSinica = new()
    {
        Id = 2,
        Genus = "Buxus",
        ScientificName = "Buxus Sinica",
        Name = "Chinese box",
        Type = PlantType.Bush.ToString(),
        Cycle = Lifecycle.Perennial.ToString()
    };
    public static readonly Specie SpecieStrelitzia = new()
    {
        Id = 3,
        Genus = "Strelitzia",
        ScientificName = "Strelitzia Reginae",
        Name = "Bird of paradise",
        Type = PlantType.Bush.ToString(),
        Cycle = Lifecycle.Perennial.ToString()
    };
    
    public static readonly SpecieDTO SpecieBuxusDTO = new()
    {
        Id = 1,
        Genus = "Buxus",
        ScientificName = "Buxus Sempervirens",
        Name = "Boxtree",
        Type = PlantType.Bush.ToString(),
        Cycle = Lifecycle.Perennial.ToString()
    };
    public static readonly SpecieDTO SpecieStrelitziaDTO = new()
    {
        Id = 3,
        Genus = "Strelitzia",
        ScientificName = "Strelitzia Reginae",
        Name = "Bird of paradise",
        Type = PlantType.Bush.ToString(),
        Cycle = Lifecycle.Perennial.ToString()
    };
}