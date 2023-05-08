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
        private View.WindowForm[] _forms;
        private Panel _contentPanel;
        private int _currentFormIndex = 0;

        public FormSwitcher(View.ContentMenu menu, View.WindowForm[] forms, Panel contentPanel)
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
            for (int i = 0; i < _forms.Length; i++)
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
            if(_currentFormIndex + 1 < _forms.Length)
            {
                _currentFormIndex++;
                SetFormByIndex(_currentFormIndex);
                _menu.SelectButtonByName(_forms[_currentFormIndex].FormName);
            }
        }
    }
}
