using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TaxBiller.Contract;
using TaxBiller.Common;

namespace TaxBiller.WinForm
{
    public partial class Main : Form
    {
        private IBillingService _billingService;

        public Main(IBillingService billingService)
        {
            InitializeComponent();

            _billingService = billingService;
        }

        private void facturarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bill frm = new Bill(_billingService);
            frm.Show();
        }

        private void cerrarDíacierreZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _billingService.DailyCashBalance();
            }
            catch (PrinterException ex)
            {
                ShowMsg(ex.Info);
            }
        }

        private void cerrarCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _billingService.CashDeskClosing();
            }
            catch (PrinterException ex)
            {
                ShowMsg(ex.Info);
            }
        }

        private void ShowMsg(PrinterInfo info)
        {
            string codigo = "0000" + info.ReturnCode.ToString("X");
            string estadoImpresora = "0000" + info.PrinterStatus.ToString("X");
            string estadofiscal = "0000" + info.FiscalStatus.ToString("X");

            string s = "Código de Retorno: " + codigo.Substring(codigo.Length - 4);
            s += System.Environment.NewLine + "Estado Impresora: " + estadoImpresora.Substring(estadoImpresora.Length - 4);
            s += System.Environment.NewLine + "Estado Fsical: " + estadofiscal.Substring(estadofiscal.Length - 4);

            MessageBox.Show(s, "Información Impresora");
        }

        private void listadoDeComprobantesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}