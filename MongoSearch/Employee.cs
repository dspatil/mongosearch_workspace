using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;

namespace MongoSearch
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }

        public Team Team { get; set; }

        public ObjectId _id { get; set; }

        public string Address { get; set; }

    }
}
