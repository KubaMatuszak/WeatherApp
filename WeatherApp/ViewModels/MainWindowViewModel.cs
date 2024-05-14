
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.ViewModels
{
	public partial class MainWindowViewModel : ObservableObject
	{
		
		[ObservableProperty]
		public string city;
		[ObservableProperty]
		public string temperature;
		
		GeolocationService geo = new GeolocationService();
		Location location = new Location();
		
		//Getting your current weather params by current position
		public async void CurrentWeatherParams()
		{
			location = await geo.GetCurrentLocation();
			var temp =  await ApiService.GetWeather(location.Latitude,location.Longitude);
			City = temp.city.name;
			Temperature = Math.Round(((temp.list[0].main.temp)-273)).ToString();
			

		}
		
	}
}
