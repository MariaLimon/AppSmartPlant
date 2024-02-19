using AppSmartPlant.Conexion;
using AppSmartPlant.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppSmartPlant.Datos
{
	public class Duser
	{
		private readonly IMongoCollection<Musuario> _usersCollection;

		public Duser(IMongoCollection<Musuario> usersCollection)
		{
			_usersCollection = usersCollection;
		}

		public async Task InsertarUsuario(Musuario musuario)
		{
			await _usersCollection.InsertOneAsync(musuario);
		}

	}
}
