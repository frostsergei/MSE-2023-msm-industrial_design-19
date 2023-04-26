using System.Windows.Controls;


namespace Setup_database_for_device.View.SystemForm
{
    public partial class TextBoxControl : UserControl
    {
        public TextBoxControl(string label, string defaultValue = "", int controlWidth = -1)
        {
            InitializeComponent();

            if(controlWidth != -1)
            {
                Width = controlWidth;
            }

            TextField.Text = defaultValue;
            InputLabel.Content = label;
        }

        public void DisableTextBox()
        {
            TextField.IsEnabled = false;
        }

        public void EnableTextBox()
        {
            TextField.IsEnabled = true;
        }

        public string GetValue()
        {
            return TextField.Text;
        }
    }
}
