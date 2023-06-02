using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System;

namespace Setup_database_for_device.View
{
    public partial class PipelineSettings2Form : WindowForm
    {
        private PipelineSettings2WPF _secondPipelineSettingsWindow;

        public PipelineSettings2Form(int index) : base($"Вторая настройка трубопровода {index}", true)
        {
            InitializeComponent();

            _formIndex = index;

            ElementHost host = new ElementHost();

            _secondPipelineSettingsWindow = new PipelineSettings2WPF();
            _secondPipelineSettingsWindow.SetOkBackButtons(_backOkComponent);
            host.Child = _secondPipelineSettingsWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);

            SetLowerLimit(0);
            
        }

        public override void OnLoadForm(EventsArgs.NextFormArgs paramsFromPreviousForm, AppState appState)
        {

            if (paramsFromPreviousForm == null)
            {
                return;
            }

            if (paramsFromPreviousForm.Params.ContainsKey("lowLimit"))
            {
                _secondPipelineSettingsWindow.lowerlimitValue = paramsFromPreviousForm.Params["lowLimit"];
            }
            
        }

        public void SetLowerLimit(float lowerlimit)
        {
            _secondPipelineSettingsWindow.lowerlimitValue = lowerlimit.ToString();
        }

        public Dictionary<string, string> GetPipelineWindowData()
        {
            return _secondPipelineSettingsWindow.GetPipelineSettings();
        }

        public override bool IsFormFilledOut()
        {
            Dictionary<string, string> pars = _secondPipelineSettingsWindow.GetPipelineSettings();
            if (pars["115н00"] == "" || pars["115н01"] == "" || pars["120"] == "")
                return false;
            return true;
        }
    }
}
