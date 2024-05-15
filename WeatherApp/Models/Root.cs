using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
	//model for gettin all the informations from API JSON object
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
	public class City
	{
		public string Name { get; set; }
		
	}

	public class List
	{
		public Main main { get; set; }
		public List<Weather> weather { get; set; }
	}

	public class Main
	{
		public double Temp { get; set; }
		
	}

	public class Root
	{
		public List<List> list { get; set; }
		public City city { get; set; }
	}


	public class Weather
	{

		public string Description { get; set; }
	}





}
