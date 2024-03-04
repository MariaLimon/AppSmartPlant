using AppSmartPlant.Models;
using AppSmartPlant.Views;
using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppSmartPlant.ViewModels
{
	public class SinginViewModel : BaseViewModel
	{
		#region VARIABLES
		string _email;
		string _password;
		private bool _camposRellenados;
		#endregion
		#region CONSTRUCTOR
		public SinginViewModel(INavigation navigation)
		{
			Navigation = navigation;
			SingIncommand = new Command(async () => await SingIn(), () => CamposRellenados);
		}
		#endregion
		#region OBJETOS
		public string Email
		{
			get { return _email; }
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
				VerificarCamposRellenados();
			}
		}
		public string Password
		{
			get { return _password; }
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
				VerificarCamposRellenados();
			}
		}
		public bool CamposRellenados
		{
			get { return _camposRellenados; }
			set
			{
				_camposRellenados = value;
				OnPropertyChanged(nameof(CamposRellenados));
			}
		}
		#endregion
		#region PROCESOS
		private void VerificarCamposRellenados()
		{
			CamposRellenados = !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);
		}
		public async Task SingIn()
		{
			string usuarioRegistrado = Preferences.Get("Usuario", string.Empty);
			string contraseñaRegistrada = Preferences.Get("Contraseña", string.Empty);

			if (Email == usuarioRegistrado && Password == contraseñaRegistrada)
			{
				Application.Current.MainPage = new AppShell();
				await Navigation.PushAsync(new HomePage());
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar");
			}
		}

		public async Task SingUp()
		{
			await Navigation.PushAsync(new SingupPage());
		}
		


		#endregion
		#region COMANDOS
		//public ICommand CommandHomePage => new Command<Musuario>(async (p) => await SingIn(p));
		public ICommand CommandSingUp => new Command(async () => await SingUp());
		public ICommand SingIncommand { get; private set; }
		public ICommand Registrarcommand { get; private set; }

		#endregion
	}
}
