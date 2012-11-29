using TaxBiller.Contract;

namespace TaxBiller.EpsonFP.Service
{
    internal class EpsonFPInfo : PrinterInfo
    {
        internal EpsonFPInfo(short returnCode, short printerStatus, short fiscalStatus, string voucher = null)
        {
            this.ReturnCode = returnCode;
            this.PrinterStatus = printerStatus;
            this.FiscalStatus = fiscalStatus;
            this.Voucher = voucher;
        }

        internal void SetVoucher(string voucher)
        {
            this.Voucher = voucher;
        }
    }
}
