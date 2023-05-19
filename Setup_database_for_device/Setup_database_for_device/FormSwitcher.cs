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

        private void SetEventListenersForForm(object form, EventArgs args)
        {
            View.WindowForm _form = (View.WindowForm)form;
            _form.NextFormEvent += new EventHandler(GoAhead);
            _form.PreviousFormEvent += new EventHandler(GoBack);
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

        //private void SetConsumers()
        //{
        //    View.SystemForm.SystemForm systemWindow = _forms[0] as View.SystemForm.SystemForm;
        //    string zeroOneStringConsumers = systemWindow.GetParamFromWindow(consumersParam);
        //    string zeroOneStringPipelines = systemWindow.GetParamFromWindow(pipelinesParam);

        //    CreateMenuItems(View.ContentMenu.DeepButtonsNames.CONSUMERS, zeroOneStringConsumers);
        //    CreateConsumerWindows(zeroOneStringConsumers, zeroOneStringPipelines);
        //}

        //private void SetPipelines()
        //{
        //    View.SystemForm.SystemForm systemWindow = _forms[0] as View.SystemForm.SystemForm;
        //    string ZeroOneStringConsumers = systemWindow.GetParamFromWindow(pipelinesParam);


        //    CreateMenuItems(View.ContentMenu.DeepButtonsNames.PIPELINES, ZeroOneStringConsumers);
        //    CreatePipelinesWindows(ZeroOneStringConsumers);

        //}


        public void ChangeFormByClickOnMenu(object sender, EventArgs e)
        {
            View.ContentMenuButton button = (View.ContentMenuButton)sender;
            SetFormByName(button.ButtonName);
        }

        public void GoBack(object sender, EventArgs e) 
        {

            _currentFormIndex--;

            while (_currentFormIndex > 0 & _forms[_currentFormIndex].IsDisabled)
            {
                _currentFormIndex--;
            }

            SetFormByIndex(_currentFormIndex);

        }

        public void GoAhead(object sender, EventArgs e)
        {

            //if(!( _consumersSet & _pipelinesSet))
            //{
            //    SetPipelines();
            //    SetConsumers();

            //    _consumersSet = true;
            //    _pipelinesSet = true;
            //}

            if(_currentFormIndex + 1 < _forms.Count)
            {
                _currentFormIndex++;
                SetFormByIndex(_currentFormIndex);

                if(_forms[_currentFormIndex].IsDisabled)
                {
                    _forms[_currentFormIndex].EnableForm();
                }
                
                _menu.SelectButtonByName(_forms[_currentFormIndex].FormName);
            }
        }
    }
}
