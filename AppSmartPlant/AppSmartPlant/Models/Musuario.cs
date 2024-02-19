using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppSmartPlant.Models
{
	public class Musuario
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		[BsonElement("NameUser")]
		public string NameUser { get; set; }
		[BsonElement("EmailUser")]
		public string EmailUser { get; set; }
		[BsonElement("PasswordUser")]
		public string PasswordUser { get; set; }
	}
}