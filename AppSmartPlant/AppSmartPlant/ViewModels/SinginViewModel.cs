using AppSmartPlant.Models;
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
		string _email;
		string _password;
		#endregion
		#region CONSTRUCTOR
		public SinginViewModel(INavigation navigation)
		{
			Navigation = navigation;
		}
		#endregion
		#region OBJETOS
		public string Email
		{
			get { return _email; }
			set { SetValue(ref _email, value); }
		}
		public string Password
		{
			get { return _password; }
			set { SetValue(ref _password, value); }
		}
		#endregion
		#region PROCESOS
		public async Task SingIn(Musuario user)
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
		public ICommand CommandHomePage => new Command<Musuario>(async (p) => await SingIn(p));
		public ICommand CommandSingUp => new Command(async () => await SingUp());

		#endregion
	}
}
