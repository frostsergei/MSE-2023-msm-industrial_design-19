using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View
{
    public partial class PipelineSettings2Form : WindowForm
    {

        private PipelineSettings2WPF _secondPipelineSettingsWindow;


        public PipelineSettings2Form(int index) : base($"Вторая настройка трубопровода {index}", true)
        {
            InitializeComponent();

            ElementHost host = new ElementHost();

            _secondPipelineSettingsWindow = new PipelineSettings2WPF();
            _secondPipelineSettingsWindow.SetOkBackButtons(_backOkComponent);
            host.Child = _secondPipelineSettingsWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);

            SetLowerLimit(0);
            
        }


        public void SetLowerLimit(float lowerlimit)
        {
            _secondPipelineSettingsWindow.lowerlimitValue = lowerlimit.ToString();
        }

        public Dictionary<string, string> GetPipelineWindowData()
        {
            return _secondPipelineSettingsWindow.GetPipelineSettings();
        }

    }
}
