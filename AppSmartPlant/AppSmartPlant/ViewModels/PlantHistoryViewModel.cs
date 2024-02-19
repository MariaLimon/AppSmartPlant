using MvvmGuia.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppSmartPlant.ViewModels
{
    class PlantHistoryViewModel : BaseViewModel
	{
		#region VARIABLES
		string _Texto;
	#endregion
	#region CONSTRUCTOR
	public PlantHistoryViewModel(INavigation navigation)
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
	#endregion
	#region PROCESOS
	public async Task ProcesoAsyncrono()
	{
		await DisplayAlert("Titulo", "Mensaje", "Ok");
	}
	public void ProcesoSimple()
	{

	}
	#endregion
	#region COMANDOS
	public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
	public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
	#endregion
}
}