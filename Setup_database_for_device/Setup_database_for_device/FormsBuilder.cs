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

        private LinkedList<View.WindowForm> _forms;
        private View.SystemForm.SystemForm _systemForm;

        private List<int> _currentPipelinesNumbers = new List<int>();
        private List<int> _currentConsumersNumbers = new List<int>();

        private static readonly string pipelinesParam = "031н00";
        private static readonly string consumersParam = "031н01";

        public FormsBuilder(LinkedList<View.WindowForm> forms)
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

            LinkedListNode<View.WindowForm> currentNode = _forms.First;

            while (currentNode != null)
            {
                View.WindowForm currentForm = currentNode.Value;

                if (currentForm.FormName == name)
                {
                    return currentForm;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }


        private void SystemWindowParamsSet(object sender, EventArgs e)
        {
            string zeroOneStringConsumers = _systemForm.GetParamFromWindow(consumersParam);
            string zeroOneStringPipelines = _systemForm.GetParamFromWindow(pipelinesParam);

            List<int> nextConsumersNumbers = GetNumbersOfOneFromZeroOneString(zeroOneStringConsumers);
            List<int> nextPipelinesNumbers = GetNumbersOfOneFromZeroOneString(zeroOneStringPipelines);

            List<int> consumersNumbersToAdd = GetFormsNumbersToAdd(_currentConsumersNumbers, nextConsumersNumbers);
            List<int> pipelinesNumbersToAdd = GetFormsNumbersToAdd(_currentPipelinesNumbers, nextPipelinesNumbers);



            List<int> consumersNumbersToDelete = GetFormsNumbersToDelete(_currentConsumersNumbers, nextConsumersNumbers);
            List<int> pipelinesNumbersToDelete = GetFormsNumbersToDelete(_currentPipelinesNumbers, nextPipelinesNumbers);




            if (pipelinesNumbersToAdd.Count == 0 & pipelinesNumbersToDelete.Count == 0)
            {

                if(consumersNumbersToAdd.Count != 0 | consumersNumbersToDelete.Count != 0)
                {
                    DeleteFormsByFormsNumbers<View.ConsumerForm>(consumersNumbersToDelete);
                    CreateConsumerWindows(consumersNumbersToAdd, _currentPipelinesNumbers);
                }
                
            } else
            {
                DeleteFormsByFormsNumbers<View.ConsumerForm>(_currentConsumersNumbers);
                CreateConsumerWindows(nextConsumersNumbers, nextPipelinesNumbers);
                CreateP
                
                
            }

            EventsArgs.MenuEventArgs args = new EventsArgs.MenuEventArgs(View.ContentMenu.DeepButtonsNames.CONSUMERS, nextConsumersNumbers);
            MenuShouldBeUpdatedEvent?.Invoke(this, args);

            _currentConsumersNumbers = nextConsumersNumbers;
            _currentPipelinesNumbers = nextPipelinesNumbers;

        }

        private void InsertNewCustomer(View.ConsumerForm form)
        {
            LinkedListNode<View.WindowForm> beforeNode = GetBeforeNodeForNumber<View.ConsumerForm>(form.FormIndex);

            if(beforeNode != null)
            {
                _forms.AddAfter(beforeNode, form);
            } else
            {
                _forms.AddAfter(_forms.Last, form);
            }
        }

        private void InsertNewPipelinesSettings(List<View.WindowForm> forms)
        {
            LinkedList<View.WindowForm> linkedForms = new LinkedList<View.WindowForm>(forms);
            //_forms.AddAfter(_forms.Last, form);
        }

        //private vo

        private LinkedListNode<View.WindowForm> GetBeforeNodeForNumber<T>(int number)
        {
            LinkedListNode<View.WindowForm> currentNode = _forms.Last;

            while (currentNode != null)
            {
                View.WindowForm currentForm = currentNode.Value;

                if (currentForm.FormIndex < number & currentForm is T)
                {
                    return currentNode;
                }

                currentNode = currentNode.Previous;
            }

            return null;
        }


        private List<int> GetFormsNumbersToAdd(List<int> currentNumbers, List<int> nextNumbers)
        {
            return nextNumbers.Where((int number) => !currentNumbers.Contains(number)).ToList();
        }

        private List<int> GetFormsNumbersToDelete(List<int> previousNumbers, List<int> currentNumbers)
        {
            return GetFormsNumbersToAdd(currentNumbers, previousNumbers);
        }

        
        private void DeleteFormsByFormsNumbers<FormType>(List<int> formsNumbers)
        {
            LinkedListNode<View.WindowForm> currentNode = _forms.Last;
            List<LinkedListNode<View.WindowForm>> nodesToDelete = new List<LinkedListNode<View.WindowForm>>();

            while (currentNode != null)
            {
                View.WindowForm currentForm = currentNode.Value;

                if (formsNumbers.Contains(currentForm.FormIndex) & currentForm is FormType)
                {
                    nodesToDelete.Add(currentNode);
                }

                currentNode = currentNode.Previous;
            }

            foreach(LinkedListNode<View.WindowForm> nodeToDelete in nodesToDelete)
            {
                _forms.Remove(nodeToDelete);
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


        //private void InsertNewConsumerForm(View.WindowForm form, int number)
        //{
        //    int ind = GetIndexToInsert(_previousConsumersNumbers, number);
        //    if(ind != -1)
        //    {
        //        _previousConsumersNumbers.Insert(ind, number);
        //        _forms.Insert(ind, form);
        //    } else
        //    {
        //        _previousConsumersNumbers.Add(number);
        //        _forms.Add(form);
        //    }
        //}

        //private void InsertNewPipelineForms(View.WindowForm[] forms, int number)
        //{
        //    int ind = GetIndexToInsert(_previousPipelinesNumbers, number);
        //    if (ind != -1)
        //    {
        //        _previousConsumersNumbers.Insert(ind, number);
        //        _forms.InsertRange(ind, forms);
        //    }
        //    else
        //    {
        //        _previousConsumersNumbers.Add(number);
        //        _forms.AddRange(forms);
        //    }
        //}

        private void CreateConsumerWindows(List<int> consumersNumbers, List<int> pipelinesNumbers)
        {
            foreach (int consumerNumber in consumersNumbers)
            {
                View.ConsumerForm newConsumerWindow = new View.ConsumerForm(pipelinesNumbers, consumerNumber);
                InsertNewCustomer(newConsumerWindow);
                NewFormCreatedEvent?.Invoke(newConsumerWindow, EventArgs.Empty);
            }
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

                InsertNewCustomer
                _forms.(coolantSelectionForm);
                _forms.Add(pipelineSettingsLimits);
                _forms.Add(pipelineSettings2Form);
            }

            EventsArgs.MenuEventArgs args = new EventsArgs.MenuEventArgs(View.ContentMenu.DeepButtonsNames.PIPELINES, pipelinesNumbers);
            MenuShouldBeUpdatedEvent?.Invoke(this, args);
        }
    }
}
