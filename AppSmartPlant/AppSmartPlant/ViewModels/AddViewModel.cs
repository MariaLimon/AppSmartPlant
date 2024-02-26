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
	public class AddViewModel : BaseViewModel
	{
		#region VARIABLES
		string _Texto;
		bool _activadorAnimacionImg;
		string _tipoP;
		string _nombreP;
		
		#endregion
		#region CONSTRUCTOR
		public AddViewModel(INavigation navigation)
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
		public bool ActivadorAnimacionImgAG
		{
			get { return _activadorAnimacionImg; }
			set { SetValue(ref _activadorAnimacionImg, value); }
		}
		public string TipoP
		{
			get { return _tipoP; }
			set { SetValue(ref _tipoP, value); }
		}
		public string NombreP
		{
			get { return _nombreP; }
			set { SetValue(ref _nombreP, value); }
		}
		#endregion
		#region PROCESOS
		public async Task AddPlant()
		{
			ActivadorAnimacionImgAG = false;
			if (string.IsNullOrEmpty(NombreP)|| string.IsNullOrEmpty(TipoP))
			{
				await DisplayAlert("Datos", "Por favor llena los datos solicitados", "Aceptar");
			}
			else
			{
				ActivadorAnimacionImgAG = true;
			}
		}
		
		#endregion
		#region COMANDOS
		public ICommand AddCommand => new Command(async () => await AddPlant());
		#endregion
	}
}
