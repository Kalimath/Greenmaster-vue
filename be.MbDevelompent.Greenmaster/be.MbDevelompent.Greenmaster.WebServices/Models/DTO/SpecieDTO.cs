using System.ComponentModel;
using be.MbDevelompent.Greenmaster.Statics.Object.Organic;

namespace be.MbDevelompent.Greenmaster.WebServices.Models.DTO;

public class SpecieDTO
{
    private string _cycle;
    private string _type;
    public int Id { get; set; }
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
    public SpecieDTO(Specie specieItem)
    {
        Id = specieItem.Id;
        ScientificName = specieItem.ScientificName;
        Name = specieItem.Name;
        Type = specieItem.Type;
        Cycle = specieItem.Cycle;
    }
}