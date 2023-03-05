using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using be.MbDevelompent.Greenmaster.WebServices.Helpers;
using be.MbDevelompent.Greenmaster.WebServices.Models.DTO;

namespace be.MbDevelompent.Greenmaster.WebServices.Models;

public class Specie
{
    private string _cycle;
    private string _type;
    private readonly string _scientificName;
    public int Id { get; set; }
    [Required]
    public string Genus { get; set; }
    [Required]
    public string Species { get; set; }
    
    public string ScientificName => $"{Genus} {Species}";

    public string? Name { get; set; }
    [Required]
    public string Type
    {
        get => _type;
        set => _type = Enum.IsDefined(typeof(PlantType), value.Capitalise()) ? value.Capitalise() : throw new InvalidEnumArgumentException();
    }
    [Required]
    public string Cycle
    {
        get => _cycle;
        set => _cycle = Enum.IsDefined(typeof(Lifecycle), value.Capitalise()) ? value.Capitalise() : throw new InvalidEnumArgumentException();
    }


    public Specie()
    {
        
    }
    
    public Specie(SpecieDTO specieDTO)
    {
        if (specieDTO == null)
            throw new ArgumentNullException(nameof(specieDTO));
        Id = specieDTO.Id;
        if (string.IsNullOrEmpty(specieDTO.Genus?.Trim()))
            throw new ArgumentException(nameof(specieDTO.Genus));
        Genus = specieDTO.Genus.Capitalise();
        if (string.IsNullOrEmpty(specieDTO.Species?.Trim()))
            throw new ArgumentException(nameof(specieDTO.Species));
        Species = specieDTO.Species.Capitalise();
        _scientificName = $"{Genus} {Species}";
        Name = specieDTO.Name;
        _cycle = specieDTO.Cycle;
        _type = specieDTO.Type;
    }
}