using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoMapReduce
{
    public static class Manager
    {
        public static void FindProfiles(List<ProfileSearchAttributes> searchAttributes)
        {
            var collection = MongoConfig.GetCollection<Profile>("Profile");

            MongoQueryAll q1 = new MongoQueryAll("Address.Addresses");
            MongoQueryAll q2 = new MongoQueryAll("Membership.Memberships");

            foreach (var search in searchAttributes)
            {
                MongoQueryElement qE = new MongoQueryElement();
                qE.QueryPredicates.Add(new MongoQueryPredicate(search.Name, search.Value));
                q1.QueryElements.Add(qE);
            }

            var searchAttributes1 = new List<ProfileSearchAttributes>() { new ProfileSearchAttributes() { Name = "Category", Value = "Activity" } };

            foreach (var search in searchAttributes1)
            {
                MongoQueryElement qE = new MongoQueryElement();
                qE.QueryPredicates.Add(new MongoQueryPredicate(search.Name, search.Value));
                q2.QueryElements.Add(qE);
            }

            BsonDocument doc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(q1.ConvertToString());
            BsonDocument doc1 = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(q2.ConvertToString());
            doc.AddRange(doc1);

            var profiles = collection.Find(new CommandDocument(doc));

            var list = new List<Profile>();
            foreach (var profile in profiles)
            {
                list.Add(profile);
            }

        }
    }
}
