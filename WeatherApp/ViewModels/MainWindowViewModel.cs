﻿
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
		public string data;
		[ObservableProperty]
		public string img;
		GeolocationService geo = new GeolocationService();
		Location location = new Location();
		
		//Getting your current weather params by current position
		public async void CurrentWeatherParams()
		{
			location = await geo.GetCurrentLocation();
			var temp =  await ApiService.GetWeather(location.Latitude,location.Longitude);
			City = temp.city.Name;
			Data = $"Description: {temp.list[0].weather[0].Description.ToString()} Temperature: {Math.Round(temp.list[0].main.Temp-273)}ºC";
			Img = ImgUrlGenerator(temp.list[0].main.Temp - 273);
		}
		public string ImgUrlGenerator(double temperature)
		{
			if (temperature > 20) 
			{
				return "hot_no_clouds.jpg";
			}
			if (temperature >=10 &&  temperature <= 20)
			{
				return "normal_no_clouds.jpg";
			}
			else
			{
				return "cold_no_clouds.jpg";
			}
			
		}
	}
}
