using System.ComponentModel;
using be.MbDevelompent.Greenmaster.Statics.Object.Organic;

namespace be.MbDevelompent.Greenmaster.WebServices.Models.DTO;

public class SpecieDTO
{
    private string _cycle;
    private string _type;
    public int Id { get; set; }
    public string Genus { get; set; }
    public string Species { get; set; }
    public string ScientificName { get; set; }
    public string? Name { get; set; }

    public string Type
    {
        get => _type;
        set => _type = Enum.IsDefined(typeof(PlantType), value) ? value : throw new InvalidEnumArgumentException();
    }

    public string Cycle
    {
        get => _cycle;
        set => _cycle = Enum.IsDefined(typeof(Lifecycle), value) ? value : throw new InvalidEnumArgumentException();
    }
    
    public SpecieDTO() { }
    public SpecieDTO(Specie specie)
    {
        if (specie == null)
            throw new ArgumentNullException(nameof(specie));
        Id = specie.Id;
        if (string.IsNullOrEmpty(specie.Genus?.Trim()))
            throw new ArgumentException(nameof(specie.Genus));
        Genus = specie.Genus;
        if (string.IsNullOrEmpty(specie.Species?.Trim()))
            throw new ArgumentException(nameof(specie.Species));
        Species = specie.Species;
        ScientificName = $"{specie.Genus} {specie.Species}";
        Name = specie.Name;
        Type = specie.Type;
        Cycle = specie.Cycle;
    }
}