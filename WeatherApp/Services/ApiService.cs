using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
	public static class ApiService
	{
		//gets weather data by coordinates
		public static async Task<Root> GetWeather(double latitude, double longitude)
		{
			var HttpClient = new HttpClient();
			var url = string.Format(CultureInfo.InvariantCulture, "https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid=3d2acfd25de5e613646d92bd26e9e907", latitude, longitude);
			var response = await HttpClient.GetStringAsync(url);
			return JsonConvert.DeserializeObject<Root>(response);
		}


		//gets weather data by cityname
		public static async Task<Root> GetWeatherByCity(string cityname)
		{
			var HttpClient = new HttpClient();
			var response = await HttpClient.GetStringAsync(String.Format("api.openweathermap.org/data/2.5/forecast?q={0}&appid=3d2acfd25de5e613646d92bd26e9e907", cityname));
			return JsonConvert.DeserializeObject<Root>(response);
		}
	}
}
