using System.Runtime.Serialization;

namespace TaxBiller.Contract
{
    [DataContract]
    public class InvoiceItem
    {
        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int Tax { get; set; }

        public decimal Total 
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}
