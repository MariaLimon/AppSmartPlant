using AppSmartPlant.Views;
using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSmartPlant.ViewModels
{
	public class SinginViewModel : BaseViewModel
	{
		#region VARIABLES

		#endregion
		#region CONSTRUCTOR
		public SinginViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
		#region OBJETOS
		
		#endregion
		#region PROCESOS
		public async Task SingIn()
		{
			Application.Current.MainPage = new AppShell();
			await Navigation.PushAsync(new HomePage());
		}

		public async Task SingUp()
		{
			await Navigation.PushAsync(new SingupPage());
		}
		


		#endregion
		#region COMANDOS
		public ICommand CommandHomePage => new Command(async () => await SingIn());
		public ICommand CommandSingUp => new Command(async () => await SingUp());

		#endregion
	}
}
