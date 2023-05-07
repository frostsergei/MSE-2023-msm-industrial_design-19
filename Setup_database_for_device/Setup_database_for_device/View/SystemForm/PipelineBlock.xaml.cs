using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class PipelineBlock : UserControl
    {

        private static readonly string[] s_parametersNames = { "035н0", "036н0", "037н0", "040н0" };
        private PipelineControl[] _pipelinesSettings;


        public PipelineBlock(bool isEnabled)
        {
            InitializeComponent();

            _pipelinesSettings = new PipelineControl[4];


            _pipelinesSettings[0] = new PipelineControl("Температура холодной воды:", "0", isEnabled);
            _pipelinesSettings[1] = new PipelineControl("Давление холодной воды:", "0,1", isEnabled);
            _pipelinesSettings[2] = new PipelineControl("Барометрическое давление:", "760", isEnabled);
            _pipelinesSettings[3] = new PipelineControl("Температура наружного воздуха:", "20", isEnabled);

            for (int i = 0; i < _pipelinesSettings.Length; i++)
            {
                PipelineSettings.Children.Add(_pipelinesSettings[i]);
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
