using System.Windows.Controls;


namespace Setup_database_for_device.View.SystemForm
{
    public partial class TextBoxControl : UserControl
    {
        public TextBoxControl(string label, string measureUnit = "", int controlWidth = -1)
        {
            InitializeComponent();

            if(controlWidth != -1)
            {
                Width = controlWidth;
            }

            InputLabel.Content = label;
            MeasureInitLabel.Content = measureUnit;
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
