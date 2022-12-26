using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using be.MbDevelompent.Greenmaster.Statics.Object.Organic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace be.MbDevelompent.Greenmaster.Arboretum.Models.SpecieElements;

public class MainProperties
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string MainPropertiesID { get; set; }
    
    [JsonProperty("floral_language")]
    [JsonPropertyName("floral_language")]
    public string FloralLanguage { get; set; }

    [JsonProperty("origin")]
    [JsonPropertyName("origin")]
    public string Origin { get; set; }

    [JsonProperty("production")]
    [JsonPropertyName("production")]
    public string Production { get; set; }
    
    [Required]
    [JsonProperty("category")]
    [JsonPropertyName("category")]
    public string Category { get; set; }

    [EnumDataType(enumType: typeof(PlantType))]
    [JsonProperty("type")]
    [JsonPropertyName("type")]
    public PlantType Type { get; set; } = PlantType.Bush;

    [JsonProperty("blooming")]
    [JsonPropertyName("blooming")]
    public string Blooming { get; set; }

    [JsonProperty("color")]
    [JsonPropertyName("color")]
    public string Color { get; set; }
}