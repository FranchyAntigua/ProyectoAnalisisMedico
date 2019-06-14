namespace ProyectoAnalisisMedico.UI.Registro
{
    partial class rTipoAnalisis
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
            this.IdnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.Descripcion = new System.Windows.Forms.Label();
            this.TipoId = new System.Windows.Forms.Label();
            this.DescripciontextBox = new System.Windows.Forms.TextBox();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IdnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // IdnumericUpDown
            // 
            this.IdnumericUpDown.Location = new System.Drawing.Point(61, 18);
            this.IdnumericUpDown.Name = "IdnumericUpDown";
            this.IdnumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.IdnumericUpDown.TabIndex = 111;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSize = true;
            this.Descripcion.Location = new System.Drawing.Point(18, 53);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(63, 13);
            this.Descripcion.TabIndex = 110;
            this.Descripcion.Text = "Descripcion";
            // 
            // TipoId
            // 
            this.TipoId.AutoSize = true;
            this.TipoId.Location = new System.Drawing.Point(18, 20);
            this.TipoId.Name = "TipoId";
            this.TipoId.Size = new System.Drawing.Size(40, 13);
            this.TipoId.TabIndex = 109;
            this.TipoId.Text = "Tipo Id";
            // 
            // DescripciontextBox
            // 
            this.DescripciontextBox.Location = new System.Drawing.Point(85, 50);
            this.DescripciontextBox.Name = "DescripciontextBox";
            this.DescripciontextBox.Size = new System.Drawing.Size(140, 20);
            this.DescripciontextBox.TabIndex = 108;
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Image = global::ProyectoAnalisisMedico.Properties.Resources.icons8_eliminar_26;
            this.Eliminarbutton.Location = new System.Drawing.Point(168, 87);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(57, 49);
            this.Eliminarbutton.TabIndex = 115;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Image = global::ProyectoAnalisisMedico.Properties.Resources.icons8_añadir_48_1_;
            this.Nuevobutton.Location = new System.Drawing.Point(24, 87);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(57, 49);
            this.Nuevobutton.TabIndex = 114;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Image = global::ProyectoAnalisisMedico.Properties.Resources.icons8_guardar_48;
            this.Guardarbutton.Location = new System.Drawing.Point(96, 87);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(57, 49);
            this.Guardarbutton.TabIndex = 113;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::ProyectoAnalisisMedico.Properties.Resources.icons8_búsqueda_24;
            this.Buscarbutton.Location = new System.Drawing.Point(127, 12);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(47, 28);
            this.Buscarbutton.TabIndex = 112;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // rTipoAnalisis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 154);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.IdnumericUpDown);
            this.Controls.Add(this.Descripcion);
            this.Controls.Add(this.TipoId);
            this.Controls.Add(this.DescripciontextBox);
            this.Name = "rTipoAnalisis";
            this.Text = "rTipoAnalisis";
            ((System.ComponentModel.ISupportInitialize)(this.IdnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.NumericUpDown IdnumericUpDown;
        private System.Windows.Forms.Label Descripcion;
        private System.Windows.Forms.Label TipoId;
        private System.Windows.Forms.TextBox DescripciontextBox;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
    }
}