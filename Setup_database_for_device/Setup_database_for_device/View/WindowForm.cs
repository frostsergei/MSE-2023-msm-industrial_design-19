using System;
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
        protected virtual bool IsAbleToGoToNext()
        {
            return true;
        }
        protected virtual bool IsAbleToGoToPrevious()
        {
            return true;
        }

        private void GoToNextForm(object sender, EventArgs e) {
            OnNextFormAction();
            if (IsAbleToGoToNext())
            {
                NextFormEvent?.Invoke(this, EventArgs.Empty);
            }         
        }

        private void GoToPreviousForm(object sender, EventArgs e) {
            OnPreviousFormAction();

            if(IsAbleToGoToPrevious())
            {
                PreviousFormEvent?.Invoke(this, EventArgs.Empty);
            }       
        }

    }
}
