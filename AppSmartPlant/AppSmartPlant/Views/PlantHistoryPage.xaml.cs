using AppSmartPlant.ViewModels;
using Microcharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using Entry = Microcharts.Entry;
using SkiaSharp;

namespace AppSmartPlant.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlantHistoryPage : ContentPage
	{
		List<Entry> entryList;
		public PlantHistoryPage ()
		{
			InitializeComponent ();
			BindingContext = new PlantHistoryViewModel(Navigation);
			entryList = new List<Entry>();
			//Cargar nuesta lista de entries;
			LoadEntries();
			//Asignar los datos dentro de los entrys a los gráficos dentro de la vista XAML
			
			linesChart.Chart = new LineChart()
			{
				Entries = entryList
			};
		}
		private void LoadEntries()
		{
			Entry e1 = new Entry(70)
			{
				Label = "Hora",
				ValueLabel = "Humedad",
				Color = SKColor.Parse("#00bcd4")
			};
			Entry e2 = new Entry(300)
			{
				Label = "B",
				ValueLabel = "300",
				Color = SKColor.Parse("#F44336")
			};
			Entry e3 = new Entry(50)
			{
				Label = "C",
				ValueLabel = "50",
				Color = SKColor.Parse("#43A047")
			};
			Entry e4 = new Entry(500)
			{
				Label = "D",
				ValueLabel = "500",
				Color = SKColor.Parse("#F9A825")
			};
			entryList.Add(e1);
			entryList.Add(e2);
			entryList.Add(e3);
			entryList.Add(e4);
		}
	}
}