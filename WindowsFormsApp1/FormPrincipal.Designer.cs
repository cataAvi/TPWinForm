
namespace WindowsFormsApp1
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.comboBoxCriterio = new System.Windows.Forms.ComboBox();
            this.comboBoxCampo = new System.Windows.Forms.ComboBox();
            this.textBoxFiltro = new System.Windows.Forms.TextBox();
            this.labelCriterio = new System.Windows.Forms.Label();
            this.labelCampo = new System.Windows.Forms.Label();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonModificiar = new System.Windows.Forms.Button();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.pictureBoxArticulo = new System.Windows.Forms.PictureBox();
            this.dataGridViewArticuloBD = new System.Windows.Forms.DataGridView();
            this.btnListar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticuloBD)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBuscar.BackgroundImage")));
            this.buttonBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBuscar.Location = new System.Drawing.Point(600, 6);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(37, 29);
            this.buttonBuscar.TabIndex = 21;
            this.buttonBuscar.UseVisualStyleBackColor = true;
            // 
            // comboBoxCriterio
            // 
            this.comboBoxCriterio.FormattingEnabled = true;
            this.comboBoxCriterio.Location = new System.Drawing.Point(288, 8);
            this.comboBoxCriterio.Name = "comboBoxCriterio";
            this.comboBoxCriterio.Size = new System.Drawing.Size(139, 24);
            this.comboBoxCriterio.TabIndex = 20;
            // 
            // comboBoxCampo
            // 
            this.comboBoxCampo.FormattingEnabled = true;
            this.comboBoxCampo.Location = new System.Drawing.Point(80, 9);
            this.comboBoxCampo.Name = "comboBoxCampo";
            this.comboBoxCampo.Size = new System.Drawing.Size(139, 24);
            this.comboBoxCampo.TabIndex = 19;
            // 
            // textBoxFiltro
            // 
            this.textBoxFiltro.Location = new System.Drawing.Point(458, 9);
            this.textBoxFiltro.Name = "textBoxFiltro";
            this.textBoxFiltro.Size = new System.Drawing.Size(125, 22);
            this.textBoxFiltro.TabIndex = 18;
            // 
            // labelCriterio
            // 
            this.labelCriterio.AutoSize = true;
            this.labelCriterio.Location = new System.Drawing.Point(225, 12);
            this.labelCriterio.Name = "labelCriterio";
            this.labelCriterio.Size = new System.Drawing.Size(57, 17);
            this.labelCriterio.TabIndex = 17;
            this.labelCriterio.Text = "Criterio:";
            // 
            // labelCampo
            // 
            this.labelCampo.AutoSize = true;
            this.labelCampo.Location = new System.Drawing.Point(18, 12);
            this.labelCampo.Name = "labelCampo";
            this.labelCampo.Size = new System.Drawing.Size(56, 17);
            this.labelCampo.TabIndex = 16;
            this.labelCampo.Text = "Campo:";
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(80, 442);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(259, 40);
            this.buttonEliminar.TabIndex = 15;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            // 
            // buttonModificiar
            // 
            this.buttonModificiar.Location = new System.Drawing.Point(80, 396);
            this.buttonModificiar.Name = "buttonModificiar";
            this.buttonModificiar.Size = new System.Drawing.Size(259, 40);
            this.buttonModificiar.TabIndex = 14;
            this.buttonModificiar.Text = "Modificar";
            this.buttonModificiar.UseVisualStyleBackColor = true;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(80, 350);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(259, 40);
            this.buttonAgregar.TabIndex = 13;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            // 
            // pictureBoxArticulo
            // 
            this.pictureBoxArticulo.Location = new System.Drawing.Point(416, 329);
            this.pictureBoxArticulo.Name = "pictureBoxArticulo";
            this.pictureBoxArticulo.Size = new System.Drawing.Size(483, 237);
            this.pictureBoxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxArticulo.TabIndex = 12;
            this.pictureBoxArticulo.TabStop = false;
            // 
            // dataGridViewArticuloBD
            // 
            this.dataGridViewArticuloBD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewArticuloBD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArticuloBD.Location = new System.Drawing.Point(12, 57);
            this.dataGridViewArticuloBD.Name = "dataGridViewArticuloBD";
            this.dataGridViewArticuloBD.RowHeadersWidth = 51;
            this.dataGridViewArticuloBD.RowTemplate.Height = 24;
            this.dataGridViewArticuloBD.Size = new System.Drawing.Size(961, 244);
            this.dataGridViewArticuloBD.TabIndex = 11;
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(80, 488);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(259, 52);
            this.btnListar.TabIndex = 22;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 610);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.comboBoxCriterio);
            this.Controls.Add(this.comboBoxCampo);
            this.Controls.Add(this.textBoxFiltro);
            this.Controls.Add(this.labelCriterio);
            this.Controls.Add(this.labelCampo);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonModificiar);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.pictureBoxArticulo);
            this.Controls.Add(this.dataGridViewArticuloBD);
            this.Name = "FormPrincipal";
            this.Text = "Administracion de Articulos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticuloBD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.ComboBox comboBoxCriterio;
        private System.Windows.Forms.ComboBox comboBoxCampo;
        private System.Windows.Forms.TextBox textBoxFiltro;
        private System.Windows.Forms.Label labelCriterio;
        private System.Windows.Forms.Label labelCampo;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonModificiar;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.PictureBox pictureBoxArticulo;
        private System.Windows.Forms.DataGridView dataGridViewArticuloBD;
        private System.Windows.Forms.Button btnListar;
    }
}