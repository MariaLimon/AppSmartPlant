using MvvmGuia.VistaModelo;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppSmartPlant.Models;
using AppSmartPlant.Views;
using static Xamarin.Essentials.Permissions;
using System.Diagnostics;

namespace AppSmartPlant.ViewModels
{
	public class PlantViewModel : BaseViewModel
	{
        #region VARIABLES
        ICommand tapCommand;
        public Mplanta parametrosRecibe { get; set; }
		#endregion
		#region CONSTRUCTOR
		public PlantViewModel(INavigation navigation, Mplanta parametrosTrae)
		{
			Navigation = navigation;
			parametrosRecibe = parametrosTrae;
            tapCommand = new Command(OnTapped);
        }
		#endregion
		#region OBJETOS
		
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


        public ICommand TapCommand
        {
            get { return tapCommand; }
        }
        void OnTapped(object s)
        {
          
            Debug.WriteLine("parameter: " + s);
        }

        #endregion
    }
}
