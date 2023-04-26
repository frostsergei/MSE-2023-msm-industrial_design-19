using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Setup_database_for_device
{
    public partial class SliderRange : Form
    {
        public SliderRange()
        {
            InitializeComponent();
            DB.Test test = new DB.Test();
        }

        float f;

        private void low_Limit_TextChanged(object sender, EventArgs e)
        {
            if ((float.TryParse(low_Limit.Text, out f)) && (f <= 400) && (f >= 0))//low &high need to be fixed
            {
                lowest_input = f;
                low_Limit.BackColor = Color.White;
                lowSlider.Value = ((int)f);
            }
            else
            {
                //lowest_input = 0;
                low_Limit.BackColor = Color.PaleVioletRed;
            }

        }

        private void high_Limit_TextChanged(object sender, EventArgs e)
        {
            if ((float.TryParse(high_Limit.Text, out f)) && (f > 400) && (f < 764))//l&hi
            {
                highest_input = f;
                high_Limit.BackColor = Color.White;
                UpperSlider.Value = ((int)f);
            }
            else
            {
                //highest_input = 0;
                high_Limit.BackColor = Color.PaleVioletRed;
            }

        }

        private void low_Limit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                low_Limit_TextChanged(sender, e);
                Console.WriteLine("low value = " + lowest_input.ToString());
            }
        }

        private void high_Limit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                high_Limit_TextChanged(sender, e);
                Console.WriteLine("high value = " + highest_input.ToString());
            }
        }

        private void lowSlider_Scroll(object sender, EventArgs e)
        {
            lowest_input = lowSlider.Value;
            low_Limit.Text = lowest_input.ToString();
        }

        private void UpperSlider_Scroll(object sender, EventArgs e)
        {
            highest_input = UpperSlider.Value;
            high_Limit.Text = highest_input.ToString();
        }
    }
}
