using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using be.MbDevelompent.Greenmaster.Arboretum.Models.SpecieElements;
using Newtonsoft.Json;

namespace be.MbDevelompent.Greenmaster.Arboretum.Models.Dto;

public class SpecieDto
{
    [Required]
    [MinLength(length:5)]
    [JsonProperty("pid")]
    [JsonPropertyName("pid")]
    public string PlantID { get; set; }

    [JsonProperty("basic")]
    [JsonPropertyName("basic")]
    public MainProperties MainProperties { get; set; }

    [Required]
    [MinLength(length:5)]
    [JsonProperty("display_pid")]
    [JsonPropertyName("display_pid")]
    public string DisplayPlantID { get; set; }

    [JsonProperty("maintenance")]
    [JsonPropertyName("maintenance")]
    public MaintenanceProperties Maintenance { get; set; }

    [JsonProperty("parameter")]
    [JsonPropertyName("parameter")]
    public SpecieParameters Parameters { get; set; }
    
    [MinLength(length:15)]
    [JsonProperty("image")]
    [JsonPropertyName("image")]
    public string Image { get; set; }
    
    [MinLength(length:15)]
    [JsonProperty("icon")]
    [JsonPropertyName("icon")]
    public string Icon { get; set; }
}