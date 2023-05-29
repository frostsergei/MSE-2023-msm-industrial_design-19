using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup_database_for_device.View
{
    public partial class ADS_97_Form : Form
    {
        public ADS_97_Form()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            labelSecondAdapter.Visible = false;
            numericUpDown2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                labelSecondAdapter.Visible = false;
                numericUpDown2.Visible = false;
            }
            else
            {
                labelSecondAdapter.Visible = true;
                numericUpDown2.Visible = true;
            }
        }
    }
}
