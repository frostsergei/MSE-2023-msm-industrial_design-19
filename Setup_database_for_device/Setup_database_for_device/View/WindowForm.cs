using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup_database_for_device.View
{
    public class WindowForm : Form
    {


        public event EventHandler NextFormEvent;
        public event EventHandler PreviousFormEvent;

        protected string _formName;
        protected Components.BackOkComponent _backOkComponent;


        public WindowForm(string formName)
        {
            _backOkComponent = new Components.BackOkComponent();
            _backOkComponent.BackButtonClickedEvent += new EventHandler(GoToPreviousForm);
            _backOkComponent.OkButtonClickedEvent += new EventHandler(GoToNextForm);

            _formName = formName;

            TopLevel = false;
            AutoScroll = true;
            Dock = DockStyle.Fill;
            FormBorderStyle = FormBorderStyle.None;
        }

        

        public string FormName => _formName;

        protected virtual void OnNextFormAction() { }
        protected virtual void OnPreviousFormAction() { }

        private void GoToNextForm(object sender, EventArgs e) {
            OnNextFormAction();
            NextFormEvent?.Invoke(this, EventArgs.Empty);
        }

        private void GoToPreviousForm(object sender, EventArgs e) {
            OnPreviousFormAction();
            PreviousFormEvent?.Invoke(this, EventArgs.Empty);
        }

    }
}
