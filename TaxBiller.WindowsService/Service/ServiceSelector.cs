using System;
using Castle.Windsor;
using TaxBiller.Contract;

namespace TaxBiller.WindowsService
{
    public class ServiceSelector : IServiceSelector
    {
        private static IWindsorContainer _container;
        private IBillingService _billingService;

        public ServiceSelector()
        {
            _container = new WindsorContainer();
            _container.Install(
                new ServiceInstaller()
            );

            _billingService = _container.Resolve<IBillingService>();
        }

        public Result Test()
        {
            return new Result { Status = "OK", Message = "Test successful", Voucher = "", };
        }

        public Result CashDeskClosing()
        {
            try
            {
                _billingService.CashDeskClosing();

                return Result.OK();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }

        public Result DailyCashBalance()
        {
            try
            {
                _billingService.DailyCashBalance();

                return Result.OK();
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }

        public Result Bill(Invoice invoice)
        {
            try
            {
                var info = _billingService.Bill(invoice);

                return Result.OK(info.Voucher);
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message);
            }
        }
    }
}
