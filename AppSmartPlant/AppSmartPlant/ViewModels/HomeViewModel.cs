using MvvmGuia.VistaModelo;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppSmartPlant.Models;

namespace AppSmartPlant.ViewModels
{
	public class HomeViewModel : BaseViewModel
	{
		public HomeViewModel()
		{
			Title = "Home";
			OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
		}


		#region VARIABLES
		string _Texto;
		ObservableCollection<Mplanta> _listaPlanta;
		#endregion
		#region CONSTRUCTOR
		public HomeViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
		#region OBJETOS
		public string Texto
		{
			get { return _Texto; }
			set { SetValue(ref _Texto, value); }
		}
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
		public async Task ProcesoAsyncrono()
		{
			await DisplayAlert("Titulo", "Mensaje", "Ok");
		}
		public void ProcesoSimple()
		{

		}
		#endregion
		#region COMANDOS
		public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
		public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
		#endregion

		public ICommand OpenWebCommand { get; }
	}
}