using System.Collections.Generic;
using TaxBiller.Common;
using TaxBiller.Contract;
using System;
using System.Linq;

namespace TaxBiller.EpsonFP.Service
{
    public class EpsonFPBillingService : IBillingService
    {
        private EpsonFPProvider _provider;

        public EpsonFPBillingService()
        {
            _provider = new EpsonFPProvider();
        }

        public string Test()
        {
            return "OK";
        }

        public PrinterInfo CashDeskClosing()
        {
            return _provider.SendData(EpsonFPCommand.CashDeskClosing);
        }

        public PrinterInfo DailyCashBalance()
        {
            return _provider.SendData(EpsonFPCommand.DailyCashBalance);
        }

        public PrinterInfo PrintTicketHeader(string client, string taxCategory, string address, string id, string idType)
        {
            var commands = new List<string>();

            commands.Add(EpsonFPCommand.PrintTicketHeader);
            commands.AddWrapped(client);

            // client address wrapped into three lines
            if (taxCategory == "I")
            {
                commands.AddWrapped(address, true);
            }
            else
            {
                commands.AddBlanks(3);
            }

            commands.Add(
                idType, 
                id, 
                taxCategory
            );

            // refer (remito, obligatorio para comprobantes A)
            if (taxCategory == "I")
            {
                commands.Add(".", ".");
            }
            else
            {
                commands.AddBlanks(2);
            }

            // reintegro de turistas
            commands.AddBlank();

            return _provider.SendData(commands);
        }

        public PrinterInfo PrintTicketItem(string description, int quantity, decimal price, int tax)
        {
            var commands = new List<string>();

            commands.Add(EpsonFPCommand.PrintTicketItem);
            commands.AddBlanks(4); // description
            commands.Add(description.Take(Configuration.MaxCharacterLength));
            commands.Add(quantity * 10000);
            commands.Add(price * 10000);
            commands.Add(tax * 100);
            commands.AddBlanks(2);

            return _provider.SendData(commands);
        }

        public PrinterInfo PrintTicketDiscounts(decimal discount)
        {
            return _provider.SendData(
                EpsonFPCommand.Discounts,
                "Descuento",
                discount * 100
            );
        }

        public PrinterInfo PrintPaymentMethod(string description, string paymentType, decimal ammount)
        {
            return _provider.SendData(
                EpsonFPCommand.PaymentMethod,
                description.Take(Configuration.MaxCharacterLength),
                paymentType,
                ammount * 100
            );
        }

        public PrinterInfo CloseTicket(string taxCategory)
        {
            _provider.SendData(
                EpsonFPCommand.CloseTicket1,
                1,
                string.Empty,
                2,
                string.Empty,
                3,
                string.Empty
            );

            var info = _provider.SendData(EpsonFPCommand.CloseTicket2, false);
            info.SetVoucher(taxCategory == "I" ? _provider.GetExtraField(4) : _provider.GetExtraField(5));

            return info;
        }

        public PrinterInfo Bill(Invoice invoice)
        {
            this.PrintTicketHeader(
                invoice.Name,
                invoice.TaxCategory,
                invoice.Address,
                invoice.Id,
                invoice.IdType
            );

            foreach (var item in invoice.Items)
            {
                this.PrintTicketItem(
                    item.Description,
                    item.Quantity,
                    item.Price,
                    item.Tax
                );
            }

            this.PrintTicketDiscounts(
                invoice.Discount
            );

            foreach (var payments in invoice.PaymentMethods)
            {
                this.PrintPaymentMethod(
                    payments.Description,
                    payments.PaymentType,
                    payments.Ammount
                );
            }

            return this.CloseTicket("");//(invoice.TaxCategory);
        }
    }
}
