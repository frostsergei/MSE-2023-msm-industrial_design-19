using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Setup_database_for_device.View.SystemForm
{
    public partial class CheckboxControl : UserControl
    {

        public event EventHandler CheckBoxChecked;

        public CheckboxControl(string label, int controlWidth = -1)
        {
            InitializeComponent();

            if (controlWidth != -1)
            {
                Width = controlWidth;
            }

            InputLabel.Content = label;
        }

        public bool IsControlCheck()
        {
            return (bool)CheckboxInput.IsChecked;
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
            if (CheckBoxChecked != null)
            {
                Console.WriteLine("checked");
                CheckBoxChecked(this, EventArgs.Empty);
            }
            
        }
    }
}
