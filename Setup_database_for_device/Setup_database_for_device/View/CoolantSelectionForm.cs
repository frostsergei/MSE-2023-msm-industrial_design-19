using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View
{
    public partial class CoolantSelectionForm : WindowForm
    {
        /*Данные из WPF могут быть получены следующим образом:
         * (elementHost1.Child as CoolantSelectionWPF).coolantTypeValue - тип теплоносителя
         * (elementHost1.Child as CoolantSelectionWPF).flowMeterValue - тип расходомера
         * (elementHost1.Child as CoolantSelectionWPF).sensorTypeValue - тип датчика (возвращает индекс)
         * (elementHost1.Child as CoolantSelectionWPF).saturationWidthValue - ширина зоны насыщения
         * (elementHost1.Child as CoolantSelectionWPF).drynessValue - степень сухости
        */
        //
        private static readonly string SensorParamName = "034н00";

        private CoolantSelectionWPF _coolantSelectionWindow;

        private PipelineSettingsLimits _pipelineSettingsLimitsForm;
        private WindowForm _previousPipelinesSettings;

        public CoolantSelectionForm(int index) : base($"Теплоноситель {index}")
        {
            InitializeComponent();

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

            string result = _coolantSelectionWindow.GetAllCoolantSettings()[SensorParamName];
            if (result != "")
            {
                _pipelineSettingsLimitsForm.SetCurIndicator(result);
                return true;
            }
            
            return false;
        }
    }
}
