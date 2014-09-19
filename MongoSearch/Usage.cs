using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace MongoSearch
{
    public class Usage
    {
        public void FindIdentities(List<IdentityAttributeSearch> searchAttributes)
        {
            var collection = MongoConfig.GetCollection<Employee>("Employee");

            MongoQueryAll qAll = new MongoQueryAll("Relationships");

            foreach (var search in searchAttributes)
            {
                MongoQueryElement qE = new MongoQueryElement();
                qE.QueryPredicates.Add(new MongoQueryPredicate("RelationshipType", search.RelationshipType));
                qE.QueryPredicates.Add(new MongoQueryPredicate("Attributes." + search.Name, search.Datum));
                qAll.QueryElements.Add(qE);
            }

            BsonDocument doc = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(qAll.ToString());

           // var identities = collection.Find();

        }
    }
}
