namespace WindowsFormsApp1
{
    partial class title1
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bttngestrt
            // 
            this.bttngestrt.Location = new System.Drawing.Point(202, 174);
            this.bttngestrt.Name = "bttngestrt";
            this.bttngestrt.Size = new System.Drawing.Size(193, 77);
            this.bttngestrt.TabIndex = 0;
            this.bttngestrt.Text = "Gestionar Artículos";
            this.bttngestrt.UseVisualStyleBackColor = true;
            // 
            // bttnsalir
            // 
            this.bttnsalir.Location = new System.Drawing.Point(202, 286);
            this.bttnsalir.Name = "bttnsalir";
            this.bttnsalir.Size = new System.Drawing.Size(193, 68);
            this.bttnsalir.TabIndex = 1;
            this.bttnsalir.Text = "Salir";
            this.bttnsalir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "WinFormApp";
            // 
            // title1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttnsalir);
            this.Controls.Add(this.bttngestrt);
            this.Name = "title1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttngestrt;
        private System.Windows.Forms.Button bttnsalir;
        private System.Windows.Forms.Label label1;
    }
}

