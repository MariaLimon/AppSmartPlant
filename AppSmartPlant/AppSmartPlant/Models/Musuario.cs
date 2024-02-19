using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppSmartPlant.Models
{
	public class Musuario
	{
		public string NameUser { get; set; }
		public string EmailUser { get; set; }
		public string PasswordUser { get; set; }
	}
}