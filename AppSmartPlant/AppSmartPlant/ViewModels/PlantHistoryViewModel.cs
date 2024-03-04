using AppSmartPlant.Datos;
using AppSmartPlant.Models;
using Microcharts;
using MvvmGuia.VistaModelo;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace AppSmartPlant.ViewModels
{
    class PlantHistoryViewModel : BaseViewModel
	{
		#region VARIABLES
		TimeZoneInfo _Time;
		DateTime _Date;
		double _Humedad;
		bool _Electrovalvula;
		ObservableCollection<Mhistorial> _listaHistorial;




		#endregion
		#region CONSTRUCTOR
		public PlantHistoryViewModel(INavigation navigation)
		{
			Navigation = navigation;
			MostrarHistorial();
			
		}
		#endregion
		#region OBJETOS
		public TimeZoneInfo Hora
		{
			get { return _Time; }
			set { SetValue(ref _Time, value); }
		}
		public DateTime Fecha
		{
			get { return _Date; }
			set { SetValue(ref _Date, value); }
		}
		public double Humedad
		{
			get { return _Humedad; }
			set { SetValue(ref _Humedad, value); }
		}
		public bool Electro
		{
			get { return _Electrovalvula; }
			set { SetValue(ref _Electrovalvula, value); }
		}
		public ObservableCollection<Mhistorial> ListaHistorial
		{
			get { return _listaHistorial; }
			set
			{
				SetValue(ref _listaHistorial, value);
				OnpropertyChanged();
			}

		}
		#endregion
		#region PROCESOS
		public async Task MostrarHistorial()
		{
			var funcion = new Dhistorial();
			ListaHistorial = await funcion.MostrarHistorial();
		}
		#endregion
		#region COMANDOS
		//public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
		//public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
		#endregion
	}
}