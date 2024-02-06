using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherForecast.ViewModels
{
    public class FirstWeatherViewModel
    {
        [JsonPropertyName("location")]
        public WeatherLocationViewModel Location { get; set; }

        [JsonPropertyName("current")]
        public CurrentWeatherViewModel Current { get; set; }
    }

    public class WeatherLocationViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        [JsonPropertyName("tz_id")]
        public string TimezoneId { get; set; }

        //[JsonPropertyName("localtime_epoch")]
        //public DateTimeOffset LocaltimeEpoch { get; set; }

        [JsonPropertyName("localtime")]
        public string Localtime { get; set; }
    }

    public class CurrentWeatherViewModel
    {
        //[JsonPropertyName("last_updated_epoch")]
        //public long LastUpdatedEpoch { get; set; }

        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("temp_c")]
        public double TemperatureCelsius { get; set; }

        [JsonPropertyName("temp_f")]
        public double TemperatureFarenheit { get; set; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; set; }

        [JsonPropertyName("condition")]
        public WeatherConditionViewModel Condition { get; set; }

        [JsonPropertyName("wind_mph")]
        public double WindMph { get; set; }

        [JsonPropertyName("wind_kph")]
        public double WindKph { get; set; }

        [JsonPropertyName("wind_degree")]
        public int WindDegree { get; set; }

        [JsonPropertyName("wind_dir")]
        public string WindDir { get; set; }

        [JsonPropertyName("pressure_mb")]
        public double PressureMb { get; set; }

        [JsonPropertyName("pressure_in")]
        public double PressureIn { get; set; }

        [JsonPropertyName("precip_mm")]
        public double PrecipMm { get; set; }

        [JsonPropertyName("precip_in")]
        public double PrecipIn { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("cloud")]
        public int Cloud { get; set; }

        [JsonPropertyName("feelslike_c")]
        public double FeelslikeCelsius { get; set; }

        [JsonPropertyName("feeslike_f")]
        public double FeelslikeFarenheit { get; set; }

        [JsonPropertyName("vis_km")]
        public double VisKm { get; set; }

        [JsonPropertyName("vis_miles")]
        public double VisMiles { get; set; }

        [JsonPropertyName("uv")]
        public double Uv { get; set; }

        [JsonPropertyName("gust_mph")]
        public double GustMph { get; set; }

        [JsonPropertyName("gust_kph")]
        public double GustKph { get; set; }

    }

    public class WeatherConditionViewModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
