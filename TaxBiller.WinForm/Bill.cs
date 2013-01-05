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
    public partial class Bill : Form
    {
        private IBillingService _billingService;

        public Bill(IBillingService billingService)
        {
            InitializeComponent();

            _billingService = billingService;

            try
            {
                CultureInfo tmp_ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                tmp_ci.NumberFormat.NumberDecimalSeparator = ".";
                System.Threading.Thread.CurrentThread.CurrentCulture = tmp_ci;

                DataTable dtIDTypes = new DataTable();

                dtIDTypes.Columns.Add("Codigo");
                dtIDTypes.Columns.Add("Descripcion");
                dtIDTypes.Rows.Add(new object[]{"D", "DNI"});
                dtIDTypes.Rows.Add(new object[]{"L", "CUIL"});
                dtIDTypes.Rows.Add(new object[]{"T", "CUIT"});
                dtIDTypes.Rows.Add(new object[]{"C", "CI"});
                dtIDTypes.Rows.Add(new object[]{"P", "PAS"});
                dtIDTypes.Rows.Add(new object[]{"V", "LC"});
                dtIDTypes.Rows.Add(new object[]{"E", "LE"});

                cmbIDType.DataSource = dtIDTypes;
                cmbIDType.DisplayMember = "Descripcion";
                cmbIDType.ValueMember = "Codigo";
                cmbIDType.SelectedValue = "D";

                DataTable dtTaxCategories = new DataTable();

                dtTaxCategories.Columns.Add("Codigo");
                dtTaxCategories.Columns.Add("Descripcion");
                dtTaxCategories.Rows.Add(new object[]{"I", "Responsable Inscripto"});
                //tableCategoriasIVA.Rows.Add(new object[]{"N", "No Responsable"});
                dtTaxCategories.Rows.Add(new object[]{"M", "Monotributista"});
                dtTaxCategories.Rows.Add(new object[]{"E", "Excento"});
                dtTaxCategories.Rows.Add(new object[]{"U", "No Categorizado"});
                dtTaxCategories.Rows.Add(new object[]{"F", "Consumidor Final"});
                //tableCategoriasIVA.Rows.Add(new object[]{"T", "Monotributista Social"});
                dtTaxCategories.Rows.Add(new object[]{"C", "Contribuyente Eventual"});
                dtTaxCategories.Rows.Add(new object[]{"V", "Contribuyente Eventual Social"});

                cmbTaxCategory.DataSource = dtTaxCategories;
                cmbTaxCategory.DisplayMember = "Descripcion";
                cmbTaxCategory.ValueMember = "Codigo";
                cmbTaxCategory.SelectedValue = "F";

                //TODO: tomar las formas de pago desde alguna configuracion
                DataTable dtPaymentTypes = new DataTable();

                dtPaymentTypes.Columns.Add("Codigo");
                dtPaymentTypes.Columns.Add("Descripcion");
                dtPaymentTypes.Rows.Add(new object[] { "Efectivo", "Efectivo" });
                dtPaymentTypes.Rows.Add(new object[] { "Tarjeta", "Tarjeta" });
                dtPaymentTypes.Rows.Add(new object[] { "Deposito", "Deposito" });
                dtPaymentTypes.Rows.Add(new object[] { "Transferencia", "Transferencia" });

                cmbPaymentType1.DataSource = dtPaymentTypes.Copy();
                cmbPaymentType1.DisplayMember = "Descripcion";
                cmbPaymentType1.ValueMember = "Codigo";
                cmbPaymentType1.SelectedValue = "Efectivo";

                cmbPaymentType2.DataSource = dtPaymentTypes.Copy();
                cmbPaymentType2.DisplayMember = "Descripcion";
                cmbPaymentType2.ValueMember = "Codigo";
                cmbPaymentType2.SelectedValue = "Efectivo";

                //TODO: tomar las tarjetas desde alguna configuracion
                DataTable dtCards = new DataTable();

                dtCards.Columns.Add("Codigo");
                dtCards.Columns.Add("Descripcion");
                dtCards.Rows.Add(new object[] { "Visa", "Visa" });
                dtCards.Rows.Add(new object[] { "Mastercard", "Mastercard" });
                dtCards.Rows.Add(new object[] { "American Express", "American Express" });
                dtCards.Rows.Add(new object[] { "Dinners", "Dinners" });

                cmbCard1.DataSource = dtCards.Copy();
                cmbCard1.DisplayMember = "Descripcion";
                cmbCard1.ValueMember = "Codigo";

                cmbCard2.DataSource = dtCards.Copy();
                cmbCard2.DisplayMember = "Descripcion";
                cmbCard2.ValueMember = "Codigo";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no controlado, por favor intente nuevamente o comuniquese con el administrador");
            }
        }

        private void cmbIDType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIDType.SelectedValue.ToString() == "T")
            {
                lblName.Text = "Razon Social";
                cmbTaxCategory.SelectedValue = "I";
            }
            else
            {
                lblName.Text = "Apellido y Nombre";
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

                    lblTotal.Text = total.ToString("00.00");

                    if (txtDiscount.Text.Trim().Length > 0)
                    {
                        try
                        {
                            lblTotalGeneral.Text = (total - Convert.ToDouble(txtDiscount.Text)).ToString("00.00");
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


        private void btnBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no controlado, por favor intente nuevamente o comuniquese con el administrador");
            }
        }

        private void Print()
        {
            var invoice = new Invoice
            {
                Name = txtName.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                TaxCategory = cmbTaxCategory.SelectedValue.ToString(),
                Id = txtID.Text.Trim(),
                IdType = cmbIDType.SelectedValue.ToString(),
                Discount = Convert.ToDecimal((txtDiscount.Text.Trim() != "") ? txtDiscount.Text : "0"),
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
            
            if (txtAmmount1.Text.Trim().Length > 0)
            {
                var description1 = string.Join(" ", new[] 
                { 
                    cmbCard1.Enabled ? cmbCard1.Text.Trim() : null, 
                    txtMovementNumber1.Text.Trim().Length > 0 ? txtMovementNumber1.Text.Trim() : null, 
                    dtpMovementDate1.Enabled && dtpMovementDate1.Checked ? dtpMovementDate1.Value.ToString("dd/MM/yyyy") : null
                }.Where(i => !string.IsNullOrEmpty(i)));

                paymentMethods.Add(new PaymentMethod 
                {
                    Description = description1,
                    PaymentType = cmbPaymentType1.Text,
                    Ammount = Convert.ToDecimal(txtAmmount1.Text.Trim()),
                });

                if (txtAmmount2.Text.Trim().Length > 0)
                {
                    var description2 = string.Join(" ", new[] 
                    { 
                        cmbCard2.Enabled ? cmbCard2.Text.Trim() : null, 
                        txtMovementNumber2.Text.Trim().Length > 0 ? txtMovementNumber2.Text.Trim() : null, 
                        dtpMovementDate2.Enabled && dtpMovementDate2.Checked ? dtpMovementDate2.Value.ToString("dd/MM/yyyy") : null
                    }.Where(i => !string.IsNullOrEmpty(i)));

                    paymentMethods.Add(new PaymentMethod
                    {
                        Description = description2,
                        PaymentType = cmbPaymentType2.Text,
                        Ammount = Convert.ToDecimal(txtAmmount2.Text.Trim()),
                    });
                }
            }

            invoice.PaymentMethods = paymentMethods;
            var info = _billingService.Bill(invoice);

            using (StreamWriter outfile = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + @"\facturas.txt", true))
            {
                outfile.Write(DateTime.Now.ToString() + ", " + info.Voucher + ", " + lblTotalGeneral.Text + ", " + cmbIDType.Text + ", " + txtID.Text + ", " + txtName.Text);
            }

            Clear();
        }

        private bool Validate()
        {
            //TODO: Hacer Validaciones
            if (txtName.Text.Trim().Length==0)
            {
                MessageBox.Show("Debe ingresar un nombre y apellido o Razon social");
                return false;
            }

            if (txtName.Text.Trim().IndexOf(",") >= 0 || txtName.Text.Trim().IndexOf(";") >= 0 || txtName.Text.Trim().IndexOf(":") >= 0)
            {
                MessageBox.Show("El nombre o apellido posee caracteres invalidos");
                return false;
            }

            if (cmbTaxCategory.SelectedValue.ToString() == "I")
            {
                if (txtAddress.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Debe ingresar un domicilio");
                    return false;
                }
            }

            if (txtID.Text.Trim().Length==0)
            {
                MessageBox.Show("Deber ingresar un numero de documento o cuit");
                return false;
            }

            Int64 nrodoc=0;

            if (!Int64.TryParse(txtID.Text, out nrodoc))
            {
                MessageBox.Show("El numero dedocumento o cuit solo puede contener numeros");
                return false;
            }
            if (txtID.Text.IndexOf(".")>=0 || txtID.Text.IndexOf(",") >= 0)
            {
                MessageBox.Show("El numero dedocumento o cuit solo puede contener numeros");
                return false;
            }
            if ((cmbIDType.SelectedValue.ToString() == "D" || cmbIDType.SelectedValue.ToString() == "L" 
                || cmbIDType.SelectedValue.ToString() == "C" || cmbIDType.SelectedValue.ToString() == "P" 
                || cmbIDType.SelectedValue.ToString() == "V" || cmbIDType.SelectedValue.ToString() == "E") 
                && cmbTaxCategory.SelectedValue.ToString()=="I")
            {
                MessageBox.Show("El tipo de documento ingresado no se corresponde con la categoría de iva seleccionada");
                return false;
            }

            if ((cmbIDType.SelectedValue.ToString() == "T") && (cmbTaxCategory.SelectedValue.ToString() != "I" && cmbTaxCategory.SelectedValue.ToString() != "M" && cmbTaxCategory.SelectedValue.ToString() != "E" && cmbTaxCategory.SelectedValue.ToString() != "C" && cmbTaxCategory.SelectedValue.ToString() != "V"))
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

            if (txtAmmount1.Text.Trim() != "")
            {
                pago1 = Convert.ToDouble(txtAmmount1.Text);
            }

            if (txtAmmount2.Text.Trim() != "")
            {
                pago2 = Convert.ToDouble(txtAmmount2.Text);
            }

            if ( pago1 + pago2 != Convert.ToDouble(lblTotalGeneral.Text))
            {
                MessageBox.Show("El total de las formas de pago debe ser igual al total general");
                return false;
            }

            return true;
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text.Trim().Length > 0)
            {
                try
                {
                    Convert.ToDouble(txtDiscount.Text);

                    lblTotalGeneral.Text = (Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(txtDiscount.Text)).ToString("00.00");
                }
                catch (Exception ex)
                {
                    lblTotalGeneral.Text = lblTotal.Text;  
                }
            }
            else
            {
                lblTotalGeneral.Text = lblTotal.Text;
            }
        }

        private void cmbPaymentType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCard1.Enabled = false;
            txtMovementNumber1.Enabled = false;
            dtpMovementDate1.Enabled = false;
            dtpMovementDate1.Checked = false;

            switch (cmbPaymentType1.SelectedValue.ToString())
            {
                case "Efectivo":
                    break;
                case "Tarjeta":
                    cmbCard1.Enabled = true;
                    txtMovementNumber1.Enabled = true;
                    dtpMovementDate1.Enabled = true;
                    break;
                case "Deposito":
                case "Transferencia":
                    txtMovementNumber1.Enabled = true;
                    dtpMovementDate1.Enabled = true;
                    break;
            }
 
        }

        private void cmbPaymentType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCard2.Enabled = false;
            txtMovementNumber2.Enabled = false;
            dtpMovementDate2.Enabled = false;
            dtpMovementDate2.Checked = false;

            switch (cmbPaymentType2.SelectedValue.ToString())
            {
                case "Efectivo":
                    break;
                case "Tarjeta":
                    cmbCard2.Enabled = true;
                    txtMovementNumber2.Enabled = true;
                    dtpMovementDate2.Enabled = true;
                    break;
                case "Deposito":
                case "Transferencia":
                    txtMovementNumber2.Enabled = true;
                    dtpMovementDate2.Enabled = true;
                    break;
            }
        }

        private void Clear()
        { 
            txtName.Text = "";
            txtAddress.Text = "";
            txtDiscount.Text = "";
            txtAmmount1.Text = "";
            txtAmmount2.Text = "";
            txtID.Text = "";
            txtMovementNumber1.Text = "";
            txtMovementNumber2.Text = "";
            cmbIDType.SelectedValue = "D";
            cmbTaxCategory.SelectedValue = "F";
            cmbPaymentType1.SelectedValue = "Efectivo";
            cmbPaymentType2.SelectedValue = "Efectivo";

            dgItems.Rows.Clear();
        }
    }
}