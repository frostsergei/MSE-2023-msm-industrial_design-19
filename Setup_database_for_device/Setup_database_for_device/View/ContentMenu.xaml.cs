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

    public partial class ContentMenu : UserControl
    {
        private static readonly string s_topTreeGroupName = "ContentButtons";
        private static readonly string s_pipelinesTreeGroupName = "PipelinesButtons";
        private static readonly string s_consumersTreeGroupName = "ConsumersButtons";
        private static readonly string s_pipelinePrefix = "Трубопровод";
        private static readonly string s_consumersPrefix = "Потребитель";

        private TreeViewItem[] _pipelinesTreeViewItems;
        private TreeViewItem[] _consumersTreeViewItems;

        private int _pipelineCount = 2;
        private int _consumersCount = 2;

        public ContentMenu()
        {


            InitializeComponent();
            _pipelinesTreeViewItems = new TreeViewItem[_pipelineCount];

            _pipelinesTreeViewItems = GetTreeViewItems(GetNamesArray(s_pipelinePrefix, _pipelineCount), s_pipelinesTreeGroupName);
            _consumersTreeViewItems = GetTreeViewItems(GetNamesArray(s_consumersPrefix, _consumersCount), s_consumersTreeGroupName);

            TreeViewItem pipelinesSettings = FindName("PipelinesSettings") as TreeViewItem;
            TreeViewItem consumersSettings = FindName("ConsumersSettings") as TreeViewItem;

            foreach (TreeViewItem item in _pipelinesTreeViewItems)
            {
                pipelinesSettings.Items.Add(item);
            }

            foreach (TreeViewItem item in _consumersTreeViewItems)
            {
                consumersSettings.Items.Add(item);
            }

        }

        private RadioButton GetTreeViewItemInnerElement(string name, string groupName)
        {

            Style style = FindResource("SimpleButton") as Style;

            return new RadioButton
            {
                Content = name,
                GroupName = groupName,
                IsEnabled = true,
                Style = style,
                Width = 130,
                Margin = new Thickness(0, 10, 0, 0)
        };

        }

        private string[] GetNamesArray(string prefix, int elementCount)
        {
            string[] names = new string[elementCount];

            for(int i = 0; i < elementCount; i++)
            {
                names[i] = prefix + (i + 1).ToString();
            }

            return names;
        }

        private TreeViewItem[] GetTreeViewItems(string[] names, string groupName)
        {

            TreeViewItem[] result = new TreeViewItem[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                TreeViewItem currentTopTreeViewItem = new TreeViewItem();

                RadioButton radioButtonInTreeViewItem = GetTreeViewItemInnerElement(names[i], groupName);
                radioButtonInTreeViewItem.Name = s_topTreeGroupName + (i + 1).ToString();

                currentTopTreeViewItem.Header = radioButtonInTreeViewItem;

                result[i] = currentTopTreeViewItem;

            }

            return result;

        }
    }
}
