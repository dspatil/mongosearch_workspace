using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoSearch
{
    public static class MongoConfig
    {
        public static MongoDatabase GetDBInstance()
        {
            MongoClient client = new MongoClient(ConfigurationManager.AppSettings["MongoServer"]);
            var server = client.GetServer();
            var db = server.GetDatabase(ConfigurationManager.AppSettings["DatabaseName"]);
            return db;
        }

        public static MongoDB.Driver.MongoCollection<T> GetCollection<T>(string colletion)
        {
            var db = GetDBInstance();

            string collectionName = colletion;
            return db.GetCollection<T>(collectionName);
        }
    }
}
