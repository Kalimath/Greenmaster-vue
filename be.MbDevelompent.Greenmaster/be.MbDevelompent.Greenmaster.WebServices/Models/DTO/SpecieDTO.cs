using System.ComponentModel;
using be.MbDevelompent.Greenmaster.Statics.Object.Organic;

namespace be.MbDevelompent.Greenmaster.WebServices.Models.DTO;

public class SpecieDTO
{
    public int Id { get; set; }
    public string Genus { get; set; }
    public string Species { get; set; }
    public string ScientificName => $"{Genus} {Species}";
    public string? Name { get; set; }

    public string Type { get; set; }

    public string Cycle { get; set; }
    
    public SpecieDTO() { }
    public SpecieDTO(Specie specie)
    {
        if (specie == null)
            throw new ArgumentNullException(nameof(specie));
        Id = specie.Id;
        Genus = specie.Genus;
        Species = specie.Species;
        Name = specie.Name;
        Type = specie.Type;
        Cycle = specie.Cycle;
    }
}