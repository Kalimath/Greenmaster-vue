using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace be.MbDevelompent.Greenmaster.JsonHandler.Dto;

public class SpecieDto
{
    public class Basic
    {
        [JsonProperty("floral_language")]
        [JsonPropertyName("floral_language")]
        public string FloralLanguage { get; set; }

        [JsonProperty("origin")]
        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        [JsonProperty("production")]
        [JsonPropertyName("production")]
        public string Production { get; set; }

        [JsonProperty("category")]
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonProperty("blooming")]
        [JsonPropertyName("blooming")]
        public string Blooming { get; set; }

        [JsonProperty("color")]
        [JsonPropertyName("color")]
        public string Color { get; set; }
        
    }

    public class Maintenance
    {
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

    public class Parameter
    {
        [JsonProperty("max_light_mmol")]
        [JsonPropertyName("max_light_mmol")]
        public int MaxLightMmol { get; set; }

        [JsonProperty("min_light_mmol")]
        [JsonPropertyName("min_light_mmol")]
        public int MinLightMmol { get; set; }

        [JsonProperty("max_light_lux")]
        [JsonPropertyName("max_light_lux")]
        public int MaxLightLux { get; set; }

        [JsonProperty("min_light_lux")]
        [JsonPropertyName("min_light_lux")]
        public int MinLightLux { get; set; }

        [JsonProperty("max_temp")]
        [JsonPropertyName("max_temp")]
        public int MaxTemp { get; set; }

        [JsonProperty("min_temp")]
        [JsonPropertyName("min_temp")]
        public int MinTemp { get; set; }

        [JsonProperty("max_env_humid")]
        [JsonPropertyName("max_env_humid")]
        public int MaxEnvHumid { get; set; }

        [JsonProperty("min_env_humid")]
        [JsonPropertyName("min_env_humid")]
        public int MinEnvHumid { get; set; }

        [JsonProperty("max_soil_moist")]
        [JsonPropertyName("max_soil_moist")]
        public int MaxSoilMoist { get; set; }

        [JsonProperty("min_soil_moist")]
        [JsonPropertyName("min_soil_moist")]
        public int MinSoilMoist { get; set; }

        [JsonProperty("max_soil_ec")]
        [JsonPropertyName("max_soil_ec")]
        public int MaxSoilEc { get; set; }

        [JsonProperty("min_soil_ec")]
        [JsonPropertyName("min_soil_ec")]
        public int MinSoilEc { get; set; }
    }

    public class Root
    {
        [JsonProperty("pid")]
        [JsonPropertyName("pid")]
        public string Pid { get; set; }

        [JsonProperty("basic")]
        [JsonPropertyName("basic")]
        public Basic Basic { get; set; }

        [JsonProperty("display_pid")]
        [JsonPropertyName("display_pid")]
        public string DisplayPid { get; set; }

        [JsonProperty("maintenance")]
        [JsonPropertyName("maintenance")]
        public Maintenance Maintenance { get; set; }

        [JsonProperty("parameter")]
        [JsonPropertyName("parameter")]
        public Parameter Parameter { get; set; }

        [JsonProperty("image")]
        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}