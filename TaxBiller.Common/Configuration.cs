using System.Configuration;

namespace TaxBiller.Common
{
    public static class Configuration
    {
        public static int Comm
        {
            get
            {
                int comm;
                int.TryParse(ConfigurationManager.AppSettings["Comm"], out comm);

                return comm;
            }
        }

        public static int BaudRate
        {
            get
            {
                int baudRate;
                int.TryParse(ConfigurationManager.AppSettings["BaudRate"], out baudRate);

                return baudRate;
            }
        }

        public static int Tax
        {
            get
            {
                int tax;
                int.TryParse(ConfigurationManager.AppSettings["Tax"], out tax);

                return tax;
            }
        }

        public static string PrinterModel
        {
            get
            {
                return ConfigurationManager.AppSettings["Model"];
            }
        }

        public const int MaxCharacterLength = 40;
    }
}
