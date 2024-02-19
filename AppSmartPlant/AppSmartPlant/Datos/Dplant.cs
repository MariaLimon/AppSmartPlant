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
		public async Task<ObservableCollection<Mplanta>> MostrarPlantas()
		{
			var data = await Task.Run(() => Cconexion.firebase
				.Child("PlantSmall")
				.AsObservable<Mplanta>()
				.AsObservableCollection());
			// .Where(a => a.Nombre !="-"));
			return data;
		}

	}
}