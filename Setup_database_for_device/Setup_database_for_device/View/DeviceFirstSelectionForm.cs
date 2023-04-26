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
    public partial class DeviceFirstSelectionForm : Form
    {
        public DeviceFirstSelectionForm()
        {
            InitializeComponent();
            comboBoxDevice.SelectedIndex = 0;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            MainForm mainForm = null;
            switch (comboBoxDevice.SelectedIndex)  
            {
                case 0:
                    mainForm = new MainForm(Model.Device.SPT961, this);
                    break;
                case 1:
                    mainForm = new MainForm(Model.Device.SPT962, this);
                    break;
                case 2:
                    mainForm = new MainForm(Model.Device.SPT963, this);
                    break;
                default:
                    break;
            }
            mainForm.Show();
            this.Hide();
        }
    }
}
