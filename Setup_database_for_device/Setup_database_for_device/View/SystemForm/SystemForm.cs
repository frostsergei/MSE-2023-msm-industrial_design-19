using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class SystemForm : Form
    {
        public SystemForm()
        {
            InitializeComponent();

            ElementHost host = new ElementHost();


            SystemControl systemWindow = new SystemControl(true);
            host.Child = systemWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);
        }

        private void SystemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
