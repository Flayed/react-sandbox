using System;

namespace Ufo.Models
{
	public class UfoIncident
	{
		public int Id { get; set; }
		public DateTime DateOccurred { get; set; }
		public string City { get; set; }
		public string CityState { get; set; }
		public string Country { get; set; }
		public string UfoShape { get; set; }
		public int DurationInSeconds { get; set; }
		public string Duration { get; set; }
		public string Description { get; set; }
		public DateTime DateReported { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}