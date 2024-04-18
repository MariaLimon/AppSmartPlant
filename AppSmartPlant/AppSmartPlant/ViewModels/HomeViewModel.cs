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
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;

namespace AppSmartPlant.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		#region VARIABLES
		ObservableCollection<Mplanta> _listaPlanta;
		bool _ActivadorB;
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
		public bool ActivadorB
		{
			get { return _ActivadorB; }
			set { SetValue(ref _ActivadorB, value); }
		}
		#endregion
		#region PROCESOS
		public async Task<ObservableCollection<Mplanta>> MostrarPlantas()
		{
			//Uri requestUri = new Uri("https://01lvzzm2-5015.usw3.devtunnels.ms/api/Plant/Lista");
			//var client = new HttpClient();

			//try
			//{
			//	var response = await client.GetAsync(requestUri);

			//	if (response.IsSuccessStatusCode)
			//	{
			//		var json = await response.Content.ReadAsStringAsync();
			//		var plantas = JsonConvert.DeserializeObject<List<Mplanta>>(json);
			//		return plantas;
			//	}
			//	else
			//	{
			//		// Manejar el caso de error (por ejemplo, mostrar un mensaje de error)
			//		return null;
			//	}
			//}
			//catch (Exception ex)
			//{
			//	// Manejar excepciones (por ejemplo, registro de errores)
			//	return null;
			//}
			Uri RequestUri = new Uri("https://01lvzzm2-5015.usw3.devtunnels.ms/api/Plant/Lista");
			var client = new HttpClient();
			var response = await client.GetAsync(RequestUri);

			if (response.IsSuccessStatusCode)
			{
				var json = await response.Content.ReadAsStringAsync();
				var productos = JsonConvert.DeserializeObject<List<Mplanta>>(json);
				return new ObservableCollection<Mplanta>(productos);
			}
			else
			{
				// Manejo de errores
				return new ObservableCollection<Mplanta>();
			}
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
			await DisplayAlert($"Eliminar planta {parametros.namePlant}", $"¿Seguro que quiere eliminar la planta {parametros.namePlant}?","Aceptar","Cancelar");
		}

		#endregion
		#region COMANDOS
		public ICommand CommandPlantPage => new Command<Mplanta>(async (p) => await PlantD(p));
		public ICommand CommandEditPage => new Command<Mplanta>(async (p) => await Editar(p));
		public ICommand CommandEliminar => new Command<Mplanta>(async (p) => await Eliminar(p));



		#endregion

	}
}