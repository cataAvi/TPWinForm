
namespace WindowsFormsApp1
{
    partial class sumarImagen
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbURLImag = new System.Windows.Forms.TextBox();
            this.btCargar = new System.Windows.Forms.Button();
            this.btSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL Imagen:";
            // 
            // tbURLImag
            // 
            this.tbURLImag.Location = new System.Drawing.Point(134, 93);
            this.tbURLImag.Name = "tbURLImag";
            this.tbURLImag.Size = new System.Drawing.Size(194, 22);
            this.tbURLImag.TabIndex = 1;
            // 
            // btCargar
            // 
            this.btCargar.Location = new System.Drawing.Point(134, 158);
            this.btCargar.Name = "btCargar";
            this.btCargar.Size = new System.Drawing.Size(90, 32);
            this.btCargar.TabIndex = 2;
            this.btCargar.Text = "Cargar";
            this.btCargar.UseVisualStyleBackColor = true;
            this.btCargar.Click += new System.EventHandler(this.btCargar_Click);
            // 
            // btSalir
            // 
            this.btSalir.Location = new System.Drawing.Point(251, 158);
            this.btSalir.Name = "btSalir";
            this.btSalir.Size = new System.Drawing.Size(90, 32);
            this.btSalir.TabIndex = 3;
            this.btSalir.Text = "Salir";
            this.btSalir.UseVisualStyleBackColor = true;
            this.btSalir.Click += new System.EventHandler(this.btSalir_Click);
            // 
            // sumarImagen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 260);
            this.Controls.Add(this.btSalir);
            this.Controls.Add(this.btCargar);
            this.Controls.Add(this.tbURLImag);
            this.Controls.Add(this.label1);
            this.Name = "sumarImagen";
            this.Text = "sumarImagen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbURLImag;
        private System.Windows.Forms.Button btCargar;
        private System.Windows.Forms.Button btSalir;
    }
}