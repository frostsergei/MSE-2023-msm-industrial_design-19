using System.Windows.Controls;
using System.Windows.Media;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class TextBoxControl : UserControl
    {

        private Label _inputLabel;
        private TextBox _textField;

        public TextBoxControl(string label, string defaultValue = "", int controlWidth = -1)
        {
            InitializeComponent();

            if(controlWidth != -1)
            {
                Width = controlWidth;
            }

            TextField.Text = defaultValue;
            InputLabel.Content = label;

            _inputLabel = InputLabel;
            _textField = TextField;
        }

        public TextBox TextFieldEl
        {
            get
            {
                return _textField;
            }
        }

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
            InputLabel.Foreground = new SolidColorBrush(Color.FromRgb(118, 118, 118));
            TextField.IsEnabled = false;
        }

        public string GetValue()
        {
            return TextField.Text;
        }
    }
}
