using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaxBiller.Common
{
    public static class ListExtensions
    {
        public static void Add<T>(this List<string> list, params T[] values)
        {
            foreach (var value in values)
            {
                list.Add(value == null ? "" : value.ToString());
            }
        }

        public static void AddBlank(this List<string> list)
        {
            list.Add(string.Empty);
        }

        public static void AddBlanks(this List<string> list, int count)
        {
            for (int i = 0; i < count; i++)
            {
                list.AddBlank();
            }
        }

        public static void AddWrapped(this List<string> list, string value, bool addExtraLine = false)
        {
            if (value.Length > Configuration.MaxCharacterLength)
            {
                list.Add(value.Substring(0, Configuration.MaxCharacterLength));
                list.Add(value.Substring(Configuration.MaxCharacterLength + 1));
            }
            else
            {
                list.Add(value);
                list.AddBlank(); // not printed line
            }

            if (addExtraLine)
            {
                list.AddBlank();
            }
        }
    }
}
