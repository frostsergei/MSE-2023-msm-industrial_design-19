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
    }
}
