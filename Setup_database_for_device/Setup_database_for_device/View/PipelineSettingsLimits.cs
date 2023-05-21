using Setup_database_for_device.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View
{
    public partial class PipelineSettingsLimits : WindowForm
    {
        private PipelineSettingsLimitsWPF _pipelineSettingsLimitsWPF; //WPF данного окна
        private PipelineSettings2Form _pipelineSettings2WPF;

        private string _curIndicator;

        public PipelineSettingsLimits(int index) : base($"Первая настройка трубопровода {index}", true)
        {
            InitializeComponent();
                       
            Text = "Настройка трубопроводов.Ввод значений расхода, давления и температуры";

            ElementHost host = new ElementHost();

            _pipelineSettingsLimitsWPF = new PipelineSettingsLimitsWPF();
            _pipelineSettingsLimitsWPF.SetOkBackButtons(_backOkComponent);
            host.Child = _pipelineSettingsLimitsWPF;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);
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
        
        public void SetNextPipelineSettings(PipelineSettings2Form form)
        {
            _pipelineSettings2WPF = form;
        }
    
        public void SetCurIndicator(string curIndicator)
        {
            _curIndicator = $"{curIndicator[0]}{curIndicator[1]}";
            _pipelineSettingsLimitsWPF.curIndicator = _curIndicator;
            _pipelineSettingsLimitsWPF.SetWindow();
        }

        protected override bool IsAbleToGoToNext()
        {
            return true;
        }
    }

}
