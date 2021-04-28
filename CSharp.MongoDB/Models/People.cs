using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CSharp.MongoDB.Models
{
    public class People
    {
        [BsonId] // es id
        [BsonRepresentation(BsonType.ObjectId)]// y va a ser un objectId, osea un tipo guid auto generado
        public string Id { get; set; }
        [BsonElement("nombre")] // hace match con el parametro en mongodb
        public string Nombre { get; set; }
        [BsonElement("edad")]
        public int Edad { get; set; }
        [BsonElement("country")]
        public string Country { get; set; }
    }
}
