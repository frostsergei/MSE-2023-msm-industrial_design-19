using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class SystemForm : WindowForm
    {

        public event EventHandler PipelinesSelectedEvent;
        public event EventHandler ConsumersSelectedEvent;

        private SystemControl _systemWindow;

        public SystemForm(Model.Device device) : base("Общесистемные параметры")
        {
            InitializeComponent();

            ElementHost host = new ElementHost();

            _systemWindow = new SystemControl(device);
            _systemWindow.SetOkBackButtons(_backOkComponent);
            host.Child = _systemWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);

        }

        public Dictionary<string, string> GetSystemWindowData()
        {
            return _systemWindow.GetAllSystemSettings();
        }

        public string GetParamFromWindow(string param)
        {
            Dictionary<string, string> result = GetSystemWindowData();
            return result.ContainsKey(param) ? result[param] : null;
        }
    }
}
