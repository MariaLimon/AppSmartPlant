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
	public class EditViewModel : BaseViewModel
	{
		public EditViewModel()
		{
			Title = "Edit";
			OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
		}


		#region VARIABLES
		string _Texto;
		#endregion
		#region CONSTRUCTOR
		public EditViewModel(INavigation navigation)
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
