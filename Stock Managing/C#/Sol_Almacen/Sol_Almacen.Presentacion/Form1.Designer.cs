namespace Sol_Almacen.Presentacion
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_articulo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_articulo = new System.Windows.Forms.TextBox();
            this.Txt_Marca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_Descripcion_um = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_lupa_um = new System.Windows.Forms.Button();
            this.Btn_lupa_ca = new System.Windows.Forms.Button();
            this.Txt_descripcion_ca = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_Stock = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Guardar = new System.Windows.Forms.Button();
            this.Btn_Cancelar = new System.Windows.Forms.Button();
            this.Btn_Nuevo = new System.Windows.Forms.Button();
            this.Btn_Actualizar = new System.Windows.Forms.Button();
            this.Btn_Eliminar = new System.Windows.Forms.Button();
            this.Btn_Reporte = new System.Windows.Forms.Button();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Buscar = new System.Windows.Forms.Button();
            this.Txt_Buscar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Pnl_um = new System.Windows.Forms.Panel();
            this.Dgv_um = new System.Windows.Forms.DataGridView();
            this.Btn_retornar_um = new System.Windows.Forms.Button();
            this.Pnl_ca = new System.Windows.Forms.Panel();
            this.Btn_retornar_ca = new System.Windows.Forms.Button();
            this.Dgv_ca = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_articulo)).BeginInit();
            this.Pnl_um.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_um)).BeginInit();
            this.Pnl_ca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ca)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_articulo
            // 
            this.dgv_articulo.AllowUserToAddRows = false;
            this.dgv_articulo.AllowUserToDeleteRows = false;
            this.dgv_articulo.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_articulo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_articulo.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_articulo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgv_articulo.ColumnHeadersHeight = 35;
            this.dgv_articulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_articulo.Location = new System.Drawing.Point(13, 195);
            this.dgv_articulo.Name = "dgv_articulo";
            this.dgv_articulo.ReadOnly = true;
            this.dgv_articulo.Size = new System.Drawing.Size(1012, 243);
            this.dgv_articulo.TabIndex = 0;
            this.dgv_articulo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_articulo_CellClick);
            this.dgv_articulo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_articulo_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Articulo:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Txt_articulo
            // 
            this.Txt_articulo.Location = new System.Drawing.Point(78, 20);
            this.Txt_articulo.Name = "Txt_articulo";
            this.Txt_articulo.ReadOnly = true;
            this.Txt_articulo.Size = new System.Drawing.Size(301, 20);
            this.Txt_articulo.TabIndex = 2;
            this.Txt_articulo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Txt_Marca
            // 
            this.Txt_Marca.Location = new System.Drawing.Point(454, 20);
            this.Txt_Marca.Name = "Txt_Marca";
            this.Txt_Marca.ReadOnly = true;
            this.Txt_Marca.Size = new System.Drawing.Size(301, 20);
            this.Txt_Marca.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(403, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Marca:";
            // 
            // Txt_Descripcion_um
            // 
            this.Txt_Descripcion_um.Location = new System.Drawing.Point(78, 68);
            this.Txt_Descripcion_um.Name = "Txt_Descripcion_um";
            this.Txt_Descripcion_um.ReadOnly = true;
            this.Txt_Descripcion_um.Size = new System.Drawing.Size(268, 20);
            this.Txt_Descripcion_um.TabIndex = 6;
            this.Txt_Descripcion_um.TextChanged += new System.EventHandler(this.Txt_Descripcion_um_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Medida:";
            // 
            // Btn_lupa_um
            // 
            this.Btn_lupa_um.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_lupa_um.Enabled = false;
            this.Btn_lupa_um.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_lupa_um.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_lupa_um.ForeColor = System.Drawing.Color.Black;
            this.Btn_lupa_um.Location = new System.Drawing.Point(352, 68);
            this.Btn_lupa_um.Name = "Btn_lupa_um";
            this.Btn_lupa_um.Size = new System.Drawing.Size(27, 25);
            this.Btn_lupa_um.TabIndex = 7;
            this.Btn_lupa_um.Text = ":::";
            this.Btn_lupa_um.UseVisualStyleBackColor = true;
            this.Btn_lupa_um.Click += new System.EventHandler(this.Btn_lupa_um_Click);
            // 
            // Btn_lupa_ca
            // 
            this.Btn_lupa_ca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_lupa_ca.Enabled = false;
            this.Btn_lupa_ca.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_lupa_ca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_lupa_ca.ForeColor = System.Drawing.Color.Black;
            this.Btn_lupa_ca.Location = new System.Drawing.Point(644, 68);
            this.Btn_lupa_ca.Name = "Btn_lupa_ca";
            this.Btn_lupa_ca.Size = new System.Drawing.Size(27, 25);
            this.Btn_lupa_ca.TabIndex = 10;
            this.Btn_lupa_ca.Text = ":::";
            this.Btn_lupa_ca.UseVisualStyleBackColor = true;
            this.Btn_lupa_ca.Click += new System.EventHandler(this.Btn_lupa_ca_Click);
            // 
            // Txt_descripcion_ca
            // 
            this.Txt_descripcion_ca.Location = new System.Drawing.Point(454, 68);
            this.Txt_descripcion_ca.Name = "Txt_descripcion_ca";
            this.Txt_descripcion_ca.ReadOnly = true;
            this.Txt_descripcion_ca.Size = new System.Drawing.Size(184, 20);
            this.Txt_descripcion_ca.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(403, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Categoria:";
            // 
            // Txt_Stock
            // 
            this.Txt_Stock.Location = new System.Drawing.Point(78, 109);
            this.Txt_Stock.Name = "Txt_Stock";
            this.Txt_Stock.ReadOnly = true;
            this.Txt_Stock.Size = new System.Drawing.Size(87, 20);
            this.Txt_Stock.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Stock:";
            // 
            // Btn_Guardar
            // 
            this.Btn_Guardar.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Guardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Guardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Guardar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Guardar.Location = new System.Drawing.Point(268, 106);
            this.Btn_Guardar.Name = "Btn_Guardar";
            this.Btn_Guardar.Size = new System.Drawing.Size(67, 25);
            this.Btn_Guardar.TabIndex = 13;
            this.Btn_Guardar.Text = "Guardar";
            this.Btn_Guardar.UseVisualStyleBackColor = false;
            this.Btn_Guardar.Visible = false;
            this.Btn_Guardar.Click += new System.EventHandler(this.Btn_Guardar_Click);
            // 
            // Btn_Cancelar
            // 
            this.Btn_Cancelar.BackColor = System.Drawing.Color.Red;
            this.Btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancelar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Cancelar.Location = new System.Drawing.Point(196, 106);
            this.Btn_Cancelar.Name = "Btn_Cancelar";
            this.Btn_Cancelar.Size = new System.Drawing.Size(65, 25);
            this.Btn_Cancelar.TabIndex = 14;
            this.Btn_Cancelar.Text = "Cancelar";
            this.Btn_Cancelar.UseVisualStyleBackColor = false;
            this.Btn_Cancelar.Visible = false;
            this.Btn_Cancelar.Click += new System.EventHandler(this.Btn_Cancelar_Click);
            // 
            // Btn_Nuevo
            // 
            this.Btn_Nuevo.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Nuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Nuevo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Nuevo.ForeColor = System.Drawing.Color.Black;
            this.Btn_Nuevo.ImageKey = "nuevo.png";
            this.Btn_Nuevo.ImageList = this.imageList1;
            this.Btn_Nuevo.Location = new System.Drawing.Point(1062, 21);
            this.Btn_Nuevo.Name = "Btn_Nuevo";
            this.Btn_Nuevo.Size = new System.Drawing.Size(73, 66);
            this.Btn_Nuevo.TabIndex = 15;
            this.Btn_Nuevo.Text = "Nuevo";
            this.Btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Nuevo.UseVisualStyleBackColor = false;
            this.Btn_Nuevo.Click += new System.EventHandler(this.Btn_Nuevo_Click);
            // 
            // Btn_Actualizar
            // 
            this.Btn_Actualizar.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Actualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Actualizar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Actualizar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Actualizar.ImageKey = "Actualizar.png";
            this.Btn_Actualizar.ImageList = this.imageList1;
            this.Btn_Actualizar.Location = new System.Drawing.Point(1062, 107);
            this.Btn_Actualizar.Name = "Btn_Actualizar";
            this.Btn_Actualizar.Size = new System.Drawing.Size(73, 66);
            this.Btn_Actualizar.TabIndex = 16;
            this.Btn_Actualizar.Text = "Actualizar";
            this.Btn_Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Actualizar.UseVisualStyleBackColor = false;
            this.Btn_Actualizar.Click += new System.EventHandler(this.Btn_Actualizar_Click);
            // 
            // Btn_Eliminar
            // 
            this.Btn_Eliminar.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Eliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Eliminar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Eliminar.ImageKey = "eliminar.png";
            this.Btn_Eliminar.ImageList = this.imageList1;
            this.Btn_Eliminar.Location = new System.Drawing.Point(1062, 195);
            this.Btn_Eliminar.Name = "Btn_Eliminar";
            this.Btn_Eliminar.Size = new System.Drawing.Size(73, 66);
            this.Btn_Eliminar.TabIndex = 17;
            this.Btn_Eliminar.Text = "Eliminar";
            this.Btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Eliminar.UseVisualStyleBackColor = false;
            this.Btn_Eliminar.Click += new System.EventHandler(this.Btn_Eliminar_Click);
            // 
            // Btn_Reporte
            // 
            this.Btn_Reporte.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Reporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Reporte.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Reporte.ForeColor = System.Drawing.Color.Black;
            this.Btn_Reporte.ImageKey = "reporte.png";
            this.Btn_Reporte.ImageList = this.imageList1;
            this.Btn_Reporte.Location = new System.Drawing.Point(1062, 285);
            this.Btn_Reporte.Name = "Btn_Reporte";
            this.Btn_Reporte.Size = new System.Drawing.Size(73, 66);
            this.Btn_Reporte.TabIndex = 18;
            this.Btn_Reporte.Text = "Reporte";
            this.Btn_Reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Reporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Reporte.UseVisualStyleBackColor = false;
            this.Btn_Reporte.Click += new System.EventHandler(this.Btn_Reporte_Click);
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Salir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Salir.ForeColor = System.Drawing.Color.Black;
            this.Btn_Salir.ImageKey = "salir.png";
            this.Btn_Salir.ImageList = this.imageList1;
            this.Btn_Salir.Location = new System.Drawing.Point(1062, 372);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(73, 66);
            this.Btn_Salir.TabIndex = 19;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Btn_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Salir.UseVisualStyleBackColor = false;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Buscar
            // 
            this.Btn_Buscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Buscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Buscar.ForeColor = System.Drawing.Color.Black;
            this.Btn_Buscar.Location = new System.Drawing.Point(268, 164);
            this.Btn_Buscar.Name = "Btn_Buscar";
            this.Btn_Buscar.Size = new System.Drawing.Size(27, 25);
            this.Btn_Buscar.TabIndex = 22;
            this.Btn_Buscar.Text = ":::";
            this.Btn_Buscar.UseVisualStyleBackColor = true;
            this.Btn_Buscar.Click += new System.EventHandler(this.Btn_Buscar_Click);
            // 
            // Txt_Buscar
            // 
            this.Txt_Buscar.Location = new System.Drawing.Point(78, 167);
            this.Txt_Buscar.Name = "Txt_Buscar";
            this.Txt_Buscar.Size = new System.Drawing.Size(184, 20);
            this.Txt_Buscar.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Buscar:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "eliminar.png");
            this.imageList1.Images.SetKeyName(1, "nuevo.png");
            this.imageList1.Images.SetKeyName(2, "reporte.png");
            this.imageList1.Images.SetKeyName(3, "salir.png");
            this.imageList1.Images.SetKeyName(4, "Actualizar.png");
            // 
            // Pnl_um
            // 
            this.Pnl_um.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_um.Controls.Add(this.Btn_retornar_um);
            this.Pnl_um.Controls.Add(this.Dgv_um);
            this.Pnl_um.Location = new System.Drawing.Point(352, 120);
            this.Pnl_um.Name = "Pnl_um";
            this.Pnl_um.Size = new System.Drawing.Size(232, 231);
            this.Pnl_um.TabIndex = 23;
            this.Pnl_um.Visible = false;
            // 
            // Dgv_um
            // 
            this.Dgv_um.AllowUserToAddRows = false;
            this.Dgv_um.AllowUserToDeleteRows = false;
            this.Dgv_um.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv_um.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_um.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Dgv_um.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.Dgv_um.ColumnHeadersHeight = 35;
            this.Dgv_um.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_um.Location = new System.Drawing.Point(3, 3);
            this.Dgv_um.Name = "Dgv_um";
            this.Dgv_um.ReadOnly = true;
            this.Dgv_um.Size = new System.Drawing.Size(226, 200);
            this.Dgv_um.TabIndex = 1;
            this.Dgv_um.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_um_CellContentClick);
            this.Dgv_um.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_um_CellDoubleClick);
            // 
            // Btn_retornar_um
            // 
            this.Btn_retornar_um.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_retornar_um.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_retornar_um.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_retornar_um.ForeColor = System.Drawing.Color.Black;
            this.Btn_retornar_um.Location = new System.Drawing.Point(3, 203);
            this.Btn_retornar_um.Name = "Btn_retornar_um";
            this.Btn_retornar_um.Size = new System.Drawing.Size(226, 25);
            this.Btn_retornar_um.TabIndex = 24;
            this.Btn_retornar_um.Text = "Retornar";
            this.Btn_retornar_um.UseVisualStyleBackColor = true;
            this.Btn_retornar_um.Click += new System.EventHandler(this.Btn_retornar_um_Click);
            // 
            // Pnl_ca
            // 
            this.Pnl_ca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_ca.Controls.Add(this.Btn_retornar_ca);
            this.Pnl_ca.Controls.Add(this.Dgv_ca);
            this.Pnl_ca.Location = new System.Drawing.Point(644, 123);
            this.Pnl_ca.Name = "Pnl_ca";
            this.Pnl_ca.Size = new System.Drawing.Size(232, 231);
            this.Pnl_ca.TabIndex = 25;
            this.Pnl_ca.Visible = false;
            // 
            // Btn_retornar_ca
            // 
            this.Btn_retornar_ca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_retornar_ca.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_retornar_ca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_retornar_ca.ForeColor = System.Drawing.Color.Black;
            this.Btn_retornar_ca.Location = new System.Drawing.Point(3, 203);
            this.Btn_retornar_ca.Name = "Btn_retornar_ca";
            this.Btn_retornar_ca.Size = new System.Drawing.Size(226, 25);
            this.Btn_retornar_ca.TabIndex = 24;
            this.Btn_retornar_ca.Text = "Retornar";
            this.Btn_retornar_ca.UseVisualStyleBackColor = true;
            this.Btn_retornar_ca.Click += new System.EventHandler(this.Btn_retornar_ca_Click);
            // 
            // Dgv_ca
            // 
            this.Dgv_ca.AllowUserToAddRows = false;
            this.Dgv_ca.AllowUserToDeleteRows = false;
            this.Dgv_ca.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Dgv_ca.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv_ca.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.Dgv_ca.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.Dgv_ca.ColumnHeadersHeight = 35;
            this.Dgv_ca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_ca.Location = new System.Drawing.Point(3, 3);
            this.Dgv_ca.Name = "Dgv_ca";
            this.Dgv_ca.ReadOnly = true;
            this.Dgv_ca.Size = new System.Drawing.Size(226, 200);
            this.Dgv_ca.TabIndex = 1;
            this.Dgv_ca.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_ca_CellDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1160, 450);
            this.Controls.Add(this.Pnl_ca);
            this.Controls.Add(this.Pnl_um);
            this.Controls.Add(this.Btn_Buscar);
            this.Controls.Add(this.Txt_Buscar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Reporte);
            this.Controls.Add(this.Btn_Eliminar);
            this.Controls.Add(this.Btn_Actualizar);
            this.Controls.Add(this.Btn_Nuevo);
            this.Controls.Add(this.Btn_Cancelar);
            this.Controls.Add(this.Btn_Guardar);
            this.Controls.Add(this.Txt_Stock);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btn_lupa_ca);
            this.Controls.Add(this.Txt_descripcion_ca);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_lupa_um);
            this.Controls.Add(this.Txt_Descripcion_um);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_Marca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_articulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_articulo);
            this.Name = "Form1";
            this.Text = "Frm_Articulos";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_articulo)).EndInit();
            this.Pnl_um.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_um)).EndInit();
            this.Pnl_ca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ca)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_articulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_articulo;
        private System.Windows.Forms.TextBox Txt_Marca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_Descripcion_um;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_lupa_um;
        private System.Windows.Forms.Button Btn_lupa_ca;
        private System.Windows.Forms.TextBox Txt_descripcion_ca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_Stock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Guardar;
        private System.Windows.Forms.Button Btn_Cancelar;
        private System.Windows.Forms.Button Btn_Nuevo;
        private System.Windows.Forms.Button Btn_Actualizar;
        private System.Windows.Forms.Button Btn_Eliminar;
        private System.Windows.Forms.Button Btn_Reporte;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Buscar;
        private System.Windows.Forms.TextBox Txt_Buscar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel Pnl_um;
        private System.Windows.Forms.Button Btn_retornar_um;
        private System.Windows.Forms.DataGridView Dgv_um;
        private System.Windows.Forms.Panel Pnl_ca;
        private System.Windows.Forms.Button Btn_retornar_ca;
        private System.Windows.Forms.DataGridView Dgv_ca;
    }
}

