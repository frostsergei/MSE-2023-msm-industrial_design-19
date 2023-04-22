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
    public partial class CoolantSelectionForm : Form
    {
        public CoolantSelectionForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 3;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Перегретый пар" || comboBox1.SelectedItem.ToString() == "Насыщенный пар")
            {
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;

                label5.Visible = false;
                label6.Visible = false;
                textBox2.Visible = false;
            }
            else if(comboBox1.SelectedItem.ToString() == "Жидкость")
            {
                label5.Visible = true;
                label6.Visible = true;
                textBox2.Visible = true;

                label3.Visible = false;
                label4.Visible = false;
                textBox1.Visible = false;
            }
            else
            {
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
            }
        }
    }
}
