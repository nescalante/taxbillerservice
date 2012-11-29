namespace TaxBiller.WinForm
{
    partial class frmFacturar
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellidoNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.cmbCategoriaIVA = new System.Windows.Forms.ComboBox();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalAcumulado = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.cmbFormaPago1 = new System.Windows.Forms.ComboBox();
            this.cmbFormaPago2 = new System.Windows.Forms.ComboBox();
            this.txtMontoPago1 = new System.Windows.Forms.TextBox();
            this.txtMontoPago2 = new System.Windows.Forms.TextBox();
            this.cmbTarjeta1 = new System.Windows.Forms.ComboBox();
            this.cmbTarjeta2 = new System.Windows.Forms.ComboBox();
            this.txtNumeroMov1 = new System.Windows.Forms.TextBox();
            this.txtNumeroMov2 = new System.Windows.Forms.TextBox();
            this.dtpFechaMov1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaMov2 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(3, 19);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(92, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido y Nombre";
            // 
            // txtApellidoNombre
            // 
            this.txtApellidoNombre.Location = new System.Drawing.Point(134, 12);
            this.txtApellidoNombre.MaxLength = 80;
            this.txtApellidoNombre.Name = "txtApellidoNombre";
            this.txtApellidoNombre.Size = new System.Drawing.Size(454, 20);
            this.txtApellidoNombre.TabIndex = 2;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo y nro. de Documento";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(134, 61);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(59, 21);
            this.cmbTipoDocumento.TabIndex = 5;
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumento_SelectedIndexChanged);
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Location = new System.Drawing.Point(200, 61);
            this.txtNroDocumento.MaxLength = 11;
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(100, 20);
            this.txtNroDocumento.TabIndex = 6;
            // 
            // cmbCategoriaIVA
            // 
            this.cmbCategoriaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoriaIVA.FormattingEnabled = true;
            this.cmbCategoriaIVA.Location = new System.Drawing.Point(387, 61);
            this.cmbCategoriaIVA.Name = "cmbCategoriaIVA";
            this.cmbCategoriaIVA.Size = new System.Drawing.Size(201, 21);
            this.cmbCategoriaIVA.TabIndex = 7;
            // 
            // dgItems
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cantidad,
            this.Descripcion,
            this.PrecioUnitario,
            this.Total});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgItems.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgItems.Location = new System.Drawing.Point(5, 109);
            this.dgItems.Name = "dgItems";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Items a facturar";
            // 
            // lblTotalAcumulado
            // 
            this.lblTotalAcumulado.AutoSize = true;
            this.lblTotalAcumulado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAcumulado.Location = new System.Drawing.Point(540, 262);
            this.lblTotalAcumulado.Name = "lblTotalAcumulado";
            this.lblTotalAcumulado.Size = new System.Drawing.Size(39, 13);
            this.lblTotalAcumulado.TabIndex = 10;
            this.lblTotalAcumulado.Text = "00.00";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(505, 410);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 11;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Descuento";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(502, 284);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(77, 20);
            this.txtDescuento.TabIndex = 13;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
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
            // cmbFormaPago1
            // 
            this.cmbFormaPago1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago1.FormattingEnabled = true;
            this.cmbFormaPago1.Location = new System.Drawing.Point(12, 357);
            this.cmbFormaPago1.Name = "cmbFormaPago1";
            this.cmbFormaPago1.Size = new System.Drawing.Size(168, 21);
            this.cmbFormaPago1.TabIndex = 15;
            this.cmbFormaPago1.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago1_SelectedIndexChanged);
            // 
            // cmbFormaPago2
            // 
            this.cmbFormaPago2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago2.FormattingEnabled = true;
            this.cmbFormaPago2.Location = new System.Drawing.Point(12, 384);
            this.cmbFormaPago2.Name = "cmbFormaPago2";
            this.cmbFormaPago2.Size = new System.Drawing.Size(168, 21);
            this.cmbFormaPago2.TabIndex = 16;
            this.cmbFormaPago2.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago2_SelectedIndexChanged);
            // 
            // txtMontoPago1
            // 
            this.txtMontoPago1.Location = new System.Drawing.Point(502, 356);
            this.txtMontoPago1.Name = "txtMontoPago1";
            this.txtMontoPago1.Size = new System.Drawing.Size(77, 20);
            this.txtMontoPago1.TabIndex = 17;
            // 
            // txtMontoPago2
            // 
            this.txtMontoPago2.Location = new System.Drawing.Point(503, 383);
            this.txtMontoPago2.Name = "txtMontoPago2";
            this.txtMontoPago2.Size = new System.Drawing.Size(77, 20);
            this.txtMontoPago2.TabIndex = 18;
            // 
            // cmbTarjeta1
            // 
            this.cmbTarjeta1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjeta1.Enabled = false;
            this.cmbTarjeta1.FormattingEnabled = true;
            this.cmbTarjeta1.Location = new System.Drawing.Point(187, 356);
            this.cmbTarjeta1.Name = "cmbTarjeta1";
            this.cmbTarjeta1.Size = new System.Drawing.Size(121, 21);
            this.cmbTarjeta1.TabIndex = 19;
            // 
            // cmbTarjeta2
            // 
            this.cmbTarjeta2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarjeta2.Enabled = false;
            this.cmbTarjeta2.FormattingEnabled = true;
            this.cmbTarjeta2.Location = new System.Drawing.Point(187, 383);
            this.cmbTarjeta2.Name = "cmbTarjeta2";
            this.cmbTarjeta2.Size = new System.Drawing.Size(121, 21);
            this.cmbTarjeta2.TabIndex = 20;
            // 
            // txtNumeroMov1
            // 
            this.txtNumeroMov1.Enabled = false;
            this.txtNumeroMov1.Location = new System.Drawing.Point(315, 356);
            this.txtNumeroMov1.MaxLength = 8;
            this.txtNumeroMov1.Name = "txtNumeroMov1";
            this.txtNumeroMov1.Size = new System.Drawing.Size(78, 20);
            this.txtNumeroMov1.TabIndex = 21;
            // 
            // txtNumeroMov2
            // 
            this.txtNumeroMov2.Enabled = false;
            this.txtNumeroMov2.Location = new System.Drawing.Point(315, 385);
            this.txtNumeroMov2.MaxLength = 8;
            this.txtNumeroMov2.Name = "txtNumeroMov2";
            this.txtNumeroMov2.Size = new System.Drawing.Size(78, 20);
            this.txtNumeroMov2.TabIndex = 22;
            // 
            // dtpFechaMov1
            // 
            this.dtpFechaMov1.Enabled = false;
            this.dtpFechaMov1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaMov1.Location = new System.Drawing.Point(400, 356);
            this.dtpFechaMov1.Name = "dtpFechaMov1";
            this.dtpFechaMov1.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaMov1.TabIndex = 23;
            // 
            // dtpFechaMov2
            // 
            this.dtpFechaMov2.Enabled = false;
            this.dtpFechaMov2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaMov2.Location = new System.Drawing.Point(400, 384);
            this.dtpFechaMov2.Name = "dtpFechaMov2";
            this.dtpFechaMov2.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaMov2.TabIndex = 24;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(418, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Total acumulado: $";
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
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(134, 35);
            this.txtDomicilio.MaxLength = 80;
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(454, 20);
            this.txtDomicilio.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Domicilio";
            // 
            // frmFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 441);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpFechaMov2);
            this.Controls.Add(this.dtpFechaMov1);
            this.Controls.Add(this.txtNumeroMov2);
            this.Controls.Add(this.txtNumeroMov1);
            this.Controls.Add(this.cmbTarjeta2);
            this.Controls.Add(this.cmbTarjeta1);
            this.Controls.Add(this.txtMontoPago2);
            this.Controls.Add(this.txtMontoPago1);
            this.Controls.Add(this.cmbFormaPago2);
            this.Controls.Add(this.cmbFormaPago1);
            this.Controls.Add(this.lblTotalGeneral);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.lblTotalAcumulado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.cmbCategoriaIVA);
            this.Controls.Add(this.txtNroDocumento);
            this.Controls.Add(this.cmbTipoDocumento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtApellidoNombre);
            this.Controls.Add(this.lblApellido);
            this.Name = "frmFacturar";
            this.Text = "Facturar";
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellidoNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.ComboBox cmbCategoriaIVA;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalAcumulado;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.ComboBox cmbFormaPago1;
        private System.Windows.Forms.ComboBox cmbFormaPago2;
        private System.Windows.Forms.TextBox txtMontoPago1;
        private System.Windows.Forms.TextBox txtMontoPago2;
        private System.Windows.Forms.ComboBox cmbTarjeta1;
        private System.Windows.Forms.ComboBox cmbTarjeta2;
        private System.Windows.Forms.TextBox txtNumeroMov1;
        private System.Windows.Forms.TextBox txtNumeroMov2;
        private System.Windows.Forms.DateTimePicker dtpFechaMov1;
        private System.Windows.Forms.DateTimePicker dtpFechaMov2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label label12;
    }
}