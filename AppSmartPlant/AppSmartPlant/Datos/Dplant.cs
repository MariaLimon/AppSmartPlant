using AppSmartPlant.Conexion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using AppSmartPlant.Conexion;
using AppSmartPlant.Models;
using Firebase.Database.Query;
using Firebase.Database;
using System.Linq;

namespace AppSmartPlant.Datos
{
	public class Dplant
	{
		public async Task InsertarPlant(Mplanta parametros)
		{
			await Cconexion.firebase
				.Child("Nota")
				.PostAsync(new Mplanta()
				{
					NamePlant = parametros.NamePlant,
					TypePlant = parametros.TypePlant
				});
		}

		public async Task<ObservableCollection<Mplanta>> MostrarPlantas()
		{
			var data = await Task.Run(() => Cconexion.firebase
				.Child("plantSmall")
				.AsObservable<Mplanta>()
				.AsObservableCollection());
			// .Where(a => a.Nombre !="-"));
			return data;
		}

        public async Task<bool> ActualizarPlant(Mplanta parametros)
        {
            var notaAEditar = (await Cconexion.firebase
                .Child("plantSmall")
                .OnceAsync<Mplanta>()).Where(p => p.Object.NamePlant == parametros.NamePlant).FirstOrDefault();

            if (notaAEditar != null)
            {
                await Cconexion.firebase
                    .Child("plantSmall")
                    .Child(notaAEditar.Key)
                    .PutAsync(new Mplanta()
                    {
                        NamePlant = parametros.NamePlant,
                        TypePlant = parametros.TypePlant,
						Electrovalvula = parametros.Electrovalvula
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