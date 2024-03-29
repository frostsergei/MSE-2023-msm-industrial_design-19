﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Setup_database_for_device
{
    public class FormSwitcher
    {

        private View.ContentMenu _menu;
        private LinkedList<View.WindowForm> _forms;
        private Panel _contentPanel;
        private LinkedListNode<View.WindowForm> _head;
        private AppState _appState;
        

        public FormSwitcher(View.ContentMenu menu, AppState appState, Panel contentPanel)
        {
            _menu = menu;
            _forms = appState.GetForms();
            _appState = appState;
            _contentPanel = contentPanel;

            _menu.FormChanged += new EventHandler(ChangeFormByClickOnMenu);

            foreach(View.WindowForm form in _forms)
            {
                form.NextFormEvent += new EventHandler<EventsArgs.NextFormArgs>(GoAhead);
                form.PreviousFormEvent += new EventHandler<EventsArgs.NextFormArgs>(GoBack);
            }

            _head = _forms.First;
            SetForm(_head.Value);
            _menu.SelectButtonByName(_head.Value.FormName);
           
        }

        public void SetEventListenersForForm(object form, EventArgs args)
        {
            View.WindowForm _form = (View.WindowForm)form;
            _form.NextFormEvent += new EventHandler<EventsArgs.NextFormArgs>(GoAhead);
            _form.PreviousFormEvent += new EventHandler<EventsArgs.NextFormArgs>(GoBack);
        }


        private LinkedListNode<View.WindowForm> GetFormNodeByName(string name)
        {
            LinkedListNode<View.WindowForm> currentNode = _forms.First;

            while (currentNode != null)
            {
                View.WindowForm currentForm = currentNode.Value;

                if (currentForm.FormName == name)
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        private void SetForm(View.WindowForm subForm)
        {
            _contentPanel.Controls.Clear();
            _contentPanel.Controls.Add(subForm);
            subForm.BringToFront();
            subForm.Show();
        }

        public void ChangeFormByClickOnMenu(object sender, EventArgs e)
        {
            View.ContentMenuButton button = (View.ContentMenuButton)sender;

            LinkedListNode<View.WindowForm> formNode = GetFormNodeByName(button.ButtonName);
            _head = formNode;

            if (formNode != null)
            {
                View.WindowForm currentForm = formNode.Value;
                currentForm.OnLoadForm(null, _appState);
                SetForm(currentForm);
            }
            
        }

        public void GoBack(object sender, EventsArgs.NextFormArgs e) 
        {
            LinkedListNode<View.WindowForm> previousFormNode = _head.Previous;

            if (previousFormNode != null)
            {
                View.WindowForm previousForm = previousFormNode.Value;

                SetForm(previousForm);
                previousForm.OnLoadForm(e, _appState);
                _menu.SelectButtonByName(previousForm.FormName);
            }
        }

        public void GoAhead(object sender, EventsArgs.NextFormArgs e)
        {
            LinkedListNode<View.WindowForm> nextFormNode = _head.Next;  

            if (nextFormNode != null)
            {
                View.WindowForm nextForm = nextFormNode.Value;

                SetForm(nextForm);
                nextFormNode.Value.OnLoadForm(e, _appState);
                _menu.SelectButtonByName(nextForm.FormName);
            }
        }
    }
}
