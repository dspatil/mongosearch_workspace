using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoMapReduce
{
   public class MongoQueryElement
    {
        public List<MongoQueryPredicate> QueryPredicates { get; set; }

        public MongoQueryElement()
        {
            QueryPredicates = new List<MongoQueryPredicate>();
        }

        public string ConvertToString()
        {
            string predicates = "";
            foreach (var qp in QueryPredicates)
            {
                predicates = predicates + qp.ToString() + ",";
            }

            return String.Format(@"{{ ""$elemMatch"" : {{ {0} }} }}", predicates);
        }
    }
}
