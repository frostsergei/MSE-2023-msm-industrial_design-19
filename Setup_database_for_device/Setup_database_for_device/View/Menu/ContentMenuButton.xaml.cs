using System;
using System.Windows;
using System.Windows.Controls;

namespace Setup_database_for_device.View
{
    public partial class ContentMenuButton : UserControl
    {

        public event EventHandler RadioButtonChecked;

        public ContentMenuButton(string name, string groupName)
        {
            InitializeComponent();

            RadioButtonControl.IsEnabled = true;

            ButtonName = name;
            GroupName = groupName;
            RadioButtonControl.Content = name;
            RadioButtonControl.GroupName = groupName;
            RadioButtonControl.Width = 160;

        }

        //public bool IsEnabled => (bool)RadioButtonControl.IsEnabled;
        public string ButtonName { get; }
        public string GroupName { get; }
        public bool IsChecked => (bool)RadioButtonControl.IsChecked;
        
        public void SetWidth(int width)
        {
            RadioButtonControl.Width = width;
        }

        public void EnableButton()
        {
            RadioButtonControl.IsEnabled = true;
        }

        public void DisableButton()
        {
           RadioButtonControl.IsEnabled = false;
        }

        public void CheckButton()
        {
            RadioButtonControl.IsChecked = true;
            SelectParentButton();
        }

        public void UncheckButton()
        {
            RadioButtonControl.IsChecked = false;
            UnselectChildrenButton();
        }

        private void UnselectChildrenButton()
        {
            ContentMenuButton ContentButton = (ContentMenuButton)RadioButtonControl.Parent;
            TreeViewItem TreeViewIt = (TreeViewItem)ContentButton.Parent;

            if(TreeViewIt.Items.Count != 0)
            {
                foreach (TreeViewItem item in TreeViewIt.Items)
                {
                    ContentMenuButton currentButton = (ContentMenuButton)item.Header;
                    if(currentButton.IsChecked)
                    {
                        currentButton.UncheckButton();
                    }
                }
            }
            
        }

        private void SelectParentButton()
        {
            ContentMenuButton ContentButton = (ContentMenuButton)RadioButtonControl.Parent;
            TreeViewItem TreeViewIt = (TreeViewItem)ContentButton.Parent;
            if (TreeViewIt.Parent.GetType() != typeof(TreeView))
            {
                TreeViewItem ParentTreeViewItem = (TreeViewItem)TreeViewIt.Parent;
                ContentMenuButton ParentContentButton = (ContentMenuButton)ParentTreeViewItem.Header;
                ParentContentButton.CheckButton();
            }
        }

        private void RadioButtonControl_Checked(object sender, RoutedEventArgs e)
        {
            ContentMenuButton ContentButton = (ContentMenuButton)RadioButtonControl.Parent;
            TreeViewItem TreeViewIt = (TreeViewItem)ContentButton.Parent;

            SelectParentButton();

            if (TreeViewIt.Items.Count != 0)
            {
                TreeViewIt.IsExpanded = true;
            } else
            {          
                RadioButtonChecked?.Invoke(this, EventArgs.Empty);
            }
        }

        private void RadioButtonControl_Unchecked(object sender, RoutedEventArgs e)
        {
            UnselectChildrenButton();
        }
    }
}
