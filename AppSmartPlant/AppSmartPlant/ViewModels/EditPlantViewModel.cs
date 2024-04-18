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
	public class EditPlantViewModel : BaseViewModel
	{
		#region VARIABLES
		string _Texto;
		bool _activadorAnimacionImg;
		string _tipoP;
		string _nombreP;

		public Mplanta parametrosRecibe { get; set; }
		#endregion
		#region CONSTRUCTOR
		public EditPlantViewModel(INavigation navigation, Mplanta parametrosTrae)
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
		public bool ActivadorAnimacionImgED
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
		public async Task EditPlant()
		{
			ActivadorAnimacionImgED = false;
			if (string.IsNullOrEmpty(parametrosRecibe.namePlant) || string.IsNullOrEmpty(parametrosRecibe.typePlant))
			{
				await DisplayAlert("Datos", "Por favor llena los datos solicitados", "Aceptar");
			}
			else
			{
				ActivadorAnimacionImgED = true;
			}
		}
		#endregion
		#region COMANDOS
		public ICommand EditCommand => new Command(async () => await EditPlant());

		#endregion

	}
}
