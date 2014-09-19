﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoSearch
{
    public class MongoQueryPredicate
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public MongoQueryPredicate(string name, object value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            if (this.Value is int)
                return String.Format(@" ""{0}"" : {1} ", this.Name, this.Value);

            return String.Format(@" ""{0}"" : ""{1}"" ", this.Name, this.Value);
        }
    }
}
