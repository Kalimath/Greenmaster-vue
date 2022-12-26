using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace be.MbDevelompent.Greenmaster.Arboretum.Models.SpecieElements;

public class SpecieParameters
{
    public class Parameter
    {
        [Range(50, 20000)]
        [JsonProperty("max_light_mmol")]
        [JsonPropertyName("max_light_mmol")]
        public int MaxLightMmol { get; set; }

        [Range(50, 10000)]
        [JsonProperty("min_light_mmol")]
        [JsonPropertyName("min_light_mmol")]
        public int MinLightMmol { get; set; }

        [Range(50, 100000)]
        [JsonProperty("max_light_lux")]
        [JsonPropertyName("max_light_lux")]
        public int MaxLightLux { get; set; }

        [Range(50, 10000)]
        [JsonProperty("min_light_lux")]
        [JsonPropertyName("min_light_lux")]
        public int MinLightLux { get; set; }

        [Range(0, 50)]
        [JsonProperty("max_temp")]
        [JsonPropertyName("max_temp")]
        public int MaxTemp { get; set; }

        [Range(-20, 50)]
        [JsonProperty("min_temp")]
        [JsonPropertyName("min_temp")]
        public int MinTemp { get; set; }

        [Range(2, 100)]
        [JsonProperty("max_env_humid")]
        [JsonPropertyName("max_env_humid")]
        public int MaxEnvHumid { get; set; }

        [Range(1, 100)]
        [JsonProperty("min_env_humid")]
        [JsonPropertyName("min_env_humid")]
        public int MinEnvHumid { get; set; }

        [Range(2, 100)]
        [JsonProperty("max_soil_moist")]
        [JsonPropertyName("max_soil_moist")]
        public int MaxSoilMoist { get; set; }

        [Range(1, 100)]
        [JsonProperty("min_soil_moist")]
        [JsonPropertyName("min_soil_moist")]
        public int MinSoilMoist { get; set; }

        [Range(2, 100000)]
        [JsonProperty("max_soil_ec")]
        [JsonPropertyName("max_soil_ec")]
        public int MaxSoilEc { get; set; }

        [Range(1, 100000)]
        [JsonProperty("min_soil_ec")]
        [JsonPropertyName("min_soil_ec")]
        public int MinSoilEc { get; set; }
    }
}