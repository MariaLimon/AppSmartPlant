using MvvmGuia.VistaModelo;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using AppSmartPlant.Models;
using System.Net.Http;
using System.Net;
using System.Text;
using Newtonsoft.Json;


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
			if (string.IsNullOrEmpty(NombreP) || string.IsNullOrEmpty(TipoP))
			{
				await DisplayAlert("Datos", "Por favor llena los datos solicitados", "Aceptar");
			}
			else
			{
				Mplanta mplanta = new Mplanta
				{
					namePlant = NombreP,
					typePlant = TipoP,
					usersId = "65d7c2311939f248d7a27298"
				};
				Uri RequestUri = new
					Uri("https://01lvzzm2-5015.usw3.devtunnels.ms/api/Plant/Crear");
				var client = new HttpClient();
				var json = JsonConvert.SerializeObject(mplanta);
				var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(RequestUri, contentJson);

				if (response.StatusCode == HttpStatusCode.Created)
				{
					//await DisplayAlert("Mensaje", "Resgistrado", "ok");
					ActivadorAnimacionImgAG = true;
					NombreP = "";
					TipoP = "";
				}
				else
				{
					await DisplayAlert("Mensaje", "No resgistrado", "ok");
				}
			}
			
		}

		#endregion
		#region COMANDOS
		public ICommand AddCommand => new Command(async () => await AddPlant());
		#endregion
	}
}
