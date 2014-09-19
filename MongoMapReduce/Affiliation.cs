using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoMapReduce
{
    public class Affiliation
    {
        public string Type { get; set; }

        public string AffiliatedBy { get; set; }

        /// <summary>
        /// E.g. TIN/PAN/ServiceTaxRegNumber
        /// </summary>
        public string Name { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }
}
