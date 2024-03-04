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
	public class Dnoti
	{
		public async Task<ObservableCollection<Mnoti>> MostrarNotis()
		{
			var data = await Task.Run(() => Cconexion.firebase
				.Child("Noti")
				.AsObservable<Mnoti>()
				.AsObservableCollection());
			// .Where(a => a.Nombre !="-"));
			return data;
		}
	}
}
