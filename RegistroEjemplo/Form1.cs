using RegistroEjemplo.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegistroEjemplo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RegistrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroPersona rg = new RegistroPersona();
            rg.Show();
        }
    }
}
