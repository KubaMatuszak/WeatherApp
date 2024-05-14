using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services
{
	public  class GeolocationService
	{

		//getting current coordinates to use for api service
		public async Task<Location> GetCurrentLocation()
		{
			try
			{
				var request = new GeolocationRequest(GeolocationAccuracy.Medium);
				var location = await Geolocation.GetLocationAsync(request);
				return location;
			}
			catch (Exception ex)
			{
				//Added exceptions
				Console.WriteLine($"Wystąpił błąd podczas pobierania lokalizacji: {ex.Message}");
				return null;
			}
		}
	}
}
