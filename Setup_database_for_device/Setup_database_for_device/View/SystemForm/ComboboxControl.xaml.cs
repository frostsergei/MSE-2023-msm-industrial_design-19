using System.Windows.Controls;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class ComboboxControl : UserControl
    {
        public ComboboxControl(string label, string[] comboboxItems)
        {
            InitializeComponent();

            for(int i = 0; i < comboboxItems.Length; i++)
            {
                ComboboxInput.Items.Add(comboboxItems[i]);
            }

            InputLabel.Text = label;
        }

        public string Value { get; private set; }

        private void ComboboxInput_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)ComboboxInput.SelectedItem;
            Value = selectedItem.Content.ToString();
        }
    }
}
