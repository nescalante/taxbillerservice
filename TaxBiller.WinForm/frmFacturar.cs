using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using TaxBiller.Contract;
using TaxBiller.Common;
using System.Linq;

namespace TaxBiller.WinForm
{
    public partial class frmFacturar : Form
    {
        private IBillingService _billingService;

        public frmFacturar(IBillingService billingService)
        {
            InitializeComponent();

            _billingService = billingService;

            try
            {
                CultureInfo tmp_ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                tmp_ci.NumberFormat.NumberDecimalSeparator = ".";
                System.Threading.Thread.CurrentThread.CurrentCulture = tmp_ci;

                DataTable tableTiposdocumentos = new DataTable();

                tableTiposdocumentos.Columns.Add("Codigo");
                tableTiposdocumentos.Columns.Add("Descripcion");
                tableTiposdocumentos.Rows.Add(new object[]{"D", "DNI"});
                tableTiposdocumentos.Rows.Add(new object[]{"L", "CUIL"});
                tableTiposdocumentos.Rows.Add(new object[]{"T", "CUIT"});
                tableTiposdocumentos.Rows.Add(new object[]{"C", "CI"});
                tableTiposdocumentos.Rows.Add(new object[]{"P", "PAS"});
                tableTiposdocumentos.Rows.Add(new object[]{"V", "LC"});
                tableTiposdocumentos.Rows.Add(new object[]{"E", "LE"});

                cmbTipoDocumento.DataSource = tableTiposdocumentos;
                cmbTipoDocumento.DisplayMember = "Descripcion";
                cmbTipoDocumento.ValueMember = "Codigo";
                cmbTipoDocumento.SelectedValue = "D";

                DataTable tableCategoriasIVA = new DataTable();

                tableCategoriasIVA.Columns.Add("Codigo");
                tableCategoriasIVA.Columns.Add("Descripcion");
                tableCategoriasIVA.Rows.Add(new object[]{"I", "Responsable Inscripto"});
                //tableCategoriasIVA.Rows.Add(new object[]{"N", "No Responsable"});
                tableCategoriasIVA.Rows.Add(new object[]{"M", "Monotributista"});
                tableCategoriasIVA.Rows.Add(new object[]{"E", "Excento"});
                tableCategoriasIVA.Rows.Add(new object[]{"U", "No Categorizado"});
                tableCategoriasIVA.Rows.Add(new object[]{"F", "Consumidor Final"});
                //tableCategoriasIVA.Rows.Add(new object[]{"T", "Monotributista Social"});
                tableCategoriasIVA.Rows.Add(new object[]{"C", "Contribuyente Eventual"});
                tableCategoriasIVA.Rows.Add(new object[]{"V", "Contribuyente Eventual Social"});

                cmbCategoriaIVA.DataSource = tableCategoriasIVA;
                cmbCategoriaIVA.DisplayMember = "Descripcion";
                cmbCategoriaIVA.ValueMember = "Codigo";
                cmbCategoriaIVA.SelectedValue = "F";

                //TODO: tomar las formas de pago desde alguna configuracion
                DataTable tableFormasPago = new DataTable();

                tableFormasPago.Columns.Add("Codigo");
                tableFormasPago.Columns.Add("Descripcion");
                tableFormasPago.Rows.Add(new object[] { "Efectivo", "Efectivo" });
                tableFormasPago.Rows.Add(new object[] { "Tarjeta", "Tarjeta" });
                tableFormasPago.Rows.Add(new object[] { "Deposito", "Deposito" });
                tableFormasPago.Rows.Add(new object[] { "Transferencia", "Transferencia" });

                cmbFormaPago1.DataSource = tableFormasPago.Copy();
                cmbFormaPago1.DisplayMember = "Descripcion";
                cmbFormaPago1.ValueMember = "Codigo";
                cmbFormaPago1.SelectedValue = "Efectivo";

                cmbFormaPago2.DataSource = tableFormasPago.Copy();
                cmbFormaPago2.DisplayMember = "Descripcion";
                cmbFormaPago2.ValueMember = "Codigo";
                cmbFormaPago2.SelectedValue = "Efectivo";

                //TODO: tomar las tarjetas desde alguna configuracion
                DataTable tableTarjetas = new DataTable();

                tableTarjetas.Columns.Add("Codigo");
                tableTarjetas.Columns.Add("Descripcion");
                tableTarjetas.Rows.Add(new object[] { "Visa", "Visa" });
                tableTarjetas.Rows.Add(new object[] { "Mastercard", "Mastercard" });
                tableTarjetas.Rows.Add(new object[] { "American Express", "American Express" });
                tableTarjetas.Rows.Add(new object[] { "Dinners", "Dinners" });

                cmbTarjeta1.DataSource = tableTarjetas.Copy();
                cmbTarjeta1.DisplayMember = "Descripcion";
                cmbTarjeta1.ValueMember = "Codigo";

                cmbTarjeta2.DataSource = tableTarjetas.Copy();
                cmbTarjeta2.DisplayMember = "Descripcion";
                cmbTarjeta2.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no controlado, por favor intente nuevamente o comuniquese con el administrador");
            }
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedValue.ToString() == "T")
            {
                lblApellido.Text = "Razon Social";
                cmbCategoriaIVA.SelectedValue = "I";
            }
            else
            {
                lblApellido.Text = "Apellido y Nombre";
            }
        }

