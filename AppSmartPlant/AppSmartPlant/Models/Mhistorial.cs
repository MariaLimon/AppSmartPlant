using System;
using System.Collections.Generic;
using System.Text;

namespace AppSmartPlant.Models
{
	public class Mhistorial
	{
		public TimeZoneInfo Time { get; set; }
		public DateTime Date { get; set; }
		public double Humedad { get; set; }
		public bool Electrovalvula { get; set; }

	}
}
