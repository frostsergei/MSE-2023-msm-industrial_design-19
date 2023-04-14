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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //DB.Test test = new DB.Test();
            TestForm subForm = new TestForm();
            subForm.TopLevel = false;
            subForm.AutoScroll = true;
            subForm.Dock = DockStyle.Fill;
            subForm.FormBorderStyle = FormBorderStyle.None;
            panelContent.Controls.Add(subForm);
            subForm.BringToFront();
            subForm.Show();
        }
    }
}
