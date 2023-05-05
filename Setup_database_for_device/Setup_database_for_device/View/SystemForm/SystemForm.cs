using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class SystemForm : Form
    {

        private SystemControl _systemWindow;

        public SystemForm()
        {
            InitializeComponent();

            ElementHost host = new ElementHost();


            _systemWindow = new SystemControl(true);
            host.Child = _systemWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);
        }

        public Dictionary<string, string> GetSystemWindowData()
        {
            return _systemWindow.GetAllSystemSettings();
        }

        private void SystemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
