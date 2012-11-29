using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxBiller.Contract;
using TaxBiller.Common;

namespace TaxBiller.Web.Controllers
{
    public class BillingController : Controller
    {
        private IBillingService _billingService;

        public BillingController(IBillingService billingService)
        {
            _billingService = billingService;
        }

        [HttpPost]
        [AllowCrossSiteJson]
        public ActionResult DailyCashBalance()
        {
            var info = _billingService.DailyCashBalance();

            return Json(info, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Facturar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Facturar(FormCollection collection)
        {
            PrinterInfo info;
            _billingService.DailyCashBalance();

            return RedirectToAction("Facturar");
        }
    }
}
