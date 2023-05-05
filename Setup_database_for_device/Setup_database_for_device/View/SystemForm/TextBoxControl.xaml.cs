using System.Windows.Controls;
using System.Windows.Media;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class TextBoxControl : UserControl
    {

        public TextBoxControl(string label, string defaultValue = "")
        {
            InitializeComponent();

            TextField.Text = defaultValue;
            InputText.Text = label;

            TextFieldEl = TextField;
        }

        public TextBox TextFieldEl { get; }

        public void DisableTextBox()
        {
            TextField.IsEnabled = false;
        }

        public void EnableTextBox()
        {
            TextField.IsEnabled = true;
        }

        public void DisableControl()
        {
            InputText.Foreground = new SolidColorBrush(Color.FromRgb(118, 118, 118));
            TextField.IsEnabled = false;
        }

        public string Value => TextField.Text;
    }
}
