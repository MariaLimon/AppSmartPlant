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

		private MongoClient _client;
		private IMongoDatabase _database;

		public IMongoCollection<Musuario> Users { get; private set; }

		public Cconexion()
		{
			// Configura la conexión a MongoDB
			_client = new MongoClient("mongodb://localhost:27017");
			_database = _client.GetDatabase("SmartPlant00");

			// Obtiene la colección de usuarios
			Users = _database.GetCollection<Musuario>("Users");
		}


	}
}


