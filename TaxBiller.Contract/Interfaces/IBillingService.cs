using System;

namespace TaxBiller.Contract
{
    public interface IBillingService
    {
        PrinterInfo CashDeskClosing();

        PrinterInfo DailyCashBalance();

        PrinterInfo Bill(Invoice invoice);
    }
}
