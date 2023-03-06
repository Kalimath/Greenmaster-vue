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
        Species = "Sempervirens",
        CommonName = "European box",
        Type = PlantType.Bush,
        Cycle = Lifecycle.Perennial.ToString()
    };
    public static readonly Specie SpecieBuxusSinica = new()
    {
        Id = 2,
        Genus = "Buxus",
        Species = "Sinica",
        CommonName = "Chinese box",
        Type = PlantType.Bush,
        Cycle = Lifecycle.Perennial.ToString()
    };
    public static readonly Specie SpecieStrelitzia = new()
    {
        Id = 3,
        Genus = "Strelitzia",
        Species = "Reginae",
        CommonName = "Bird of paradise",
        Type = PlantType.Bush,
        Cycle = Lifecycle.Perennial.ToString()
    };
    public static readonly Specie SpecieBirch = new()
    {
        Id = 4,
        Genus = "Betula",
        Species = "Pendula",
        CommonName = "Silver birch",
        Type = PlantType.Tree,
        Cycle = Lifecycle.Perennial.ToString()
    };
    
    public static readonly SpecieDTO SpecieBuxusDTO = new (SpecieBuxus);
    public static readonly SpecieDTO SpecieStrelitziaDTO = new(SpecieStrelitzia);
}