using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using MongoDB.Driver.Core;

namespace MyApplication.Models
{
    public class ParkInfoDaoImpl
    {
        public List<parkData> getParkingInformation()
        {
            List<parkData> parkInfo = new List<parkData>();
            String connectionString = "mongodb://pavani:pavani@ds115701.mlab.com:15701/parkinfo";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            MongoDatabase db =server.GetDatabase("parkinfo");
            MongoCollection<parkData> parkcollection = db.GetCollection<parkData>("parkinfo");
            parkInfo = parkcollection.FindAll().ToList<parkData>(); 
            return parkInfo;

        }

        public void updateParkingInformation()
        {
            List<parkData> parkInfo = new List<parkData>();
            String connectionString = "mongodb://pavani:pavani@ds115701.mlab.com:15701/parkinfo";
            MongoClient client = new MongoClient(connectionString);
            var server = client.GetServer();
            MongoDatabase db = server.GetDatabase("parkinfo");
            MongoCollection<parkData> parkcollection = db.GetCollection<parkData>("parkinfo");
            var query2 =
            from book in parkcollection.AsQueryable<parkData>()
            where book.parkSlotId == "villanova-02"
             select book;
            
            // Cast linq query to Mongo query
            var mongoQuery = ((MongoQueryable<parkData>)query2).GetMongoQuery();
            var update = new UpdateDocument {
            { "$set", new BsonDocument("isParkingAvailable", "0") }
        };
            parkcollection.Update(mongoQuery, update);

        }
    }
}