using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Setup_database_for_device.View
{
    public partial class ContentMenuButton : UserControl
    {

        public event EventHandler RadioButtonChecked;

        public ContentMenuButton(string name, string groupName, int width = 140)
        {
            InitializeComponent();

            RadioButtonControl.IsEnabled = false;

            ButtonName = name;
            RadioButtonControl.Content = name;
            RadioButtonControl.GroupName = groupName;
            RadioButtonControl.Width = width;

        }

        public string ButtonName { get; }

        public void EnableButton()
        {
            RadioButtonControl.IsEnabled = true;
        }

        private void RadioButtonControl_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            ContentMenuButton ContentButton = (ContentMenuButton)radioButton.Parent;
            TreeViewItem TreeViewIt = (TreeViewItem)ContentButton.Parent;
            
            if(TreeViewIt.Items.Count != 0)
            {
                TreeViewIt.IsExpanded = true;
            }

            RadioButtonChecked?.Invoke(this, EventArgs.Empty);
        }

    }
}
