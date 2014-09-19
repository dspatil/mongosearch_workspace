using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMapReduce
{
    class MongoQueryAll
    {
        public string Name { get; set; }
        public List<MongoQueryElement> QueryElements { get; set; }

        public MongoQueryAll(string name)
        {
            Name = name;
            QueryElements = new List<MongoQueryElement>();
        }

        public string ConvertToString()
        {
            string qelems = "";
            foreach (var qe in QueryElements)
                qelems = qelems + qe + ",";

            string query = String.Format(@"{{ ""{0}"" : {{ $all : [ {1} ] }} }}", this.Name, qelems);

            return query;
        }
    }
}
