using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class CheckboxControl : UserControl
    {

        public event EventHandler CheckBoxChecked;

        private CheckBox _checkboxElement;
        private Label _checkboxLabel;

        public CheckboxControl(string label, int controlWidth = -1)
        {
            InitializeComponent();

            if (controlWidth != -1)
            {
                Width = controlWidth;
            }

            InputLabel.Content = label;

            _checkboxLabel = InputLabel;
            _checkboxElement = CheckboxInput;
        }

        public Label InputLabelEl
        {
            get
            {
                return _checkboxLabel;
            }
        }

        public CheckBox CheckboxElement {
            get
            {
                return _checkboxElement;
            } 
        }

        public bool IsControlCheck()
        {
            return (bool)CheckboxInput.IsChecked;
        }

        public void DisableControl()
        {

            InputLabel.Foreground = new SolidColorBrush(Color.FromRgb(118, 118, 118));
            CheckboxInput.IsEnabled = false;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }


  
        private void CheckboxInput_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxChecked?.Invoke(this, EventArgs.Empty);
        }
    }
}
