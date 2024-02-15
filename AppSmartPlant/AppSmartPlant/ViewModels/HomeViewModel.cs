using MvvmGuia.VistaModelo;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppSmartPlant.Models;
using AppSmartPlant.Datos;

namespace AppSmartPlant.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		public HomeViewModel()
		{
			OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
		}


		#region VARIABLES
		ObservableCollection<Mplanta> _listaPlanta;
		#endregion
		#region CONSTRUCTOR
		public HomeViewModel(INavigation navigation)
		{
			Navigation = navigation;
			MostrarPlantas();
		}
		#endregion
		#region OBJETOS
		public ObservableCollection<Mplanta> ListaPlanta
		{
			get { return _listaPlanta; }
			set
			{
				SetValue(ref _listaPlanta, value);
				OnpropertyChanged();
			}

		}
		#endregion
		#region PROCESOS
		public async Task MostrarPlantas()
		{
			var funcion = new Dplant();
			ListaPlanta = await funcion.MostrarPlantas();
		}

		#endregion
		#region COMANDOS


		#endregion

		public ICommand OpenWebCommand { get; }
	}
}