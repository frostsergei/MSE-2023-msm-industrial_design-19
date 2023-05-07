using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup_database_for_device.View
{
    public abstract partial class WindowForm : Form
    {

        public event EventHandler NextFormEvent;
        public event EventHandler PreviousFormEvent;

        public WindowForm()
        {
            Components.BackOkComponent backOkComponent = new Components.BackOkComponent();
            backOkComponent.BackButtonClickedEvent += new EventHandler(GoToPreviousForm);
            backOkComponent.OkButtonClickedEvent += new EventHandler(GoToNextForm);
        }

        private string _formName;

        public string FormName => _formName;

        public void GoToNextForm(object sender, EventArgs e) {
            NextFormEvent?.Invoke(this, EventArgs.Empty);
        }

        public void GoToPreviousForm(object sender, EventArgs e) {
            PreviousFormEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}
