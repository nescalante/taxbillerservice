using System;
using System.Runtime.Serialization;

namespace TaxBiller.Contract
{
    [DataContract]
    public class PaymentMethod
    {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string PaymentType { get; set; }

        [DataMember]
        public decimal Ammount { get; set; }
    }
}
