using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceProcess;

namespace TaxBiller.WindowsService
{
    public partial class BillingService : ServiceBase
    {
        public WebServiceHost webHost;

        public BillingService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var sn = "Facturador Fiscal Winks Hotel";

            try
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
            catch (Exception ex)
            {
                if (!EventLog.SourceExists(sn))
                    EventLog.CreateEventSource(sn, "Application");

                EventLog.WriteEntry(sn, ex.Message, EventLogEntryType.Error);
            }
        }

        protected override void OnStop()
        {
            webHost.Close();
        }
    }
}
