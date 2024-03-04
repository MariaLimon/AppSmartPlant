using AppSmartPlant.Datos;
using AppSmartPlant.Models;
using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSmartPlant.ViewModels
{
	public class NotificationsViewModel : BaseViewModel
	{
		#region VARIABLES
		ObservableCollection<Mnoti> _listaNotis;

		#endregion
		#region CONSTRUCTOR
		public NotificationsViewModel(INavigation navigation)
		{
			Navigation = navigation;
			MostrarNotis();
		}
		#endregion
		#region OBJETOS
		public ObservableCollection<Mnoti> ListaNotis
		{
			get { return _listaNotis; }
			set
			{
				SetValue(ref _listaNotis, value);
				OnpropertyChanged();
			}
		}

		#endregion
		#region PROCESOS
		public async Task MostrarNotis()
		{
			var funcion = new Dnoti();
			ListaNotis = await funcion.MostrarNotis();
		}
		#endregion
		#region COMANDOS

		#endregion
	}
}