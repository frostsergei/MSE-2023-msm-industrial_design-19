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

        protected WindowForm _previousForm = null;
        protected WindowForm _nextForm = null;
        protected int _formIndex = 0;

        public WindowForm(string formName, bool isDisabled = false)
        {

            IsDisabled = isDisabled;

            _backOkComponent = new Components.BackOkComponent();
            _backOkComponent.BackButtonClickedEvent += new EventHandler(GoToPreviousForm);
            _backOkComponent.OkButtonClickedEvent += new EventHandler(GoToNextForm);

            _formName = formName;

            TopLevel = false;
            AutoScroll = true;
            Dock = DockStyle.Fill;
            FormBorderStyle = FormBorderStyle.None;
        }

        public void SetNextForm(WindowForm nextForm)
        {
            _nextForm = nextForm;
        }

        public WindowForm NextForm => _nextForm;
        public WindowForm PreviousForm => _previousForm;

        public void SetFormIndex(int index)
        {
            _formIndex = index;
        }

        public void EnableForm()
        {
            IsDisabled = false;
        }

        public bool IsDisabled { get; private set; }

        public void SetFormName(string name)
        {
            _formName = name;
        }

        public string FormName => _formName;
        public int FormIndex => _formIndex;

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
