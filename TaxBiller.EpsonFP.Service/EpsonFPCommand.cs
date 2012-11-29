using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxBiller.EpsonFP.Service
{
    internal class EpsonFPCommand
    {
        private EpsonFPCommand(string cmd, string cmdExt)
        {
            this.Cmd = cmd;
            this.CmdExt = cmdExt;
        }

        internal string Cmd { get; private set; }

        internal string CmdExt { get; private set; }

        internal static EpsonFPCommand CashDeskClosing = new EpsonFPCommand("\x8\x2", "\x0\x1");

        internal static EpsonFPCommand DailyCashBalance = new EpsonFPCommand("\x8\x1", "\xC\x0");

        internal static EpsonFPCommand PrintTicketHeader = new EpsonFPCommand("\xB\x1", "\x0\x0");

        internal static EpsonFPCommand PrintTicketItem = new EpsonFPCommand("\xB\x2", "\x0\x8");

        internal static EpsonFPCommand Discounts = new EpsonFPCommand("\xB\x4", "\x0\x0");

        internal static EpsonFPCommand PaymentMethod = new EpsonFPCommand("\xB\x5", "\x0\x0");

        internal static EpsonFPCommand CloseTicket1 = new EpsonFPCommand("\xB\x6", "\x0\x1");

        internal static EpsonFPCommand CloseTicket2 = new EpsonFPCommand("\x8\xA", "\x0\x0");
    }
}
