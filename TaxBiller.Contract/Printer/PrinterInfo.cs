using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxBiller.Contract
{
    public abstract class PrinterInfo
    {
        public short ReturnCode { get; protected set; }

        public short PrinterStatus { get; protected set; }

        public short FiscalStatus { get; protected set; }

        public string Voucher { get; protected set; }
    }
}
