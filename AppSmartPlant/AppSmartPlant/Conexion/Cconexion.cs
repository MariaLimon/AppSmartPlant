using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace AppSmartPlant.Conexion
{
	public class Cconexion
	{
		public static FirebaseClient firebase = new FirebaseClient("https://smartplant00-ec450-default-rtdb.firebaseio.com/");
	}
}
