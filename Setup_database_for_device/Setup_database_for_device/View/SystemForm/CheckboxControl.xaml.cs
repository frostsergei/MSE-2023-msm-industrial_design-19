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

        public CheckboxControl(string label)
        {
            InitializeComponent();

            InputLabel.Content = label;

            InputLabelEl = InputLabel;
            CheckboxElement = CheckboxInput;
        }

        public Label InputLabelEl { get; }

        public CheckBox CheckboxElement { get; }

        public bool IsControlCheck()
        {
            return (bool)CheckboxInput.IsChecked;
        }

        public void DisableControl()
        {

            InputLabel.Foreground = new SolidColorBrush(Color.FromRgb(118, 118, 118));
            CheckboxInput.IsEnabled = false;
        }

  
        private void CheckboxInput_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxChecked?.Invoke(this, EventArgs.Empty);
        }
    }
}
