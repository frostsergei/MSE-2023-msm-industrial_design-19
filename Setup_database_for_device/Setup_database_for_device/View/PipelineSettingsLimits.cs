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

        public override void OnLoadForm(NextFormArgs paramsFromPreviousForm, AppState appState)
        {

            if (paramsFromPreviousForm == null)
            {
                return;
            }

            if (paramsFromPreviousForm.Params.ContainsKey("curIndicator"))
            {
                SetCurIndicator(paramsFromPreviousForm.Params["curIndicator"]);
            } else
            {
                SetCurIndicator("00");
            }
        }

        protected override bool IsAbleToGoToNext()
        {
            string result = _pipelineSettingsLimitsWPF.GetPipelineSettings().ContainsKey("034н02") ? _pipelineSettingsLimitsWPF.GetPipelineSettings()["034н02"] : "0";
            if ("" == "")
            {
                paramsToNextForm = new Dictionary<string, string>()
                {
                    { "lowLimit", result }
                };
                return true;
            }

            return false;
        }

        public override bool IsFormFilledOut()
        {
            Dictionary<string, string> pars = _pipelineSettingsLimitsWPF.GetPipelineSettings();
            if (pars["109н00"] == "" || pars["032н00"] == "" || pars["032н01"] == "" || pars["032н08"] == "" || 
                pars["113н00"] == "" || pars["033н00"] == "" || pars["033н01"] == "" || pars["033н02"] == "" ||
                pars["114н00"] == "")
                return false;

            if (pars.ContainsKey("034н01"))
            {
                if (pars["034н01"] == "" || pars["034н02"] == "" || pars["034н06"] == "" || pars["034н07"] == "")
                    return false;
                return true;
            }
            if(pars["034н06"] == "" || pars["034н07"] == "" || pars["034н08"] == "")
                return false;
            return true;
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
