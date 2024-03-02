using MvvmGuia.VistaModelo;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppSmartPlant.Models;
using AppSmartPlant.Views;

namespace AppSmartPlant.ViewModels
{
	public class PlantViewModel : BaseViewModel
	{
		#region VARIABLES
		string _Texto;
		bool _ValorSwitch;
		public Mplanta parametrosRecibe { get; set; }
		#endregion
		#region CONSTRUCTOR
		public PlantViewModel(INavigation navigation, Mplanta parametrosTrae)
		{
			Navigation = navigation;
			parametrosRecibe = parametrosTrae;
		}
		#endregion
		#region OBJETOS
		public string Texto
		{
			get { return _Texto; }
			set { SetValue(ref _Texto, value); }
		}
		public bool ValorSwitch
		{
			get { return _ValorSwitch; }
			set { SetValue(ref _ValorSwitch, value); }
		}

		#endregion
		#region PROCESOS
		public async Task Editar(Mplanta parametros)
		{
			await Navigation.PushAsync(new EditPlantPage(parametros));
		}

		public async Task History()
		{
			await Navigation.PushAsync(new PlantHistoryPage());
		}

		#endregion
		#region COMANDOS
		public ICommand CommandEditPage => new Command<Mplanta>(async (p) => await Editar(p));
		public ICommand CommandHistoryPage => new Command(async () => await History());

		#endregion
	}
}
