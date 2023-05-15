using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Setup_database_for_device
{
    public class FormSwitcher
    {

        private View.ContentMenu _menu;
        private List<View.WindowForm> _forms;
        private Panel _contentPanel;
        private int _currentFormIndex = 0;
        private bool _pipelinesSet = false;
        private bool _consumersSet = false;
        private static string pipelinesParam = "031н00";
        private static string consumersParam = "031н01";

        public FormSwitcher(View.ContentMenu menu, List<View.WindowForm> forms, Panel contentPanel)
        {
            _menu = menu;
            _forms = forms;
            _contentPanel = contentPanel;

            _menu.FormChanged += new EventHandler(ChangeFormByClickOnMenu);

            foreach(View.WindowForm form in _forms)
            {
                form.NextFormEvent += new EventHandler(GoAhead);
                form.PreviousFormEvent += new EventHandler(GoBack);
            }

            SetFormByName("Общесистемные параметры");
        }


        private int GetFormIndexByName(string name)
        {
            for (int i = 0; i < _forms.Count; i++)
            {
                if (_forms[i].FormName == name)
                {
                    return i;
                }
            }

            return -1;
        }

        private void SetFormByIndex(int index)
        {

            View.WindowForm subForm = _forms[index];
            _menu.SelectButtonByName(subForm.FormName);

            _contentPanel.Controls.Clear();
            _contentPanel.Controls.Add(subForm);
            subForm.BringToFront();
            subForm.Show();
        }

        private void SetFormByName(string name)
        {
            _currentFormIndex = GetFormIndexByName(name);

            if(_currentFormIndex != -1)
            {
                SetFormByIndex(_currentFormIndex);
            }
        }

        private void SetConsumers()
        {
            View.SystemForm.SystemForm systemWindow = _forms[0] as View.SystemForm.SystemForm;
            string zeroOneStringConsumers = systemWindow.GetParamFromWindow(consumersParam);
            string zeroOneStringPipelines = systemWindow.GetParamFromWindow(pipelinesParam);

            CreateMenuItems(View.ContentMenu.DeepButtonsNames.CONSUMERS, zeroOneStringConsumers);
            CreateConsumerWindows(zeroOneStringConsumers, zeroOneStringPipelines);
        }

        private void SetPipelines()
        {
            View.SystemForm.SystemForm systemWindow = _forms[0] as View.SystemForm.SystemForm;
            string ZeroOneStringConsumers = systemWindow.GetParamFromWindow(pipelinesParam);


            CreateMenuItems(View.ContentMenu.DeepButtonsNames.PIPELINES, ZeroOneStringConsumers);
            CreatePipelinesWindows(ZeroOneStringConsumers);

        }

        private List<int> GetNumbersOfOneFromZeroOneString(string zeroOneString)
        {

            List<int> numbers = new List<int>();

            for(int i = 0; i < zeroOneString.Length; i++)
            {
                if(zeroOneString[i] == '1')
                {
                    numbers.Add(i + 1);
                }
            }

            return numbers;
        }

        private void CreateConsumerWindows(string consumersZeroOneString, string pipelinesZeroOneString)
        {

            List<int> consumersNumbers = GetNumbersOfOneFromZeroOneString(consumersZeroOneString);
            List<int> pipelinesNumbers = GetNumbersOfOneFromZeroOneString(pipelinesZeroOneString);

            foreach(int consumerNumber in consumersNumbers)
            {
                View.ConsumerForm newPipelineWindow = new View.ConsumerForm(pipelinesNumbers, consumerNumber);
                _forms.Add(newPipelineWindow);
            }
        }

        private void CreatePipelinesWindows(string pipelinesZeroOneString)
        {
            List<int> pipelinesNumbers = GetNumbersOfOneFromZeroOneString(pipelinesZeroOneString);

            foreach(int pipelineNumber in pipelinesNumbers)
            {
                View.CoolantSelectionForm coolantSelectionForm = new View.CoolantSelectionForm(pipelineNumber);
                View.PipelineSettingsLimits pipelineSettingsLimits = new View.PipelineSettingsLimits(pipelineNumber);
                //View.PipelineSettings2Form pipelineSettings2Form = new View.PipelineSettings2Form();

                _forms.Add(coolantSelectionForm);
                _forms.Add(pipelineSettingsLimits);
            }
        }

        private void CreateMenuItems(View.ContentMenu.DeepButtonsNames buttonName, string zeroOneString)
        {
            _menu.AddDeepButtonsByZeroOneString(buttonName, zeroOneString);
        }


        public void ChangeFormByClickOnMenu(object sender, EventArgs e)
        {
            View.ContentMenuButton button = (View.ContentMenuButton)sender;
            SetFormByName(button.ButtonName);
        }

        public void GoBack(object sender, EventArgs e) 
        {
            if(_currentFormIndex - 1 >= 0)
            {
                _currentFormIndex--;
                SetFormByIndex(_currentFormIndex);
                
            }
        }

        public void GoAhead(object sender, EventArgs e)
        {

            if(!( _consumersSet & _pipelinesSet))
            {
                SetPipelines();
                SetConsumers();

                _consumersSet = true;
                _pipelinesSet = true;
            } 

            if(_currentFormIndex + 1 < _forms.Count)
            {
                _currentFormIndex++;
                SetFormByIndex(_currentFormIndex);
                _menu.SelectButtonByName(_forms[_currentFormIndex].FormName);
            }
        }
    }
}
