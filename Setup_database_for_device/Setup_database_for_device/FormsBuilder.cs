using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup_database_for_device
{
    public class FormsBuilder
    {

        public class CustomEventArgs
        {
            public List<int> FormsNumbers { get; set; }
            public View.ContentMenu.DeepButtonsNames ButtonName { get; set; }
            public CustomEventArgs(View.ContentMenu.DeepButtonsNames buttonName, List<int> formsNumbers)
            {
                FormsNumbers = formsNumbers;
                ButtonName = buttonName;
            }
        }

        public event EventHandler NewFormCreatedEvent;
        public event EventHandler MenuShouldBeUpdatedEvent;

        private View.ContentMenu _menu;
        private List<View.WindowForm> _forms;
        private View.SystemForm.SystemForm _systemForm;

        private static readonly string pipelinesParam = "031н00";
        private static readonly string consumersParam = "031н01";

        public FormsBuilder(List<View.WindowForm> forms, View.ContentMenu menu)
        {
            _forms = forms;
            _menu = menu;

            View.WindowForm systemWindow = GetFormByName("Общесистемные параметры");
            
            if(!(systemWindow is null))
            {
                _systemForm = systemWindow as View.SystemForm.SystemForm;
                _systemForm.NextFormEvent += new EventHandler(SystemWindowParamsSet);
            }
        }

        private View.WindowForm GetFormByName(string name)
        {
            foreach(View.WindowForm form in _forms)
            {
                if (form.FormName == name)
                {
                    return form;
                }
            }

            return null;
        }

        private void SystemWindowParamsSet(object sender, EventArgs e)
        {       
            string zeroOneStringConsumers = _systemForm.GetParamFromWindow(consumersParam);
            string zeroOneStringPipelines = _systemForm.GetParamFromWindow(pipelinesParam);
            CreateConsumerWindows(zeroOneStringConsumers, zeroOneStringPipelines);
            CreatePipelinesWindows(zeroOneStringPipelines);
        }

        private List<int> GetNumbersOfOneFromZeroOneString(string zeroOneString)
        {

            List<int> numbers = new List<int>();

            for (int i = 0; i < zeroOneString.Length; i++)
            {
                if (zeroOneString[i] == '1')
                {
                    numbers.Add(i + 1);
                }
            }

            return numbers;
        }

        private Dictionary<View.ContentMenu.DeepButtonsNames, List<int>> GetMenuParam(View.ContentMenu.DeepButtonsNames buttonName, List<int> formNumbers)
        {
            return new Dictionary<View.ContentMenu.DeepButtonsNames, List<int>>()
            {
                { buttonName, formNumbers }
            };
        }

        private void CreateConsumerWindows(string consumersZeroOneString, string pipelinesZeroOneString)
        {

            List<int> consumersNumbers = GetNumbersOfOneFromZeroOneString(consumersZeroOneString);
            List<int> pipelinesNumbers = GetNumbersOfOneFromZeroOneString(pipelinesZeroOneString);

            foreach (int consumerNumber in consumersNumbers)
            {
                View.ConsumerForm newConsumerWindow = new View.ConsumerForm(pipelinesNumbers, consumerNumber);
                _forms.Add(newConsumerWindow);
                NewFormCreatedEvent?.Invoke(newConsumerWindow, EventArgs.Empty);
                Dictionary<View.ContentMenu.DeepButtonsNames, int> param = new Dictionary<View.ContentMenu.DeepButtonsNames, int>() {
                    { View.ContentMenu.DeepButtonsNames.CONSUMERS, consumerNumber }
                };
               

            }

            MenuShouldBeUpdatedEvent?.Invoke();
        }

        private void CreatePipelinesWindows(string pipelinesZeroOneString)
        {
            List<int> pipelinesNumbers = GetNumbersOfOneFromZeroOneString(pipelinesZeroOneString);

            foreach (int pipelineNumber in pipelinesNumbers)
            {
                View.CoolantSelectionForm coolantSelectionForm = new View.CoolantSelectionForm(pipelineNumber);
                View.PipelineSettingsLimits pipelineSettingsLimits = new View.PipelineSettingsLimits(pipelineNumber);
                View.PipelineSettings2Form pipelineSettings2Form = new View.PipelineSettings2Form(pipelineNumber);

                coolantSelectionForm.SetNextPipelineSettings(pipelineSettingsLimits);
                pipelineSettingsLimits.SetNextPipelineSettings(pipelineSettings2Form);

                NewFormCreatedEvent?.Invoke(coolantSelectionForm, EventArgs.Empty);
                NewFormCreatedEvent?.Invoke(pipelineSettingsLimits, EventArgs.Empty);
                NewFormCreatedEvent?.Invoke(pipelineSettings2Form, EventArgs.Empty);

                _forms.Add(coolantSelectionForm);
                _forms.Add(pipelineSettingsLimits);
                _forms.Add(pipelineSettings2Form);
            }
        }
    }
}