        private void dgItems_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    if (dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue != null && dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().Trim().Length > 0)
                    {
                        try
                        {
                            Convert.ToInt32(dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                        }
                        catch (Exception ex)
                        {
                            dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            MessageBox.Show("Debe ingresar un valor entero para las cantidades de los items a facturar");
                        }
                    }
                    break;
                case 2:
                    if (dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue != null && dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().Trim().Length > 0)
                    {
                        try
                        {
                            if (dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().IndexOf(",") > 0)
                                throw new Exception("Valos no numerico");

                            Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                        }
                        catch (Exception ex)
                        {
                            dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            MessageBox.Show("Debe ingresar un valor numerico para los precios unitarios de los items a facturar");
                        }
                    }
                    break;
                case 3:
                    if (dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue != null && dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().Trim().Length > 0)
                    {
                        try
                        {
                            if (dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString().IndexOf(",") > 0)
                                throw new Exception("Valos no numerico");

                            Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                        }
                        catch (Exception ex)
                        {
                            dgItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                            MessageBox.Show("Debe ingresar un valor numerico para los totales de los items a facturar");
                        }
                    }
                    break;
            }

            double total = 0;

            switch (e.ColumnIndex)
            {
                case 0:
                case 2:
                    if (dgItems.Rows[e.RowIndex].Cells[0].EditedFormattedValue != null && dgItems.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString().Trim().Length > 0 && dgItems.Rows[e.RowIndex].Cells[2].EditedFormattedValue != null && dgItems.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString().Trim().Length > 0)
                    {
                        try
                        {
                            if (dgItems.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString().IndexOf(",") < 0)
                                dgItems.Rows[e.RowIndex].Cells[3].Value = (Convert.ToInt32(dgItems.Rows[e.RowIndex].Cells[0].EditedFormattedValue) * Convert.ToDouble(dgItems.Rows[e.RowIndex].Cells[2].EditedFormattedValue)).ToString();
                        }
                        catch
                        {}
                    }

                    for (int i = 0; i < dgItems.Rows.Count; i++)
                    {
                        if (dgItems.Rows[i].Cells[0].EditedFormattedValue != null && dgItems.Rows[i].Cells[0].EditedFormattedValue.ToString().Trim().Length > 0 && dgItems.Rows[i].Cells[2].EditedFormattedValue != null && dgItems.Rows[i].Cells[2].EditedFormattedValue.ToString().Trim().Length > 0)
                        {
                            try
                            {
                                if (dgItems.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString().IndexOf(",") < 0)
                                    total += (Convert.ToInt32(dgItems.Rows[i].Cells[0].EditedFormattedValue) * Convert.ToDouble(dgItems.Rows[i].Cells[2].EditedFormattedValue));
                            }
                            catch
                            { }
                        } 
                    }

                    lblTotalAcumulado.Text = total.ToString("00.00");

                    if (txtDescuento.Text.Trim().Length > 0)
                    {
                        try
                        {
                            lblTotalGeneral.Text = (total - Convert.ToDouble(txtDescuento.Text)).ToString("00.00");
                        }
                        catch (Exception eX)
                        {
                            lblTotalGeneral.Text = total.ToString("00.00");
                        }
                    }
                    else
                    {
                        lblTotalGeneral.Text = total.ToString("00.00");
                    }
                    break;
            }
        }


        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosTicket())
                {
                    ImprimirTicketFactura();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no controlado, por favor intente nuevamente o comuniquese con el administrador");
            }
        }

        private void ImprimirTicketFactura()
        {
            var invoice = new Invoice
            {
                Name = txtApellidoNombre.Text.Trim(),
                Address = txtDomicilio.Text.Trim(),
                TaxCategory = cmbCategoriaIVA.SelectedValue.ToString(),
                Id = txtNroDocumento.Text.Trim(),
                IdType = cmbTipoDocumento.SelectedValue.ToString(),
                Discount = Convert.ToDecimal((txtDescuento.Text.Trim() != "") ? txtDescuento.Text : "0"),
                Items = dgItems.Rows.Cast<DataGridViewRow>().Where(r => r.Cells[1].Value != null && r.Cells[1].Value.ToString().Trim() != "")
                    .Select(r => new InvoiceItem
                    {
                        Description = r.Cells[1].Value.ToString().Trim(),
                        Quantity = Convert.ToInt32(r.Cells[0].Value),
                        Price = Convert.ToDecimal(r.Cells[2].Value),
                        Tax = Configuration.Tax,
                    }),
            };

            var paymentMethods = new List<PaymentMethod>();
            
            if (txtMontoPago1.Text.Trim().Length > 0)
            {
                var description1 = string.Join(" ", new[] 
                { 
                    cmbTarjeta1.Enabled ? cmbTarjeta1.Text.Trim() : null, 
                    txtNumeroMov1.Text.Trim().Length > 0 ? txtNumeroMov1.Text.Trim() : null, 
                    dtpFechaMov1.Enabled && dtpFechaMov1.Checked ? dtpFechaMov1.Value.ToString("dd/MM/yyyy") : null
                }.Where(i => !string.IsNullOrEmpty(i)));

                paymentMethods.Add(new PaymentMethod 
                {
                    Description = description1,
                    PaymentType = cmbFormaPago1.Text,
                    Ammount = Convert.ToDecimal(txtMontoPago1.Text.Trim()),
                });

                if (txtMontoPago2.Text.Trim().Length > 0)
                {
                    var description2 = string.Join(" ", new[] 
                    { 
                        cmbTarjeta2.Enabled ? cmbTarjeta2.Text.Trim() : null, 
                        txtNumeroMov2.Text.Trim().Length > 0 ? txtNumeroMov2.Text.Trim() : null, 
                        dtpFechaMov2.Enabled && dtpFechaMov2.Checked ? dtpFechaMov2.Value.ToString("dd/MM/yyyy") : null
                    }.Where(i => !string.IsNullOrEmpty(i)));

                    paymentMethods.Add(new PaymentMethod
                    {
                        Description = description2,
                        PaymentType = cmbFormaPago2.Text,
                        Ammount = Convert.ToDecimal(txtMontoPago2.Text.Trim()),
                    });
                }
            }

            invoice.PaymentMethods = paymentMethods;
            var info = _billingService.Bill(invoice);

            using (StreamWriter outfile = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\facturas.txt", true))
            {
                outfile.Write(DateTime.Now.ToString() + ", " + info.Voucher + ", " + lblTotalGeneral.Text + ", " + cmbTipoDocumento.Text + ", " + txtNroDocumento.Text + ", " + txtApellidoNombre.Text);
            }

            LimpiarFormulario();
        }

        private bool ValidarDatosTicket()
        {
            //TODO: Hacer Validaciones
            if (txtApellidoNombre.Text.Trim().Length==0)
            {
                MessageBox.Show("Debe ingresar un nombre y apellido o Razon social");
                return false;
            }

            if (txtApellidoNombre.Text.Trim().IndexOf(",") >= 0 || txtApellidoNombre.Text.Trim().IndexOf(";") >= 0 || txtApellidoNombre.Text.Trim().IndexOf(":") >= 0)
            {
                MessageBox.Show("El nombre o apellido posee caracteres invalidos");
                return false;
            }

            if (cmbCategoriaIVA.SelectedValue.ToString() == "I")
            {
                if (txtDomicilio.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar un domicilio");
                    return false;
                }
            }

            if (txtNroDocumento.Text.Trim().Length==0)
            {
                MessageBox.Show("Deber ingresar un numero de documento o cuit");
                return false;
            }

            Int64 nrodoc=0;

            if (!Int64.TryParse(txtNroDocumento.Text, out nrodoc))
            {
                MessageBox.Show("El numero dedocumento o cuit solo puede contener numeros");
                return false;
            }
            if (txtNroDocumento.Text.IndexOf(".")>=0 || txtNroDocumento.Text.IndexOf(",") >= 0)
            {
                MessageBox.Show("El numero dedocumento o cuit solo puede contener numeros");
                return false;
            }
            if ((cmbTipoDocumento.SelectedValue.ToString() == "D" || cmbTipoDocumento.SelectedValue.ToString() == "L" 
                || cmbTipoDocumento.SelectedValue.ToString() == "C" || cmbTipoDocumento.SelectedValue.ToString() == "P" 
                || cmbTipoDocumento.SelectedValue.ToString() == "V" || cmbTipoDocumento.SelectedValue.ToString() == "E") 
                && cmbCategoriaIVA.SelectedValue.ToString()=="I")
            {
                MessageBox.Show("El tipo de documento ingresado no se corresponde con la categoría de iva seleccionada");
                return false;
            }

            if ((cmbTipoDocumento.SelectedValue.ToString() == "T") && (cmbCategoriaIVA.SelectedValue.ToString() != "I" && cmbCategoriaIVA.SelectedValue.ToString() != "M" && cmbCategoriaIVA.SelectedValue.ToString() != "E" && cmbCategoriaIVA.SelectedValue.ToString() != "C" && cmbCategoriaIVA.SelectedValue.ToString() != "V"))
            {
                MessageBox.Show("El tipo de documento ingresado no se corresponde con la categoría de iva seleccionada");
                return false;
            }

            for (int i = 0; i < dgItems.Rows.Count && dgItems.Rows[i].Cells[1].Value != null && dgItems.Rows[i].Cells[1].Value.ToString().Trim() != ""; i++)
            {
                if (dgItems.Rows[i].Cells[0].Value == null || dgItems.Rows[i].Cells[0].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Existen items con cantidad no ingresada");
                    return false;
                }
                if (dgItems.Rows[i].Cells[2].Value == null || dgItems.Rows[i].Cells[2].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Existen items con precio unitario no ingresado");
                    return false;
                }
                if (Convert.ToInt32(dgItems.Rows[i].Cells[0].Value) <= 0 || Convert.ToDouble(dgItems.Rows[i].Cells[2].Value) <= 0)
                {
                    MessageBox.Show("La cantidad y el precio unitario de todos los items debe ser mayo a cero");
                    return false;
                }
            }

            bool unItemOK = false;
            for (int i = 0; i < dgItems.Rows.Count ; i++)
            {
                if (dgItems.Rows[i].Cells[1].Value != null && dgItems.Rows[i].Cells[1].Value.ToString().Trim() != "")
                {
                    if (dgItems.Rows[i].Cells[0].Value != null && dgItems.Rows[i].Cells[0].Value.ToString().Trim() != "")
                    {
                        if (dgItems.Rows[i].Cells[2].Value != null && dgItems.Rows[i].Cells[2].Value.ToString().Trim() != "")
                        {
                            unItemOK = true;
                        }
                    }
                }
            }

            if (!unItemOK)
            {
                MessageBox.Show("No existen items correctamente ingresados");
                return false;
            }

            if (Convert.ToDouble(lblTotalGeneral.Text) <= 0)
            {
                MessageBox.Show("El total de la factura no puede ser cero");
                return false;
            }


            double pago1 = 0;
            double pago2 = 0;

            if (txtMontoPago1.Text.Trim() != "")
            {
                pago1 = Convert.ToDouble(txtMontoPago1.Text);
            }

            if (txtMontoPago2.Text.Trim() != "")
            {
                pago2 = Convert.ToDouble(txtMontoPago2.Text);
            }

            if ( pago1 + pago2 != Convert.ToDouble(lblTotalGeneral.Text))
            {
                MessageBox.Show("El total de las formas de pago debe ser igual al total general");
                return false;
            }

            return true;
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (txtDescuento.Text.Trim().Length > 0)
            {
                try
                {
                    Convert.ToDouble(txtDescuento.Text);

                    lblTotalGeneral.Text = (Convert.ToDouble(lblTotalAcumulado.Text) - Convert.ToDouble(txtDescuento.Text)).ToString("00.00");
                }
                catch (Exception ex)
                {
                    lblTotalGeneral.Text = lblTotalAcumulado.Text;  
                }
            }
            else
            {
                lblTotalGeneral.Text = lblTotalAcumulado.Text;
            }
        }

        private void cmbFormaPago1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTarjeta1.Enabled = false;
            txtNumeroMov1.Enabled = false;
            dtpFechaMov1.Enabled = false;
            dtpFechaMov1.Checked = false;

            switch (cmbFormaPago1.SelectedValue.ToString())
            {
                case "Efectivo":
                    break;
                case "Tarjeta":
                    cmbTarjeta1.Enabled = true;
                    txtNumeroMov1.Enabled = true;
                    dtpFechaMov1.Enabled = true;
                    break;
                case "Deposito":
                case "Transferencia":
                    txtNumeroMov1.Enabled = true;
                    dtpFechaMov1.Enabled = true;
                    break;
            }
 
        }

        private void cmbFormaPago2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTarjeta2.Enabled = false;
            txtNumeroMov2.Enabled = false;
            dtpFechaMov2.Enabled = false;
            dtpFechaMov2.Checked = false;

            switch (cmbFormaPago2.SelectedValue.ToString())
            {
                case "Efectivo":
                    break;
                case "Tarjeta":
                    cmbTarjeta2.Enabled = true;
                    txtNumeroMov2.Enabled = true;
                    dtpFechaMov2.Enabled = true;
                    break;
                case "Deposito":
                case "Transferencia":
                    txtNumeroMov2.Enabled = true;
                    dtpFechaMov2.Enabled = true;
                    break;
            }
        }

        private void LimpiarFormulario()
        { 
            txtApellidoNombre.Text = "";
            txtDomicilio.Text = "";
            txtDescuento.Text = "";
            txtMontoPago1.Text = "";
            txtMontoPago2.Text = "";
            txtNroDocumento.Text = "";
            txtNumeroMov1.Text = "";
            txtNumeroMov2.Text = "";
            cmbTipoDocumento.SelectedValue = "D";
            cmbCategoriaIVA.SelectedValue = "F";
            cmbFormaPago1.SelectedValue = "Efectivo";
            cmbFormaPago2.SelectedValue = "Efectivo";

            dgItems.Rows.Clear();
        }
    }
}