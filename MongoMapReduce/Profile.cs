using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoMapReduce
{
    public class Profile
    {
        public string _id { get; set; }

        public MediaSection Media { get; set; }

        public StatusMessageSection StatusMessage { get; set; }

        public ContactSection Contact { get; set; }

        public AddressSection Address { get; set; }

        public AffiliationSection Affiliation { get; set; }

        public MembershipSection Membership { get; set; }

        public FormOfPaymentSection FormOfPayment { get; set; }

        public List<KeyValueState> AdditionalData { get; set; }

    }
}
