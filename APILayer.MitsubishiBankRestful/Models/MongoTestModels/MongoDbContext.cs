using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Domain.Core.MitsubishiBank.BankCommon;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace APILayer.MitsubishiBankRestful.Models.MongoTestModels
{
    public class MongoDbContext
    {
        MongoClient client;
        IMongoDatabase database;
        MongoGridFS gridFS;

        public MongoDbContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var con = new MongoUrlBuilder(connectionString);

            client = new MongoClient(connectionString);
            database = client.GetDatabase(con.DatabaseName);
            gridFS = new MongoGridFS(
                new MongoServer(
                    new MongoServerSettings { Server = con.Server }),
                con.DatabaseName,
                new MongoGridFSSettings()
            );
        }

        public IMongoCollection<Bank> Computers
        {
            get { return database.GetCollection<Bank>("Banks"); }
        }

        public MongoGridFS GridFS
        {
            get { return gridFS; }
        }
    }
}