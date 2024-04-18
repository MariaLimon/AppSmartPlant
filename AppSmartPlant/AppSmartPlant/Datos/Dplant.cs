using AppSmartPlant.Conexion;
using AppSmartPlant.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace AppSmartPlant.Datos
{
	public class Dplant
	{
		//public async Task InsertarPlant(Mplanta parametros)
		//{
		//	await Cconexion.firebase
		//		.Child("Nota")
		//		.PostAsync(new Mplanta()
		//		{
		//			namePlant = parametros.namePlant,
		//			typePlant = parametros.typePlant
		//		});
		//}

		public async Task<ObservableCollection<Mplanta>> MostrarPlantas()
		{
			Uri RequestUri = new Uri("https://6fd17xdg-5015.usw3.devtunnels.ms/api/Plant/Listar");
			var client = new HttpClient();
			var response = await client.GetAsync(RequestUri);

			ObservableCollection<Mplanta> plantas = new ObservableCollection<Mplanta>();

			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				plantas = JsonConvert.DeserializeObject<ObservableCollection<Mplanta>>(content);
			}
			else
			{
				// Manejar el caso donde la solicitud no fue exitosa
				// Por ejemplo, mostrar un mensaje de error
				Console.WriteLine("Error al recuperar la lista de plantas. Código de estado: " + response.StatusCode);
			}

			return plantas;
		}

		public async Task<bool> ActualizarPlant(Mplanta parametros)
		{
			var notaAEditar = (await Cconexion.firebase
				.Child("plantSmall")
				.OnceAsync<Mplanta>()).Where(p => p.Object.namePlant == parametros.namePlant).FirstOrDefault();

			if (notaAEditar != null)
			{
				await Cconexion.firebase
					.Child("plantSmall")
					.Child(notaAEditar.Key)
					.PutAsync(new Mplanta()
					{
						namePlant = parametros.namePlant,
						typePlant = parametros.typePlant
					});
				return true;
			}
			return false;

		}

		/*
		public async Task EliminarNota(string notaId)
		{
			try
			{
				var notaAEliminar = (await Cconexion.firebase
					.Child("Nota")
					.OnceAsync<Mnota1>()).Where(p => p.Object.idNota == notaId).FirstOrDefault();

				if (notaAEliminar != null)
				{
					await Cconexion.firebase
						.Child("Nota")
						.Child(notaAEliminar.Key)
						.DeleteAsync();
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error al eliminar la nota: {ex.Message}");
			}
		}

		public async Task<bool> ActualizarNota(Mnota1 parametros)
		{
			var notaAEditar = (await Cconexion.firebase
				.Child("Nota")
				.OnceAsync<Mnota1>()).Where(p => p.Object.idNota == parametros.idNota).FirstOrDefault();

			if (notaAEditar != null)
			{
				await Cconexion.firebase
					.Child("Nota")
					.Child(notaAEditar.Key)
					.PutAsync(new Mnota1()
					{
						Titulo = parametros.Titulo,
						Descripcion = parametros.Descripcion,
					});
				return true;
			}
			return false;
		}
		*/
	}
}