namespace Punto_de_Venta.Forms
{
    partial class frmCuentasPorPagar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ProductGridView = new System.Windows.Forms.DataGridView();
            this.conceptoDeudaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoAPagarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDeudorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDeudaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDeudaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuentaXPagarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeudores = new System.Windows.Forms.Button();
            this.cmbDeudores = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaXPagarBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductGridView
            // 
            this.ProductGridView.AllowUserToAddRows = false;
            this.ProductGridView.AllowUserToDeleteRows = false;
            this.ProductGridView.AllowUserToOrderColumns = true;
            this.ProductGridView.AutoGenerateColumns = false;
            this.ProductGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.conceptoDeudaDataGridViewTextBoxColumn,
            this.montoAPagarDataGridViewTextBoxColumn,
            this.nombreDeudorDataGridViewTextBoxColumn,
            this.estadoDeudaDataGridViewTextBoxColumn,
            this.fechaDeudaDataGridViewTextBoxColumn});
            this.ProductGridView.DataSource = this.cuentaXPagarBindingSource;
            this.ProductGridView.Location = new System.Drawing.Point(3, 3);
            this.ProductGridView.Name = "ProductGridView";
            this.ProductGridView.ReadOnly = true;
            this.ProductGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductGridView.Size = new System.Drawing.Size(520, 553);
            this.ProductGridView.TabIndex = 2;
            // 
            // conceptoDeudaDataGridViewTextBoxColumn
            // 
            this.conceptoDeudaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.conceptoDeudaDataGridViewTextBoxColumn.DataPropertyName = "ConceptoDeuda";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conceptoDeudaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.conceptoDeudaDataGridViewTextBoxColumn.HeaderText = "Concepto de Deuda";
            this.conceptoDeudaDataGridViewTextBoxColumn.Name = "conceptoDeudaDataGridViewTextBoxColumn";
            this.conceptoDeudaDataGridViewTextBoxColumn.ReadOnly = true;
            this.conceptoDeudaDataGridViewTextBoxColumn.Width = 88;
            // 
            // montoAPagarDataGridViewTextBoxColumn
            // 
            this.montoAPagarDataGridViewTextBoxColumn.DataPropertyName = "MontoAPagar";
            dataGridViewCellStyle2.Format = "N2";
            this.montoAPagarDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.montoAPagarDataGridViewTextBoxColumn.HeaderText = "Monto a Pagar";
            this.montoAPagarDataGridViewTextBoxColumn.Name = "montoAPagarDataGridViewTextBoxColumn";
            this.montoAPagarDataGridViewTextBoxColumn.ReadOnly = true;
            this.montoAPagarDataGridViewTextBoxColumn.Width = 70;
            // 
            // nombreDeudorDataGridViewTextBoxColumn
            // 
            this.nombreDeudorDataGridViewTextBoxColumn.DataPropertyName = "NombreDeudor";
            this.nombreDeudorDataGridViewTextBoxColumn.HeaderText = "Nombre de Deudor";
            this.nombreDeudorDataGridViewTextBoxColumn.Name = "nombreDeudorDataGridViewTextBoxColumn";
            this.nombreDeudorDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDeudorDataGridViewTextBoxColumn.Width = 114;
            // 
            // estadoDeudaDataGridViewTextBoxColumn
            // 
            this.estadoDeudaDataGridViewTextBoxColumn.DataPropertyName = "EstadoDeuda";
            this.estadoDeudaDataGridViewTextBoxColumn.HeaderText = "Estado de Deuda";
            this.estadoDeudaDataGridViewTextBoxColumn.Name = "estadoDeudaDataGridViewTextBoxColumn";
            this.estadoDeudaDataGridViewTextBoxColumn.ReadOnly = true;
            this.estadoDeudaDataGridViewTextBoxColumn.Width = 105;
            // 
            // fechaDeudaDataGridViewTextBoxColumn
            // 
            this.fechaDeudaDataGridViewTextBoxColumn.DataPropertyName = "FechaDeuda";
            this.fechaDeudaDataGridViewTextBoxColumn.HeaderText = "Fecha Inicio de Deuda";
            this.fechaDeudaDataGridViewTextBoxColumn.Name = "fechaDeudaDataGridViewTextBoxColumn";
            this.fechaDeudaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDeudaDataGridViewTextBoxColumn.Width = 98;
            // 
            // cuentaXPagarBindingSource
            // 
            this.cuentaXPagarBindingSource.DataSource = typeof(PuntoDeVenta.Library.Entity_Classes.CuentaXPagar);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Concepto de Deuda:";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(12, 31);
            this.txtConcepto.Multiline = true;
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(223, 44);
            this.txtConcepto.TabIndex = 4;
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(12, 105);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(223, 22);
            this.txtMonto.TabIndex = 5;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Monto a Pagar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Estado de Deuda:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(12, 164);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(223, 23);
            this.cmbEstado.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDeudores);
            this.panel1.Controls.Add(this.cmbDeudores);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbEstado);
            this.panel1.Controls.Add(this.txtConcepto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtMonto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 561);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnDeudores
            // 
            this.btnDeudores.Font = new System.Drawing.Font("Microsoft NeoGothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeudores.Location = new System.Drawing.Point(12, 393);
            this.btnDeudores.Name = "btnDeudores";
            this.btnDeudores.Size = new System.Drawing.Size(220, 66);
            this.btnDeudores.TabIndex = 13;
            this.btnDeudores.Text = "Deudores";
            this.btnDeudores.UseVisualStyleBackColor = true;
            this.btnDeudores.Click += new System.EventHandler(this.btnDeudores_Click);
            // 
            // cmbDeudores
            // 
            this.cmbDeudores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeudores.FormattingEnabled = true;
            this.cmbDeudores.Location = new System.Drawing.Point(12, 224);
            this.cmbDeudores.Name = "cmbDeudores";
            this.cmbDeudores.Size = new System.Drawing.Size(223, 23);
            this.cmbDeudores.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Nombre del Deudor:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft NeoGothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(12, 476);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(220, 66);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Atrás";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft NeoGothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(12, 310);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(220, 66);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ProductGridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(242, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 561);
            this.panel2.TabIndex = 10;
            // 
            // frmCuentasPorPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(771, 561);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft NeoGothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(787, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(787, 600);
            this.Name = "frmCuentasPorPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas por Pagar";
            this.Load += new System.EventHandler(this.CuentasPorPagar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuentaXPagarBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ProductGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbDeudores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnDeudores;
        private System.Windows.Forms.BindingSource cuentaXPagarBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn conceptoDeudaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoAPagarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDeudorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDeudaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDeudaDataGridViewTextBoxColumn;
    }
}