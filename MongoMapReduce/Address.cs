﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoMapReduce
{
    public class Address
    {
        public string AddressScheme { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Zip { get; set; }
    }
}
