using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Setup_database_for_device.View
{
    public class WindowForm : Form
    {


        public event EventHandler<EventsArgs.NextFormArgs> NextFormEvent;
        public event EventHandler<EventsArgs.NextFormArgs> PreviousFormEvent;

        protected string _formName;
        protected Components.BackOkComponent _backOkComponent;

        protected int _formIndex = 0;
        protected Dictionary<string, string> paramsToNextForm = new Dictionary<string, string>();

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

        public virtual void OnLoadForm(EventsArgs.NextFormArgs paramsFromPreviousForm, AppState appState)
        {
            
        }




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

        public virtual bool IsFormFilledOut()
        {
            return true;
        }

        private void GoToNextForm(object sender, EventArgs e) {
            OnNextFormAction();
            if (IsAbleToGoToNext())
            {
                EventsArgs.NextFormArgs args = new EventsArgs.NextFormArgs(paramsToNextForm);
                NextFormEvent?.Invoke(this, args);
            }
        }

        private void GoToPreviousForm(object sender, EventArgs e) {
            OnPreviousFormAction();

            if(IsAbleToGoToPrevious())
            {
                EventsArgs.NextFormArgs args = new EventsArgs.NextFormArgs(paramsToNextForm);
                PreviousFormEvent?.Invoke(this, args);
            }
        }

    }
}
