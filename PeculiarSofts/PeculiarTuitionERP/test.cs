using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PeculiarTuitionERP
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void picBOx1_btnAddClick(object sender, EventArgs e)
        {
            MessageBox.Show("Pic box click");
        }
    }
}
