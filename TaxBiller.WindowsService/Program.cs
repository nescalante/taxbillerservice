using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceProcess;
using TaxBiller.Contract;
using TaxBiller.EpsonFP.Service;
using System.Diagnostics;

namespace TaxBiller.WindowsService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var sn = "Facturador Fiscal";

            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
			    { 
				    new BillingService()
			    };
                    
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex)
            {
                if (!EventLog.SourceExists(sn))
                    EventLog.CreateEventSource(sn, "Application");

                EventLog.WriteEntry(sn, ex.Message, EventLogEntryType.Error);
            }
        }

        private static void InitializeManually()
        {
            Uri baseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);

            var webHost = new WebServiceHost(typeof(ServiceSelector), baseAddress);
            var endpoint = webHost.AddServiceEndpoint(typeof(IServiceSelector), new WebHttpBinding(WebHttpSecurityMode.None), baseAddress);
            //add support for cors (both for the endpoint to detect and create reply)  
            endpoint.Behaviors.Add(new CorsBehaviorAttribute());

            foreach (var operation in endpoint.Contract.Operations)
            {
                //add support for cors (and for operation to be able to not  
                //invoke the operation if we have a preflight cors request)  
                operation.Behaviors.Add(new CorsBehaviorAttribute());
            }

            webHost.Open();
        }
    }
}
