using System;
using TaxBiller.Contract;

namespace TaxBiller.Common
{
    public class PrinterException : Exception
    {
        public PrinterInfo Info { get; private set; }

        public PrinterException(string message, PrinterInfo info)
            : base(message)
        {
            this.Info = info;
        }

        public PrinterException(string message, Exception innerException, PrinterInfo info)
            : base(message, innerException)
        {
            this.Info = info;
        }
    }
}
