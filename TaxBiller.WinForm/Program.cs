using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Castle.Windsor;
using TaxBiller.Contract;

namespace TaxBiller.WinForm
{
    static class Program
    {
        private static IWindsorContainer _container;

        [STAThread]
        static void Main()
        {
            _container = new WindsorContainer();
            _container.Install(
                new ServiceInstaller()
            );

            var billingLogic = _container.Resolve<IBillingService>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(billingLogic));
        }
    }
}