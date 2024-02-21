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

		//lleva a la vista de detalles de la planta
		public async Task PlantD(Mplanta parametros)
		{
			await Navigation.PushAsync(new PlantPage(parametros));
		}

		//vista de editar de la planta
		public async Task Editar(Mplanta parametros)
		{
			await Navigation.PushAsync(new EditPlantPage(parametros));
		}

		//eliminar planta
		public async Task Eliminar(Mplanta parametros)
		{
			await DisplayAlert($"Eliminar planta {parametros.NamePlant}", $"¿Seguro que quiere eliminar la planta {parametros.NamePlant}?","Aceptar","Cancelar");
		}

		#endregion
		#region COMANDOS
		public ICommand CommandPlantPage => new Command<Mplanta>(async (p) => await PlantD(p));
		public ICommand CommandEditPage => new Command<Mplanta>(async (p) => await Editar(p));
		public ICommand CommandEliminar => new Command<Mplanta>(async (p) => await Eliminar(p));



		#endregion

		public ICommand OpenWebCommand { get; }
	}
}