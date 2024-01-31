namespace WeatherForecast.Pages;

public partial class SplashPage : ContentPage
{
	public SplashPage()
	{
		InitializeComponent();
        _ = LoadSplashPage();
	}

	private async Task LoadSplashPage()
	{
		await SplashCloudy.FadeTo(1, 2000);

		await Task.Delay(500);

		await SplashDayCloudy.FadeTo(1, 2000);

        await Task.Delay(500);

        await SplashSunny.FadeTo(1, 2000);

        await Task.Delay(1000);

        Location? locale = await GetCurrentLocation();

        Application.Current!.MainPage = new NavigationPage(new MainPage(locale));
    }

    private CancellationTokenSource? _cancelTokenSource;
    private bool _isCheckingLocation;

    private async Task<Location?> GetCurrentLocation()
    {
        try
        {
            _isCheckingLocation = true;

            GeolocationRequest request = new(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

            _cancelTokenSource = new CancellationTokenSource();

            Location? location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

            if (location != null)
                return location;
            else
                return null;
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            return null;
        }
        catch (FeatureNotEnabledException fneEx)
        {
            return null;
        }
        catch (PermissionException pEx)
        {
            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
            _isCheckingLocation = false;
        }
    }

    public void CancelRequest()
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }
}