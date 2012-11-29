using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TaxBiller.Contract
{
    [DataContract]
    public class Invoice
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string IdType { get; set; }

        [DataMember]
        public string TaxCategory { get; set; }

        [DataMember]
        public decimal Discount { get; set; }

        [DataMember]
        public IEnumerable<InvoiceItem> Items { get; set; }

        [DataMember]
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
    }
}
