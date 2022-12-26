using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using be.MbDevelompent.Greenmaster.Arboretum.Models.SpecieElements;
using be.MbDevelompent.Greenmaster.Statics.Base;
using Newtonsoft.Json;

namespace be.MbDevelompent.Greenmaster.Arboretum.Models;

public class Specie : BaseAuditableEntity
{
    [Required]
    [MinLength(length: 5)]
    [JsonProperty("pid")]
    [JsonPropertyName("pid")]
    public string PlantID { get; set; }


    [Required]
    [MinLength(length: 5)]
    [JsonProperty("display_pid")]
    [JsonPropertyName("display_pid")]
    public string DisplayPlantID { get; set; }


    [MinLength(length: 15)]
    [JsonProperty("image")]
    [JsonPropertyName("image")]
    public string Image { get; set; }

    [MinLength(length: 15)]
    [JsonProperty("icon")]
    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    //MainProperties_FK
    public string MainPropertiesID { get; set; }
    
    [JsonProperty("basic")]
    [JsonPropertyName("basic")]
    public virtual MainProperties MainProperties { get; set; }

    //MaintenanceProperties_FK
    public string MaintenancePropertiesID { get; set; }
    
    [JsonProperty("maintenance")]
    [JsonPropertyName("maintenance")]
    public virtual MaintenanceProperties Maintenance { get; set; }

    //SpecieParametersID_FK
    public string SpecieParametersID { get; set; }
    
    [JsonProperty("parameter")]
    [JsonPropertyName("parameter")]
    public virtual SpecieParameters Parameters { get; set; }
}