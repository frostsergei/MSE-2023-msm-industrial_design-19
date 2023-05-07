using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup_database_for_device
{
    class FormSwitcher
    {

        private View.ContentMenu _menu;
        private View.WindowForm[] _forms;
        private int currentFormIndex = 0;

        public FormSwitcher(View.ContentMenu menu, View.WindowForm[] forms, Panel contentPanel)
        {
            _menu = menu;
            _forms = forms;

            _menu.FormChanged += new EventHandler(ChangeFormByClickOnMenu);

            foreach(View.WindowForm form in _forms)
            {
                form.NextFormEvent += new EventHandler(GoAhead);
                form.PreviousFormEvent += new EventHandler(GoBack);
            }
        }

        //private Form GetFormBy

        public void ChangeFormByClickOnMenu(object sender, EventArgs e)
        {

        }

        public void GoBack(object sender, EventArgs e) 
        {

        }

        public void GoAhead(object sender, EventArgs e)
        {

        }
    }
}
