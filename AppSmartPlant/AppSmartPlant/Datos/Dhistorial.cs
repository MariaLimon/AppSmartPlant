using AppSmartPlant.Conexion;
using AppSmartPlant.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Firebase.Database.Query;
using Firebase.Database;
using System.Linq;

namespace AppSmartPlant.Datos
{
	public class Dhistorial
	{
		public async Task<ObservableCollection<Mhistorial>> MostrarHistorial()
		{
			var data = await Task.Run(() => Cconexion.firebase
				.Child("historialPlant")
				.AsObservable<Mhistorial>()
				.AsObservableCollection());
			// .Where(a => a.Nombre !="-"));
			return data;
		}
	}
}
