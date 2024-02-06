using WeatherForecast.Utilities;
using WeatherForecast.ViewModels;

namespace WeatherForecast.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Location? location)
        {
            InitializeComponent();

            if (location != null)
            {
                var responseFromApi = Task.Run(() => GetWeatherResponse(location.Latitude.ToString(), location.Longitude.ToString())).Result;

                FirstWeatherViewModel viewModel = WeatherDeserializer.Deserialize(responseFromApi);

                #region [Page Elements]
                LocationName.Text = viewModel.Location.Name;
                LocationRegion.Text = viewModel.Location.Region;
                LocationCountry.Text = viewModel.Location.Country;
                LocationTimezone.Text = viewModel.Location.TimezoneId;

                CurrentTempC.Text = viewModel.Current.TemperatureCelsius.ToString();
                CurrentTempF.Text = viewModel.Current.TemperatureFarenheit.ToString();
                WindKph.Text = viewModel.Current.WindKph.ToString();
                WindMph.Text = viewModel.Current.WindMph.ToString();

                FeelsLikeC.Text = viewModel.Current.FeelslikeCelsius.ToString();
                WindGustKph.Text = viewModel.Current.GustKph.ToString();
                WindDirection.Text = viewModel.Current.WindDir;
                WindDegree.Text = viewModel.Current.WindDegree.ToString();
                
                CurrentCondition.Text = viewModel.Current.Condition.Text;
                Clouds.Text = viewModel.Current.Cloud.ToString();
                Humidity.Text = viewModel.Current.Humidity.ToString();
                UVEmissions.Text = viewModel.Current.Uv.ToString();


                #endregion



                Console.WriteLine(responseFromApi);
            }
        }

        private static async Task<string> GetWeatherResponse(string latitude, string longitude)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://weatherapi-com.p.rapidapi.com/current.json?q={latitude}%2C{longitude}"),
                Headers =
                {
                    { "X-RapidAPI-Key", "a23ded86d1msh9acd0845306046fp1524e3jsne421de9c58f5" },
                    { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
                },
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
    }
}
