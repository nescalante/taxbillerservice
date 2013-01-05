namespace TaxBiller.WinForm
{
    partial class Bill
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIDType = new System.Windows.Forms.Label();
            this.cmbIDType = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbTaxCategory = new System.Windows.Forms.ComboBox();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnBill = new System.Windows.Forms.Button();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.cmbPaymentType1 = new System.Windows.Forms.ComboBox();
            this.cmbPaymentType2 = new System.Windows.Forms.ComboBox();
            this.txtAmmount1 = new System.Windows.Forms.TextBox();
            this.txtAmmount2 = new System.Windows.Forms.TextBox();
            this.cmbCard1 = new System.Windows.Forms.ComboBox();
            this.cmbCard2 = new System.Windows.Forms.ComboBox();
            this.txtMovementNumber1 = new System.Windows.Forms.TextBox();
            this.txtMovementNumber2 = new System.Windows.Forms.TextBox();
            this.dtpMovementDate1 = new System.Windows.Forms.DateTimePicker();
            this.dtpMovementDate2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Apellido y Nombre";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(134, 12);
            this.txtName.MaxLength = 80;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(454, 20);
            this.txtName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Categoría IVA";
            // 
            // lblIDType
            // 
            this.lblIDType.AutoSize = true;
            this.lblIDType.Location = new System.Drawing.Point(2, 70);
            this.lblIDType.Name = "lblIDType";
            this.lblIDType.Size = new System.Drawing.Size(130, 13);
            this.lblIDType.TabIndex = 4;
            this.lblIDType.Text = "Tipo y nro. de Documento";
            // 
            // cmbIDType
            // 
            this.cmbIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIDType.FormattingEnabled = true;
            this.cmbIDType.Location = new System.Drawing.Point(134, 61);
            this.cmbIDType.Name = "cmbIDType";
            this.cmbIDType.Size = new System.Drawing.Size(59, 21);
            this.cmbIDType.TabIndex = 5;
            this.cmbIDType.SelectedIndexChanged += new System.EventHandler(this.cmbIDType_SelectedIndexChanged);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(200, 61);
            this.txtID.MaxLength = 11;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 6;
            // 
            // cmbTaxCategory
            // 
            this.cmbTaxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaxCategory.FormattingEnabled = true;
            this.cmbTaxCategory.Location = new System.Drawing.Point(387, 61);
            this.cmbTaxCategory.Name = "cmbTaxCategory";
            this.cmbTaxCategory.Size = new System.Drawing.Size(201, 21);
            this.cmbTaxCategory.TabIndex = 7;
            // 
            // dgItems
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Descripcion,
            this.PrecioUnitario,
            this.Total});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgItems.Location = new System.Drawing.Point(5, 109);
            this.dgItems.Name = "dgItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgItems.Size = new System.Drawing.Size(583, 150);
            this.dgItems.TabIndex = 8;
            this.dgItems.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellLeave);
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MaxInputLength = 2;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 50;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 290;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "Precio Unitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(6, 90);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(80, 13);
            this.lblItems.TabIndex = 9;
            this.lblItems.Text = "Items a facturar";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(540, 262);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(39, 13);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "00.00";
            // 
            // btnBill
            // 
            this.btnBill.Location = new System.Drawing.Point(505, 410);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(75, 23);
            this.btnBill.TabIndex = 11;
            this.btnBill.Text = "Facturar";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(437, 291);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(59, 13);
            this.lblDiscount.TabIndex = 12;
            this.lblDiscount.Text = "Descuento";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(502, 284);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(77, 20);
            this.txtDiscount.TabIndex = 13;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeneral.Location = new System.Drawing.Point(540, 315);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(39, 13);
            this.lblTotalGeneral.TabIndex = 14;
            this.lblTotalGeneral.Text = "00.00";
            // 
            // cmbPaymentType1
            // 
            this.cmbPaymentType1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType1.FormattingEnabled = true;
            this.cmbPaymentType1.Location = new System.Drawing.Point(12, 357);
            this.cmbPaymentType1.Name = "cmbPaymentType1";
            this.cmbPaymentType1.Size = new System.Drawing.Size(168, 21);
            this.cmbPaymentType1.TabIndex = 15;
            this.cmbPaymentType1.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentType1_SelectedIndexChanged);
            // 
            // cmbPaymentType2
            // 
            this.cmbPaymentType2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentType2.FormattingEnabled = true;
            this.cmbPaymentType2.Location = new System.Drawing.Point(12, 384);
            this.cmbPaymentType2.Name = "cmbPaymentType2";
            this.cmbPaymentType2.Size = new System.Drawing.Size(168, 21);
            this.cmbPaymentType2.TabIndex = 16;
            this.cmbPaymentType2.SelectedIndexChanged += new System.EventHandler(this.cmbPaymentType2_SelectedIndexChanged);
            // 
            // txtAmmount1
            // 
            this.txtAmmount1.Location = new System.Drawing.Point(502, 356);
            this.txtAmmount1.Name = "txtAmmount1";
            this.txtAmmount1.Size = new System.Drawing.Size(77, 20);
            this.txtAmmount1.TabIndex = 17;
            // 
            // txtAmmount2
            // 
            this.txtAmmount2.Location = new System.Drawing.Point(503, 383);
            this.txtAmmount2.Name = "txtAmmount2";
            this.txtAmmount2.Size = new System.Drawing.Size(77, 20);
            this.txtAmmount2.TabIndex = 18;
            // 
            // cmbCard1
            // 
            this.cmbCard1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCard1.Enabled = false;
            this.cmbCard1.FormattingEnabled = true;
            this.cmbCard1.Location = new System.Drawing.Point(187, 356);
            this.cmbCard1.Name = "cmbCard1";
            this.cmbCard1.Size = new System.Drawing.Size(121, 21);
            this.cmbCard1.TabIndex = 19;
            // 
            // cmbCard2
            // 
            this.cmbCard2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCard2.Enabled = false;
            this.cmbCard2.FormattingEnabled = true;
            this.cmbCard2.Location = new System.Drawing.Point(187, 383);
            this.cmbCard2.Name = "cmbCard2";
            this.cmbCard2.Size = new System.Drawing.Size(121, 21);
            this.cmbCard2.TabIndex = 20;
            // 
            // txtMovementNumber1
            // 
            this.txtMovementNumber1.Enabled = false;
            this.txtMovementNumber1.Location = new System.Drawing.Point(315, 356);
            this.txtMovementNumber1.MaxLength = 8;
            this.txtMovementNumber1.Name = "txtMovementNumber1";
            this.txtMovementNumber1.Size = new System.Drawing.Size(78, 20);
            this.txtMovementNumber1.TabIndex = 21;
            // 
            // txtMovementNumber2
            // 
            this.txtMovementNumber2.Enabled = false;
            this.txtMovementNumber2.Location = new System.Drawing.Point(315, 385);
            this.txtMovementNumber2.MaxLength = 8;
            this.txtMovementNumber2.Name = "txtMovementNumber2";
            this.txtMovementNumber2.Size = new System.Drawing.Size(78, 20);
            this.txtMovementNumber2.TabIndex = 22;
            // 
            // dtpMovementDate1
            // 
            this.dtpMovementDate1.Enabled = false;
            this.dtpMovementDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMovementDate1.Location = new System.Drawing.Point(400, 356);
            this.dtpMovementDate1.Name = "dtpMovementDate1";
            this.dtpMovementDate1.Size = new System.Drawing.Size(96, 20);
            this.dtpMovementDate1.TabIndex = 23;
            // 
            // dtpMovementDate2
            // 
            this.dtpMovementDate2.Enabled = false;
            this.dtpMovementDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMovementDate2.Location = new System.Drawing.Point(400, 384);
            this.dtpMovementDate2.Name = "dtpMovementDate2";
            this.dtpMovementDate2.Size = new System.Drawing.Size(96, 20);
            this.dtpMovementDate2.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 337);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Forma de Pago";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(191, 337);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Tarjeta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(318, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Nro. Mov.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(404, 337);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Fecha Mov.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(500, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Monto";
            // 
            // lblTotalText
            // 
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalText.Location = new System.Drawing.Point(418, 262);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(116, 13);
            this.lblTotalText.TabIndex = 30;
            this.lblTotalText.Text = "Total acumulado: $";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(420, 315);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Total: $";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(134, 35);
            this.txtAddress.MaxLength = 80;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(454, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(3, 42);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(49, 13);
            this.lblAddress.TabIndex = 32;
            this.lblAddress.Text = "Domicilio";
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 441);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTotalText);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpMovementDate2);
            this.Controls.Add(this.dtpMovementDate1);
            this.Controls.Add(this.txtMovementNumber2);
            this.Controls.Add(this.txtMovementNumber1);
            this.Controls.Add(this.cmbCard2);
            this.Controls.Add(this.cmbCard1);
            this.Controls.Add(this.txtAmmount2);
            this.Controls.Add(this.txtAmmount1);
            this.Controls.Add(this.cmbPaymentType2);
            this.Controls.Add(this.cmbPaymentType1);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.btnBill);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.cmbTaxCategory);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.cmbIDType);
            this.Controls.Add(this.lblIDType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "Bill";
            this.Text = "Facturar";
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIDType;
        private System.Windows.Forms.ComboBox cmbIDType;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbTaxCategory;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.ComboBox cmbPaymentType1;
        private System.Windows.Forms.ComboBox cmbPaymentType2;
        private System.Windows.Forms.TextBox txtAmmount1;
        private System.Windows.Forms.TextBox txtAmmount2;
        private System.Windows.Forms.ComboBox cmbCard1;
        private System.Windows.Forms.ComboBox cmbCard2;
        private System.Windows.Forms.TextBox txtMovementNumber1;
        private System.Windows.Forms.TextBox txtMovementNumber2;
        private System.Windows.Forms.DateTimePicker dtpMovementDate1;
        private System.Windows.Forms.DateTimePicker dtpMovementDate2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
    }
}