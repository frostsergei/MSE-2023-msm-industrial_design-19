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
        private LinkedList<View.WindowForm> _forms;
        private Panel _contentPanel;   

        public FormSwitcher(View.ContentMenu menu, LinkedList<View.WindowForm> forms, Panel contentPanel)
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

        public void SetEventListenersForForm(object form, EventArgs args)
        {
            View.WindowForm _form = (View.WindowForm)form;
            _form.NextFormEvent += new EventHandler(GoAhead);
            _form.PreviousFormEvent += new EventHandler(GoBack);
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

        private void SetForm(View.WindowForm subForm)
        {
            _menu.SelectButtonByName(subForm.FormName);
            _contentPanel.Controls.Clear();
            _contentPanel.Controls.Add(subForm);
            subForm.BringToFront();
            subForm.Show();
        }

        private void SetFormByName(string name)
        {
            View.WindowForm form = GetFormByName(name);

            if(form != null)
            {
                SetForm(form);
            }
        }

        public void ChangeFormByClickOnMenu(object sender, EventArgs e)
        {
            View.ContentMenuButton button = (View.ContentMenuButton)sender;
            SetFormByName(button.ButtonName);
        }

        public void GoBack(object sender, EventArgs e) 
        {

            //_currentFormIndex--;

            //while (_currentFormIndex > 0 & _forms[_currentFormIndex].IsDisabled)
            //{
            //    _currentFormIndex--;
            //}

            //SetFormByIndex(_currentFormIndex);

        }

        public void GoAhead(object sender, EventArgs e)
        {

            //if(_currentFormIndex + 1 < _forms.Count)
            //{
            //    _currentFormIndex++;
            //    SetFormByIndex(_currentFormIndex);

            //    if(_forms[_currentFormIndex].IsDisabled)
            //    {
            //        _forms[_currentFormIndex].EnableForm();
            //    }
                
            //    _menu.SelectButtonByName(_forms[_currentFormIndex].FormName);
            //}
        }
    }
}
