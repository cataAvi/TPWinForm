namespace WindowsFormsApp1
{
    partial class FormInicio
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
            this.bttngestrt = new System.Windows.Forms.Button();
            this.bttnsalir = new System.Windows.Forms.Button();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bttngestrt
            // 
            this.bttngestrt.Location = new System.Drawing.Point(157, 159);
            this.bttngestrt.Name = "bttngestrt";
            this.bttngestrt.Size = new System.Drawing.Size(193, 77);
            this.bttngestrt.TabIndex = 0;
            this.bttngestrt.Text = "Gestionar Artículos";
            this.bttngestrt.UseVisualStyleBackColor = true;
            this.bttngestrt.Click += new System.EventHandler(this.bttngestrt_Click);
            // 
            // bttnsalir
            // 
            this.bttnsalir.Location = new System.Drawing.Point(157, 271);
            this.bttnsalir.Name = "bttnsalir";
            this.bttnsalir.Size = new System.Drawing.Size(193, 68);
            this.bttnsalir.TabIndex = 1;
            this.bttnsalir.Text = "Salir";
            this.bttnsalir.UseVisualStyleBackColor = true;
            this.bttnsalir.Click += new System.EventHandler(this.bttnsalir_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(150, 43);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(200, 38);
            this.labelTitulo.TabIndex = 2;
            this.labelTitulo.Text = "TP WinForm";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 426);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.bttnsalir);
            this.Controls.Add(this.bttngestrt);
            this.Name = "FormInicio";
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttngestrt;
        private System.Windows.Forms.Button bttnsalir;
        private System.Windows.Forms.Label labelTitulo;
    }
}

