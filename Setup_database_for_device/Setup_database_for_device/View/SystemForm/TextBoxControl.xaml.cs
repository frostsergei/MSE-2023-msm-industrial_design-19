using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class TextBoxControl : UserControl
    {

        private static readonly Regex _regex = new Regex(@"-?\d+(?:\.\d+)?");

        public TextBoxControl(string label, string defaultValue = "")
        {
            InitializeComponent();

            TextField.Text = defaultValue;
            InputText.Text = label;

            TextFieldEl = TextField;
            TextField.Padding = new System.Windows.Thickness(2);
        }

        public TextBox TextFieldEl { get; }

        public void DisableTextBox()
        {
            TextField.IsEnabled = false;
        }

        public void EnableTextBox()
        {
            InputText.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            TextField.IsEnabled = true;
        }

        public void DisableControl()
        {
            InputText.Foreground = new SolidColorBrush(Color.FromRgb(118, 118, 118));
            TextField.IsEnabled = false;
        }

        public string Value => TextField.Text;

        private bool IsTextAllowed(string text)
        {

            return double.TryParse(text, out _) | double.TryParse(text.Replace('.', ','), out _); ;
        }

        private void TextField_LostFocus(object sender, RoutedEventArgs e)
        {

            TextBox textbox = (TextBox)sender;

            if (!IsTextAllowed(textbox.Text))
            { 
                textbox.BorderThickness = new Thickness(1);
                textbox.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            } else
            {
                textbox.BorderThickness = new Thickness(1);
                textbox.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
        }
    }
}