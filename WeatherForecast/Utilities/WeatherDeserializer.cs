using WeatherForecast.ViewModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherForecast.Utilities
{
    public static class WeatherDeserializer
    {
        public static FirstWeatherViewModel Deserialize(string json)
        {
            if (!string.IsNullOrEmpty(json))
                return JsonSerializer.Deserialize<FirstWeatherViewModel>(json)!;
            else
                return new FirstWeatherViewModel();
        }
    }
}
