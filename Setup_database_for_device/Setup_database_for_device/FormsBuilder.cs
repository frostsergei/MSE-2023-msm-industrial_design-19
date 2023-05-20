using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setup_database_for_device
{
    public class FormsBuilder
    {

        public event EventHandler NewFormCreatedEvent;
        public event EventHandler<EventsArgs.MenuEventArgs> MenuShouldBeUpdatedEvent;

        public enum FormsName
        {
            CONSUMERS,
            PIPELINES
        }

        private List<View.WindowForm> _forms;
        private View.SystemForm.SystemForm _systemForm;

        private List<int> _previousPipelinesNumbers = new List<int>();
        private List<int> _previousConsumersNumbers = new List<int>();

        private static readonly string pipelinesParam = "031н00";
        private static readonly string consumersParam = "031н01";

        public FormsBuilder(List<View.WindowForm> forms)
        {
            _forms = forms;


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

        private int GetFormIndexByName(string name)
        {
            for(int i = 0; i < _forms.Count; i++)
            {
                if (_forms[i].FormName == name)
                {
                    return i;
                }
            }

            return -1;
        }

        private List<int> GetFormsNumbersToAdd(List<int> previousNumbers, List<int> currentNumbers)
        {
            return currentNumbers.Where((int number) => !previousNumbers.Contains(number)).ToList();
        }

        private List<int> GetFormsNumbersToDelete(List<int> previousNumbers, List<int> currentNumbers)
        {
            return GetFormsNumbersToAdd(currentNumbers, previousNumbers);
        }

        private void SystemWindowParamsSet(object sender, EventArgs e)
        {
            string zeroOneStringConsumers = _systemForm.GetParamFromWindow(consumersParam);
            string zeroOneStringPipelines = _systemForm.GetParamFromWindow(pipelinesParam);

            List<int> consumersNumbers = GetNumbersOfOneFromZeroOneString(zeroOneStringConsumers);
            List<int> pipelinesNumbers = GetNumbersOfOneFromZeroOneString(zeroOneStringPipelines);

            List<int> consumersNumbersToAdd = GetFormsNumbersToAdd(_previousConsumersNumbers, consumersNumbers);
            List<int> pipelinesNumbersToAdd = GetFormsNumbersToAdd(_previousPipelinesNumbers, pipelinesNumbers);

            List<int> consumersNumbersToDelete = GetFormsNumbersToDelete(_previousConsumersNumbers, consumersNumbers);
            List<int> pipelinesNumbersToDelete = GetFormsNumbersToDelete(_previousPipelinesNumbers, pipelinesNumbers);

            if ((pipelinesNumbersToAdd.Count != 0) & (consumersNumbersToAdd.Count == 0 | consumersNumbersToAdd.Count != 0))
            {
                DeleteFormsByFormsNumbers(FormsName.CONSUMERS, _previousConsumersNumbers);
                DeleteFormsByFormsNumbers(FormsName.PIPELINES, pipelinesNumbersToDelete);
                CreateConsumerWindows(consumersNumbers, pipelinesNumbers);
                CreatePipelinesWindows(pipelinesNumbersToAdd);
            } else
            {
                DeleteFormsByFormsNumbers(FormsName.CONSUMERS, consumersNumbersToDelete);
                CreateConsumerWindows(consumersNumbersToAdd, pipelinesNumbers);
            }
            
            
        }

        private void DeleteFormsByFormsNumbers(FormsName name, List<int> numbers)
        {
            string formName = "";

            switch(name)
            {
                case FormsName.CONSUMERS:
                    formName = "Потребитель";
                    break;
                case FormsName.PIPELINES:
                    formName = "Трубопровод";
                    break;
            }

            foreach (int number in numbers)
            {
                int formIndex = GetFormIndexByName($"{formName} {number}");
                if(formIndex != -1)
                {
                    _forms.RemoveAt(formIndex);
                }
            }

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

        private void CreateConsumerWindows(List<int> consumersNumbers, List<int> pipelinesNumbers)
        {
            foreach (int consumerNumber in consumersNumbers)
            {
                View.ConsumerForm newConsumerWindow = new View.ConsumerForm(pipelinesNumbers, consumerNumber);
                _forms.Add(newConsumerWindow);
                NewFormCreatedEvent?.Invoke(newConsumerWindow, EventArgs.Empty);                        
            }

            EventsArgs.MenuEventArgs args = new EventsArgs.MenuEventArgs(View.ContentMenu.DeepButtonsNames.CONSUMERS, consumersNumbers);

            MenuShouldBeUpdatedEvent?.Invoke(this, args);
        }

        private void CreatePipelinesWindows(List<int> pipelinesNumbers)
        {

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

            EventsArgs.MenuEventArgs args = new EventsArgs.MenuEventArgs(View.ContentMenu.DeepButtonsNames.CONSUMERS, pipelinesNumbers);
            MenuShouldBeUpdatedEvent?.Invoke(this, args);
        }
    }
}
