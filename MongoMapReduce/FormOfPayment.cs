using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoMapReduce
{
  public  class FormOfPayment
    {
        public string Type { get; set; }

        public string BankName { get; set; }

        public string AccountNumber { get; set; }

        public string BranchName { get; set; }

        public string BranchCode { get; set; }
    }
}
