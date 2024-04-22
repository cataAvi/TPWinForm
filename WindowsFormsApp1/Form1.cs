using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void bttnsalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bttngestrt_Click(object sender, EventArgs e)
        {
            FormPrincipal form2 = new FormPrincipal();
            form2.ShowDialog();
        }
    }
}
