namespace Punto_de_Venta.Forms
{
    partial class frmFewProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvfewProducts = new System.Windows.Forms.DataGridView();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductoID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoBarraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProductoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioPorUnidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadesEnAlmacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suplidorNombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDeListaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDeCompraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvfewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(647, 50);
            this.panel2.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft NeoGothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(570, 36);
            this.label6.TabIndex = 0;
            this.label6.Text = "Existen 0 producto/s escaso/s en el Inventario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnGuardarCambios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 58);
            this.panel1.TabIndex = 16;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Location = new System.Drawing.Point(11, 9);
            this.btnGuardarCambios.MaximumSize = new System.Drawing.Size(110, 36);
            this.btnGuardarCambios.MinimumSize = new System.Drawing.Size(110, 36);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(110, 36);
            this.btnGuardarCambios.TabIndex = 10;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvfewProducts);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(647, 224);
            this.panel3.TabIndex = 17;
            // 
            // dgvfewProducts
            // 
            this.dgvfewProducts.AllowUserToAddRows = false;
            this.dgvfewProducts.AllowUserToDeleteRows = false;
            this.dgvfewProducts.AutoGenerateColumns = false;
            this.dgvfewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvfewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductoID,
            this.codigoBarraDataGridViewTextBoxColumn,
            this.nombreProductoDataGridViewTextBoxColumn,
            this.marcaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.precioPorUnidadDataGridViewTextBoxColumn,
            this.unidadesEnAlmacenDataGridViewTextBoxColumn,
            this.suplidorNombreDataGridViewTextBoxColumn,
            this.precioDeListaDataGridViewTextBoxColumn,
            this.fechaDeCompraDataGridViewTextBoxColumn});
            this.dgvfewProducts.DataSource = this.productoBindingSource;
            this.dgvfewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvfewProducts.Location = new System.Drawing.Point(0, 0);
            this.dgvfewProducts.Name = "dgvfewProducts";
            this.dgvfewProducts.Size = new System.Drawing.Size(645, 222);
            this.dgvfewProducts.TabIndex = 1;
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataSource = typeof(PuntoDeVenta.Library.Entity_Classes.Producto);
            // 
            // ProductoID
            // 
            this.ProductoID.DataPropertyName = "ProductoID";
            this.ProductoID.HeaderText = "ProductoID";
            this.ProductoID.Name = "ProductoID";
            this.ProductoID.ReadOnly = true;
            this.ProductoID.Visible = false;
            // 
            // codigoBarraDataGridViewTextBoxColumn
            // 
            this.codigoBarraDataGridViewTextBoxColumn.DataPropertyName = "CodigoBarra";
            this.codigoBarraDataGridViewTextBoxColumn.HeaderText = "CodigoBarra";
            this.codigoBarraDataGridViewTextBoxColumn.Name = "codigoBarraDataGridViewTextBoxColumn";
            this.codigoBarraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreProductoDataGridViewTextBoxColumn
            // 
            this.nombreProductoDataGridViewTextBoxColumn.DataPropertyName = "NombreProducto";
            this.nombreProductoDataGridViewTextBoxColumn.HeaderText = "NombreProducto";
            this.nombreProductoDataGridViewTextBoxColumn.Name = "nombreProductoDataGridViewTextBoxColumn";
            this.nombreProductoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            this.marcaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioPorUnidadDataGridViewTextBoxColumn
            // 
            this.precioPorUnidadDataGridViewTextBoxColumn.DataPropertyName = "PrecioPorUnidad";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.precioPorUnidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.precioPorUnidadDataGridViewTextBoxColumn.HeaderText = "PrecioPorUnidad";
            this.precioPorUnidadDataGridViewTextBoxColumn.Name = "precioPorUnidadDataGridViewTextBoxColumn";
            this.precioPorUnidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadesEnAlmacenDataGridViewTextBoxColumn
            // 
            this.unidadesEnAlmacenDataGridViewTextBoxColumn.DataPropertyName = "UnidadesEnAlmacen";
            this.unidadesEnAlmacenDataGridViewTextBoxColumn.HeaderText = "UnidadesEnAlmacen";
            this.unidadesEnAlmacenDataGridViewTextBoxColumn.Name = "unidadesEnAlmacenDataGridViewTextBoxColumn";
            // 
            // suplidorNombreDataGridViewTextBoxColumn
            // 
            this.suplidorNombreDataGridViewTextBoxColumn.DataPropertyName = "SuplidorNombre";
            this.suplidorNombreDataGridViewTextBoxColumn.HeaderText = "SuplidorNombre";
            this.suplidorNombreDataGridViewTextBoxColumn.Name = "suplidorNombreDataGridViewTextBoxColumn";
            this.suplidorNombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // precioDeListaDataGridViewTextBoxColumn
            // 
            this.precioDeListaDataGridViewTextBoxColumn.DataPropertyName = "PrecioDeLista";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.precioDeListaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.precioDeListaDataGridViewTextBoxColumn.HeaderText = "PrecioDeLista";
            this.precioDeListaDataGridViewTextBoxColumn.Name = "precioDeListaDataGridViewTextBoxColumn";
            this.precioDeListaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaDeCompraDataGridViewTextBoxColumn
            // 
            this.fechaDeCompraDataGridViewTextBoxColumn.DataPropertyName = "FechaDeCompra";
            this.fechaDeCompraDataGridViewTextBoxColumn.HeaderText = "FechaDeCompra";
            this.fechaDeCompraDataGridViewTextBoxColumn.Name = "fechaDeCompraDataGridViewTextBoxColumn";
            this.fechaDeCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmFewProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 332);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFewProducts";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Productos Escasos";
            this.Load += new System.EventHandler(this.frmFewProducts_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvfewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvfewProducts;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoID;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoBarraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioPorUnidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadesEnAlmacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suplidorNombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDeListaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDeCompraDataGridViewTextBoxColumn;
    }
}