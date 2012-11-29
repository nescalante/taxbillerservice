using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxBiller.EpsonFP.Service
{
    internal static class ListExtensions
    {
        internal static void Add(this List<string> list, EpsonFPCommand command)
        {
            list.Add(command.Cmd);
            list.Add(command.CmdExt);
        }
    }
}
