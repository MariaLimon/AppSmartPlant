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
		#region VARIABLES
		string _Texto;
		public Mplanta parametrosRecibe { get; set; }
		#endregion
		#region CONSTRUCTOR
		public EditViewModel(INavigation navigation, Mplanta parametrosTrae)
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
		
		#endregion
		#region PROCESOS
		
		#endregion
		#region COMANDOS
	
		#endregion

	}
}
