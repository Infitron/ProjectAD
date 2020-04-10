using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectADApi.Contract.V1.Request
{
    public class BankodeRequest
    {
       
        public string BankName { get; set; }
        public string Bankcode { get; set; }
        public DateTime? CreatedDate { get; set; }

        //public virtual ICollection<BankDetails> BankDetails { get; set; }
    }
}
