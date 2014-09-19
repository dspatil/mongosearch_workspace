using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoMapReduce
{
   public class Contact
    {
        public string Value { get; set; }

        public string Extension { get; set; }

        public string CountryCode { get; set; }

        public string AreaCode { get; set; }

        public bool IsDefault { get; set; }
    }
}
