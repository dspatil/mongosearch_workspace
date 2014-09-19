using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoMapReduce
{
    public class Membership
    {
        /// <summary>
        /// E.g. AirMembership/HotelMembership/CarMembership etc
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Membership code given by provider
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// E.g. CorporateCode/PromotionalCode/FF etc
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// E.g. American Airline
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// E.g. AA
        /// </summary>
        public string ProviderCode { get; set; }

        /// <summary>
        /// Date of membership effective from
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date on membership expires
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Will play a tie breaker when multiple memberships are valid.
        /// </summary>
        public int PreferenceOrder { get; set; }
    }
}
