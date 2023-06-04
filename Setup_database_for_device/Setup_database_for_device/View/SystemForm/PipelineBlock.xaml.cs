using System.Collections.Generic;
using System.Windows.Controls;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class PipelineBlock : UserControl
    {

        private static readonly string[] s_parametersNames = { "035н0", "036н0", "037н0", "040н0" };
        private PipelineControl[] _pipelinesSettings;

        public PipelineControl[] PipelinesSettings { get { return _pipelinesSettings; } }

        public PipelineBlock()
        {
            InitializeComponent();

            _pipelinesSettings = new PipelineControl[4];


            _pipelinesSettings[0] = new PipelineControl("Температура холодной воды:", "0");
            _pipelinesSettings[1] = new PipelineControl("Давление холодной воды:", "0,1");
            _pipelinesSettings[2] = new PipelineControl("Барометрическое давление:", "760");
            _pipelinesSettings[3] = new PipelineControl("Температура наружного воздуха:", "20");

            object objLabel = _pipelinesSettings[2].FindName("MeasurementUnitLabel");
            System.Windows.Controls.Label label = (System.Windows.Controls.Label)objLabel;
            label.Content = "мм.рт.ст.";
            objLabel = _pipelinesSettings[1].FindName("MeasurementUnitLabel");
            label = (System.Windows.Controls.Label)objLabel;
            label.Content = "МПа";

            for (int i = 0; i < _pipelinesSettings.Length; i++)
            {
                PipelineSettings.Children.Add(_pipelinesSettings[i]);
            }


        }
    
        public void EnableBlock()
        {
            foreach(PipelineControl control in _pipelinesSettings)
            {
                control.EnablePipelineControl();
            }
        }
        
        public void DisableBlock()
        {
            foreach (PipelineControl control in _pipelinesSettings)
            {
                control.DisablePipelineControl();
            }
        }

        public Dictionary<string, string> GetResult()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            for(int i = 0; i < _pipelinesSettings.Length; i++)
            {
                Dictionary<string, string> pipelineSettingsValue = _pipelinesSettings[i].Value;

                result.Add($"{s_parametersNames[i]}0", pipelineSettingsValue["TextFieldValue"]);
                result.Add($"{s_parametersNames[i]}1", pipelineSettingsValue["CheckboxValue"]);
            }

            return result;
        }
    }
}
