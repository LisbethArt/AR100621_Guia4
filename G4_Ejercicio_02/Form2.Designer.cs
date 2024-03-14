namespace G4_Ejercicio_02
{
    partial class Form2
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
            this.dgvNotas = new System.Windows.Forms.DataGridView();
            this.cmbCarnet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMateriaNotas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNota4 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtPromedio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtNota3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNota2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNota1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNotas
            // 
            this.dgvNotas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvNotas.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotas.Location = new System.Drawing.Point(106, 391);
            this.dgvNotas.Name = "dgvNotas";
            this.dgvNotas.RowHeadersWidth = 51;
            this.dgvNotas.RowTemplate.Height = 24;
            this.dgvNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotas.Size = new System.Drawing.Size(960, 185);
            this.dgvNotas.TabIndex = 112;
            this.dgvNotas.DoubleClick += new System.EventHandler(this.dgvNotas_DoubleClick);
            // 
            // cmbCarnet
            // 
            this.cmbCarnet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCarnet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarnet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCarnet.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.cmbCarnet.FormattingEnabled = true;
            this.cmbCarnet.Location = new System.Drawing.Point(375, 89);
            this.cmbCarnet.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCarnet.Name = "cmbCarnet";
            this.cmbCarnet.Size = new System.Drawing.Size(312, 31);
            this.cmbCarnet.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(118, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 23);
            this.label3.TabIndex = 110;
            this.label3.Text = "Carnet del Alumno";
            // 
            // cmbMateriaNotas
            // 
            this.cmbMateriaNotas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbMateriaNotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateriaNotas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMateriaNotas.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.cmbMateriaNotas.FormattingEnabled = true;
            this.cmbMateriaNotas.Location = new System.Drawing.Point(375, 34);
            this.cmbMateriaNotas.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMateriaNotas.Name = "cmbMateriaNotas";
            this.cmbMateriaNotas.Size = new System.Drawing.Size(691, 31);
            this.cmbMateriaNotas.TabIndex = 109;
            this.cmbMateriaNotas.SelectedIndexChanged += new System.EventHandler(this.cmbMateriaNotas_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(118, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 23);
            this.label2.TabIndex = 108;
            this.label2.Text = "Materia a Ingresar Notas";
            // 
            // txtNota4
            // 
            this.txtNota4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNota4.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtNota4.Location = new System.Drawing.Point(864, 186);
            this.txtNota4.Name = "txtNota4";
            this.txtNota4.Size = new System.Drawing.Size(98, 32);
            this.txtNota4.TabIndex = 107;
            this.txtNota4.Leave += new System.EventHandler(this.txtNota4_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(833, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 23);
            this.label1.TabIndex = 106;
            this.label1.Text = "Nota Periodo 4";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnLimpiar.Location = new System.Drawing.Point(603, 314);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(198, 47);
            this.btnLimpiar.TabIndex = 105;
            this.btnLimpiar.Text = "Limpiar Campos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtPromedio
            // 
            this.txtPromedio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPromedio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPromedio.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtPromedio.Location = new System.Drawing.Point(523, 260);
            this.txtPromedio.Name = "txtPromedio";
            this.txtPromedio.ReadOnly = true;
            this.txtPromedio.Size = new System.Drawing.Size(98, 32);
            this.txtPromedio.TabIndex = 104;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label8.Location = new System.Drawing.Point(521, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 23);
            this.label8.TabIndex = 103;
            this.label8.Text = "Promedio";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalir.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnSalir.Location = new System.Drawing.Point(839, 314);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(198, 47);
            this.btnSalir.TabIndex = 102;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtNota3
            // 
            this.txtNota3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNota3.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtNota3.Location = new System.Drawing.Point(655, 186);
            this.txtNota3.Name = "txtNota3";
            this.txtNota3.Size = new System.Drawing.Size(98, 32);
            this.txtNota3.TabIndex = 101;
            this.txtNota3.Leave += new System.EventHandler(this.txtNota3_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label6.Location = new System.Drawing.Point(622, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 23);
            this.label6.TabIndex = 100;
            this.label6.Text = "Nota Periodo 3";
            // 
            // txtNota2
            // 
            this.txtNota2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNota2.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtNota2.Location = new System.Drawing.Point(439, 186);
            this.txtNota2.Name = "txtNota2";
            this.txtNota2.Size = new System.Drawing.Size(98, 32);
            this.txtNota2.TabIndex = 99;
            this.txtNota2.Leave += new System.EventHandler(this.txtNota2_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(411, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 23);
            this.label5.TabIndex = 98;
            this.label5.Text = "Nota Periodo 2";
            // 
            // txtNota1
            // 
            this.txtNota1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNota1.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtNota1.Location = new System.Drawing.Point(233, 186);
            this.txtNota1.Name = "txtNota1";
            this.txtNota1.Size = new System.Drawing.Size(98, 32);
            this.txtNota1.TabIndex = 97;
            this.txtNota1.Leave += new System.EventHandler(this.txtNota1_Leave);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.label7.Location = new System.Drawing.Point(207, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 23);
            this.label7.TabIndex = 96;
            this.label7.Text = "Nota Periodo 1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnGuardar.Location = new System.Drawing.Point(133, 314);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(198, 47);
            this.btnGuardar.TabIndex = 95;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminar.BackColor = System.Drawing.Color.CadetBlue;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnEliminar.Location = new System.Drawing.Point(368, 314);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(198, 47);
            this.btnEliminar.TabIndex = 94;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1173, 610);
            this.Controls.Add(this.dgvNotas);
            this.Controls.Add(this.cmbCarnet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMateriaNotas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNota4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.txtPromedio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtNota3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNota2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNota1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNotas;
        private System.Windows.Forms.ComboBox cmbCarnet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMateriaNotas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNota4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtPromedio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtNota3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNota2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNota1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
    }
}