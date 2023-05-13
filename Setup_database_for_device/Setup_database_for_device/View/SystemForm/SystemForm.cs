using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class SystemForm : WindowForm
    {

        private SystemControl _systemWindow;

        public SystemForm() : base("Общесистемные параметры")
        {
            InitializeComponent();

            ElementHost host = new ElementHost();

            _systemWindow = new SystemControl(true);
            _systemWindow.SetOkBackButtons(_backOkComponent);
            host.Child = _systemWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);

        }

        public Dictionary<string, string> GetSystemWindowData()
        {
            return _systemWindow.GetAllSystemSettings();
        }
    }
}
