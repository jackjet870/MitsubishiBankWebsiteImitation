using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using APILayer.MitsubishiBankRestful.Models.MongoTestModels;
using MongoDB.Bson;
using MongoDB.Driver;

namespace APILayer.MitsubishiBankRestful.Controllers.MongoTest
{
    public class MongoTestController : ApiController
    {
        //MongoDbContext db = new MongoDbContext();
       /*
        * RavenDb : 8080
        */
        
        public void GetAll()
        {
            //return db.Computers.ToJson();
        }

    }
}
