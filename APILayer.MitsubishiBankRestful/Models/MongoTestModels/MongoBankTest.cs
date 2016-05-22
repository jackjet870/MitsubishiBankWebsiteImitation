using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Core.MitsubishiBank.BankCommon;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Bson;

namespace APILayer.MitsubishiBankRestful.Models.MongoTestModels
{
    public class MongoBankTest : Bank
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string MongoDbId { get; set; }

    }

}