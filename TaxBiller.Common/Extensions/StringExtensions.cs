using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxBiller.Common
{
    public static class StringExtensions
    {
        public static string Take(this string value, int count)
        {
            return new string(value.ToCharArray().Take(count).ToArray());
        }
    }
}
