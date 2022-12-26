using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace be.MbDevelompent.Greenmaster.Arboretum.Models.SpecieElements;

public class MaintenanceProperties
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string MaintenancePropertiesID { get; set; } = null!;

    [Required]
    [JsonProperty("size")]
    [JsonPropertyName("size")]
    public string Size { get; set; }

    [JsonProperty("soil")]
    [JsonPropertyName("soil")]
    public string Soil { get; set; }

    [JsonProperty("sunlight")]
    [JsonPropertyName("sunlight")]
    public string Sunlight { get; set; }

    [JsonProperty("watering")]
    [JsonPropertyName("watering")]
    public string Watering { get; set; }

    [JsonProperty("fertilization")]
    [JsonPropertyName("fertilization")]
    public string Fertilization { get; set; }

    [JsonProperty("pruning")]
    [JsonPropertyName("pruning")]
    public string Pruning { get; set; }
}