using Setup_database_for_device.EventsArgs;
using Setup_database_for_device.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View
{
    public partial class PipelineSettingsLimits : WindowForm
    {
        private PipelineSettingsLimitsWPF _pipelineSettingsLimitsWPF;

        private string _curIndicator;

        public PipelineSettingsLimits(int index) : base($"Первая настройка трубопровода {index}", true)
        {
            InitializeComponent();

            _formIndex = index;
            Text = "Настройка трубопроводов. Ввод значений расхода, давления и температуры";

            ElementHost host = new ElementHost();

            _pipelineSettingsLimitsWPF = new PipelineSettingsLimitsWPF();
            _pipelineSettingsLimitsWPF.SetOkBackButtons(_backOkComponent);
            host.Child = _pipelineSettingsLimitsWPF;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);
        }

        public override void OnLoadForm(NextFormArgs paramsFromPreviousForm)
        {
            if(paramsFromPreviousForm.Params.ContainsKey("curIndicator"))
            {
                SetCurIndicator(paramsFromPreviousForm.Params["curIndicator"]);
            } else
            {
                SetCurIndicator("00");
            }
        }

        protected override bool IsAbleToGoToNext()
        {
            Dictionary<string, string> result1 = _pipelineSettingsLimitsWPF.GetPipelineSettings();
            if ("" != "")
            {
                paramsToNextForm = new Dictionary<string, string>()
                {
                    { "lowLimit", "" }
                };
                return true;
            }

            return false;
        }

        public Dictionary<string, string> GetPipelineWindowData()
        {
            return _pipelineSettingsLimitsWPF.GetPipelineSettings();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PipelineSettingLimits_Load(object sender, EventArgs e)
        {
            
        }
    
        public void SetCurIndicator(string curIndicator)
        {
            _curIndicator = $"{curIndicator[0]}{curIndicator[1]}";
            _pipelineSettingsLimitsWPF.curIndicator = _curIndicator;
            _pipelineSettingsLimitsWPF.SetWindow();
        }
    }

}
