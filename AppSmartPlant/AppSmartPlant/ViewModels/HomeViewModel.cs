using MvvmGuia.VistaModelo;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppSmartPlant.Models;
using AppSmartPlant.Datos;
using AppSmartPlant.Views;

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
		public async Task PlantD(Mplanta parametros)
		{

			await Navigation.PushAsync(new PlantPage(parametros));
		}
		public async Task Editar(Mplanta parametros)
		{

			await Navigation.PushAsync(new EditPlantPage(parametros));
		}

		#endregion
		#region COMANDOS
		public ICommand CommandPlantPage => new Command<Mplanta>(async (p) => await PlantD(p));
		public ICommand CommandEditPage => new Command<Mplanta>(async (p) => await Editar(p));



		#endregion

		public ICommand OpenWebCommand { get; }
	}
}