using WeatherApp.Services;
using WeatherApp.ViewModels;

namespace WeatherApp;

public partial class WeatherPage : ContentPage
{
	private readonly MainWindowViewModel _viewModel;
	public WeatherPage(MainWindowViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		
		BindingContext = _viewModel;
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.CurrentWeatherParams();
		
		
	}

}

