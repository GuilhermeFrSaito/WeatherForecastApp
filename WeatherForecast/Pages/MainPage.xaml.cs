using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherForecast.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Location? location)
        {
            InitializeComponent();

            if (location != null)
            {
                var responseFromApi = Task.Run(() => GetWeatherResponse()).Result;
                
                Console.WriteLine(responseFromApi);
            }
        }

        private static async Task<string> GetWeatherResponse()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=-22.0154%2C-47.9207"),
                Headers =
                {
                    { "X-RapidAPI-Key", " " },
                    { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
        
    }

}
