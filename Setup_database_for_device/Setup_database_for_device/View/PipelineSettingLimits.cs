using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows.Documents;

namespace Setup_database_for_device.View
{
    public partial class PipelineSettingLimits : Form
    { 
        string curIndicator = "04";// убрать после подсодинения к моделе
        public PipelineSettingLimits()
        {
            InitializeComponent();
                       
            this.Text = "Настройка трубопроводов. Ввод значения расхода, избыточного давления и температуры теплоносителя";
        }
        

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PipelineSettingLimits_Load(object sender, EventArgs e)
        {
           if(curIndicator == "03" || curIndicator == "04")
            {
                richTextBox1.Visible = true;
                richTextBox2.Visible = true;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;

                label1.Visible = true;
                label2.Visible = true;

                label3.Visible = true;
                label4.Visible = true;

                //turning off

                richTextBox13.Visible = false;
                textBox13.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox14.Visible = false;

                textBox15.Visible = false;
                richTextBox14.Visible = false;
            }
            if (curIndicator == "01" || curIndicator == "02")
            {
                richTextBox13.Visible = true;
                textBox13.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                textBox14.Visible = true;

                textBox15.Visible = true;
                richTextBox14.Visible = true;

            //turning off
                richTextBox1.Visible = false;
                richTextBox2.Visible = false;

                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;

                label1.Visible = false;
                label2.Visible = false;

                label3.Visible = false;
                label4.Visible = false;
            }
        }        
    }

}
