namespace TP2_Espinola
{
    partial class Principal
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
            this.dgv_listaArticulos = new System.Windows.Forms.DataGridView();
            this.btn_filtrar = new System.Windows.Forms.Button();
            this.lp_txtApellido = new System.Windows.Forms.TextBox();
            this.lp_cbColorFav = new System.Windows.Forms.ComboBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_modificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listaArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_listaArticulos
            // 
            this.dgv_listaArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_listaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_listaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv_listaArticulos.Location = new System.Drawing.Point(11, 99);
            this.dgv_listaArticulos.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_listaArticulos.Name = "dgv_listaArticulos";
            this.dgv_listaArticulos.RowTemplate.Height = 28;
            this.dgv_listaArticulos.Size = new System.Drawing.Size(778, 340);
            this.dgv_listaArticulos.TabIndex = 43;
            // 
            // btn_filtrar
            // 
            this.btn_filtrar.Location = new System.Drawing.Point(369, 61);
            this.btn_filtrar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_filtrar.Name = "btn_filtrar";
            this.btn_filtrar.Size = new System.Drawing.Size(102, 34);
            this.btn_filtrar.TabIndex = 65;
            this.btn_filtrar.Text = "Filtrar";
            this.btn_filtrar.UseVisualStyleBackColor = true;
            // 
            // lp_txtApellido
            // 
            this.lp_txtApellido.Location = new System.Drawing.Point(224, 17);
            this.lp_txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.lp_txtApellido.Name = "lp_txtApellido";
            this.lp_txtApellido.Size = new System.Drawing.Size(153, 20);
            this.lp_txtApellido.TabIndex = 64;
            // 
            // lp_cbColorFav
            // 
            this.lp_cbColorFav.FormattingEnabled = true;
            this.lp_cbColorFav.Items.AddRange(new object[] {
            "Azul",
            "Azul Cielo",
            "Azul Marino",
            "Azul Celeste",
            "Azul Acero",
            "Azul Cian",
            "Azul Klein"});
            this.lp_cbColorFav.Location = new System.Drawing.Point(11, 16);
            this.lp_cbColorFav.Margin = new System.Windows.Forms.Padding(2);
            this.lp_cbColorFav.Name = "lp_cbColorFav";
            this.lp_cbColorFav.Size = new System.Drawing.Size(188, 21);
            this.lp_cbColorFav.TabIndex = 66;
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(581, 61);
            this.btn_agregar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(102, 34);
            this.btn_agregar.TabIndex = 67;
            this.btn_agregar.Text = "Agregar Nuevo";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(687, 61);
            this.btn_eliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(102, 34);
            this.btn_eliminar.TabIndex = 68;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            // 
            // btn_modificar
            // 
            this.btn_modificar.Location = new System.Drawing.Point(475, 61);
            this.btn_modificar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_modificar.Name = "btn_modificar";
            this.btn_modificar.Size = new System.Drawing.Size(102, 34);
            this.btn_modificar.TabIndex = 69;
            this.btn_modificar.Text = "Modificar";
            this.btn_modificar.UseVisualStyleBackColor = true;
            this.btn_modificar.Click += new System.EventHandler(this.btn_modificar_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_modificar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.lp_cbColorFav);
            this.Controls.Add(this.btn_filtrar);
            this.Controls.Add(this.lp_txtApellido);
            this.Controls.Add(this.dgv_listaArticulos);
            this.Name = "Principal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_listaArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView dgv_listaArticulos;
        private System.Windows.Forms.Button btn_filtrar;
        private System.Windows.Forms.TextBox lp_txtApellido;
        private System.Windows.Forms.ComboBox lp_cbColorFav;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_modificar;
    }
}

