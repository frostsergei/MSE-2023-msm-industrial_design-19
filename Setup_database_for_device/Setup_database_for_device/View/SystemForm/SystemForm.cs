using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class SystemForm : WindowForm
    {


        private ADS_97_Form _ADS_97_Form;
        private SystemControl _systemWindow;
        private int _minPipelinesCountFor_ADS_97 = 0;
        private static string SelectedPipelinesParam = "031н00";
        private Dictionary<string, string> ADS_97_result;

        public SystemForm(Model.Device device) : base("Общесистемные параметры")
        {
            InitializeComponent();

            _ADS_97_Form = new ADS_97_Form();
            _ADS_97_Form.DataIsSetEvent += new EventHandler(SaveADS_97_results);
            ElementHost host = new ElementHost();
            ADS_97_result = new Dictionary<string, string>();

            CalculateMinPipelinesCountForm_ADS_97(device);

            _systemWindow = new SystemControl(device);
            _systemWindow.SetOkBackButtons(_backOkComponent);
            host.Child = _systemWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);

        }

        public void SaveADS_97_results(object sender, EventArgs e)
        {
            ADS_97_result = _ADS_97_Form.GetADS_97_results();
        }

        private void CalculateMinPipelinesCountForm_ADS_97(Model.Device device)
        {
            switch(device)
            {
                case Model.Device.SPT963:
                    _minPipelinesCountFor_ADS_97 = 8;
                    break;
                default:
                    _minPipelinesCountFor_ADS_97 = 4;
                    break;
            }
        }

        public Dictionary<string, string> GetSystemWindowData()
        {
            Dictionary<string, string> result = _systemWindow.GetAllSystemSettings();
            foreach(KeyValuePair<string, string> param in ADS_97_result)
            {
                result.Add(param.Key, param.Value);
            }

            return result;
        }

        private int GetPipelinesCountByOneZeroString(string oneZeroString)
        {
            int count = 0;

            foreach(char sym in oneZeroString)
            {
                if(sym == '1')
                {
                    count++;
                }
            }

            return count;
        }

        public override void OnLoadForm(EventsArgs.NextFormArgs e, AppState appState)
        {
            if(appState.IsAllPipelinesFilledOut())
            {
                _systemWindow.EnableSensorsSettings();
            } else
            {
                _systemWindow.DisableSensorsSettings();
            }
        }

        protected override void OnNextFormAction()
        {

            string zeroOneStringPipelines = GetParamFromWindow(SelectedPipelinesParam);
            int countSelectedPipelines = (zeroOneStringPipelines != null) ? GetPipelinesCountByOneZeroString(zeroOneStringPipelines) : 0;
            if (countSelectedPipelines > _minPipelinesCountFor_ADS_97)
            {
                _ADS_97_Form.ShowDialog();
            }      
        }

        public string GetParamFromWindow(string param)
        {
            Dictionary<string, string> result = GetSystemWindowData();
            return result.ContainsKey(param) ? result[param] : null;
        }
    }
}
