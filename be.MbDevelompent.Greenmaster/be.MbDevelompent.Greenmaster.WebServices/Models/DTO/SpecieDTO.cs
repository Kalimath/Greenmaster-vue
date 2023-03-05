

namespace be.MbDevelompent.Greenmaster.WebServices.Models.DTO;

public class SpecieDTO
{
    public int Id { get; set; }
    
    //Names
    public string Genus { get; set; }
    public string Species { get; set; }
    public string ScientificName => $"{Genus} {Species}";
    public string? CommonName { get; set; }
    
    //basicData
    public string Type { get; set; }
    public string Cycle { get; set; }
    public bool IsHedgeable { get; set; } = false;
    public string Origin { get; set; } = "unknown";
    public string Description { get; set; }
    
    //Characteristics
    public string Shape { get; set; }
    public string LeafColor { get; set; } = "green";
    
    //FlowerData
    public string[] FloweringSeasons { get; set; } = {};
    public string[] FlowerColors { get; set; } = {};
    
    //Dimensions
    public int WidthMetric { get; set; }
    public int HeightMetric { get; set; }
    
    //Requirements
    public string SunLight { get; set; }
    public string Water { get; set; }
    public double MinDegrees { get; set; }
    public string MaintenanceLevel { get; set; }
    public string MaintenanceDescription { get; set; }
    
    //media
    public string ImgBase64 { get; set; }
    
    
    public SpecieDTO() { }
    public SpecieDTO(Specie specie)
    {
        if (specie == null)
            throw new ArgumentNullException(nameof(specie));
        Id = specie.Id;
        Genus = specie.Genus;
        Species = specie.Species;
        CommonName = specie.CommonName;
        Type = specie.Type;
        Cycle = specie.Cycle;
    }
}