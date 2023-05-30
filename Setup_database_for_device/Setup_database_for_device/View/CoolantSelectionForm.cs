using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View
{
    public partial class CoolantSelectionForm : WindowForm
    {
        private static readonly string SensorParamName = "034н00";

        private CoolantSelectionWPF _coolantSelectionWindow;

        private PipelineSettingsLimits _pipelineSettingsLimitsForm;
        private WindowForm _previousPipelinesSettings;


        public CoolantSelectionForm(int index) : base($"Теплоноситель {index}")
        {
            InitializeComponent();

            _formIndex = index;

            ElementHost host = new ElementHost();

            _coolantSelectionWindow = new CoolantSelectionWPF();
            _coolantSelectionWindow.AddOkBackButtons(_backOkComponent);
            host.Child = _coolantSelectionWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);

        }
        public Dictionary<string, string> GetCoolantWindowData()
        {
            return (CoolantSelectionBlock.Child as CoolantSelectionWPF).GetAllCoolantSettings();
        }

        public void SetPreviousPipelineSettings(WindowForm form)
        {
            _previousPipelinesSettings = form;
        }

        public void SetNextPipelineSettings(PipelineSettingsLimits form)
        {
            _pipelineSettingsLimitsForm = form;
        }


        protected override bool IsAbleToGoToNext()
        {
            string result = (CoolantSelectionBlock.Child as CoolantSelectionWPF).GetAllCoolantSettings()[SensorParamName];
            result = result.Substring(0, result.Length - 1);
            if (result != "")
            {
                paramsToNextForm = new Dictionary<string, string>()
                {
                    { "curIndicator", result }
                };
                return true;
            }
            
            return false;
        }
    }
}
