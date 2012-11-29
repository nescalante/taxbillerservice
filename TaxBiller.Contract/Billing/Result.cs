using System.Runtime.Serialization;

namespace TaxBiller.Contract
{
    [DataContract]
    public class Result
    {
        public static Result OK()
        {
            return new Result { Status = "OK" };
        }

        public static Result OK(string voucher)
        {
            return new Result { Status = "OK", Voucher = voucher, };
        }

        public static Result Error(string message)
        {
            return new Result { Status = "Error", Message = message, };
        }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Voucher { get; set; }
    }
}
