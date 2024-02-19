using System;
using System.Collections.Generic;
using System.Text;
using Amazon.Util.Internal;
using AppSmartPlant.Models;
using Firebase.Database;
using MongoDB.Driver;
using MongoDB.Bson;


namespace AppSmartPlant.Conexion
{
	public class Cconexion
	{
		public static FirebaseClient firebase = new FirebaseClient("https://smartplant00-ec450-default-rtdb.firebaseio.com/");

	}
}


