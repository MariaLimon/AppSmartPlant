using AppSmartPlant.Views;
using DnsClient;
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
    public class SingupViewModel : BaseViewModel
    {
		#region Variables
		private string _NombreUsuario;
		private string _Email;
		private string _Contraseña;
		private string _confirmarContraseña;
		private bool _camposRellenos;
		#endregion
		public SingupViewModel(INavigation naivigation)
		{
			Navigation = naivigation;
			Registrarcommand = new Command(async () => await SingUp(), () => CamposRellenados);
		}
		#region Objetos
		public string NombreUsuario
		{
			get { return _NombreUsuario; }
			set
			{
				_NombreUsuario = value;
				OnPropertyChanged(nameof(NombreUsuario));
				VerificarCamposRellenados();
			}
		}
		public string Email
		{
			get { return _Email; }
			set
			{
				_Email = value;
				OnPropertyChanged(nameof(Email));
				VerificarCamposRellenados();
			}
		}
		public string Contraseña
		{
			get { return _Contraseña; }
			set
			{
				_Contraseña = value;
				OnPropertyChanged(nameof(Contraseña));
				VerificarCamposRellenados();
			}
		}
		public string ConfirmarContraseña
		{
			get { return _confirmarContraseña; }
			set
			{
				_confirmarContraseña = value;
				OnPropertyChanged(nameof(ConfirmarContraseña));
				VerificarCamposRellenados();
			}
		}
		public bool CamposRellenados
		{
			get { return _camposRellenos; }
			set
			{
				_camposRellenos = value;
				OnPropertyChanged(nameof(CamposRellenados));
			}
		}
		#endregion
		#region Procesos

		private void VerificarCamposRellenados()
		{
			CamposRellenados = !string.IsNullOrWhiteSpace(NombreUsuario) && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Contraseña) && !string.IsNullOrWhiteSpace(ConfirmarContraseña);
		}

		public async Task SingUp()
		{
			if (Contraseña != ConfirmarContraseña)
			{
				await Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
				return; // No permitir el registro si las contraseñas no coinciden
			}
			else
			{
				// Guardar los datos del usuario en Preferences
				Preferences.Set("Usuario", NombreUsuario);
				Preferences.Set("Contraseña", Contraseña);

				await Application.Current.MainPage.DisplayAlert("Registro", "Registro exitoso", "Aceptar");
				await Navigation.PushAsync(new SinginPage());
			}
		}
		

		#endregion


		#region Comandos
		public ICommand Registrarcommand { get; private set; }
		#endregion
	}
}

