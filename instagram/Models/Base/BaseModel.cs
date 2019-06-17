using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace instagram.Models.Base
{
    [BsonIgnoreExtraElements]
    public abstract class BaseModel
    {
        [BsonId]
        [JsonProperty("_id")]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

    }
}
