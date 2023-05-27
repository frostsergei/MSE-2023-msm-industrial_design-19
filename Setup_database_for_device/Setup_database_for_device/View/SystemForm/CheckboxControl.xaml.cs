using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class CheckboxControl : UserControl
    {

        public event EventHandler CheckBoxChecked;

        public CheckboxControl(string label)
        {
            InitializeComponent();

            CheckboxText.Text = label;
            CheckboxInput.IsChecked = false;

            CheckboxTextEl = CheckboxText;
            CheckboxElement = CheckboxInput;
        }

        public TextBlock CheckboxTextEl { get; }

        public CheckBox CheckboxElement { get; }

        public string Value => (bool)CheckboxInput.IsChecked ? "1" : "0";

        public bool IsControlCheck()
        {
            return (bool)CheckboxInput.IsChecked;
        }

        public void DisableControl()
        {

            CheckboxText.Foreground = new SolidColorBrush(Color.FromRgb(118, 118, 118));
            CheckboxInput.IsEnabled = false;
        }

  
        private void CheckboxInput_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxChecked?.Invoke(this, EventArgs.Empty);
        }
    }
}
