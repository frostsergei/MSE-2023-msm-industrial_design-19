using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Setup_database_for_device.View
{

    public partial class ContentMenu : UserControl
    {

        public event EventHandler FormChanged;

        private static readonly string s_topTreeGroupName = "ContentButtons";
        private static readonly string s_pipelineGroupName = "PipelinesButtons";
        private static readonly string s_consumersGroupName = "ConsumersButtons";
        private static readonly string s_pipelineSettingsGroupName = "PipelinesSettingsButtons";

        private static readonly Dictionary<string, string> s_russianNames = new Dictionary<string, string>
        {
            { "PipelinesButtons", "Трубопровод" },
            { "ConsumersButtons", "Потребитель" }
        };

        public enum DeepButtonsNames
        {
            PIPELINES,
            CONSUMERS
        }

        private static readonly string[] s_pipelinesSettingsButtonsNames = new string[] { "Настройка 1", "Настройка 2" };

        private List<ContentMenuButton> _topButtons = new List<ContentMenuButton>(5);
        private ContentMenuButton[] _pipelinesButtons;
        private ContentMenuButton[] _consumersButtons;
        private List<ContentMenuButton> _allButtons;


        private TreeViewItem[] _topButtonsTreeViewItems;
        private TreeViewItem[] _pipelinesButtonsTreeViewItems;


        private int _pipelinesCount = 2;
        private int _consumersCount = 4;

        public ContentMenu(string deviceName)
        {

            InitializeComponent();
            

            _topButtons.Add(new ContentMenuButton(deviceName, s_topTreeGroupName));
            _topButtons.Add(new ContentMenuButton("Общесистемные параметры", s_topTreeGroupName));
            _topButtons.Add(new ContentMenuButton("Настройка трубопроводов", s_topTreeGroupName));
            _topButtons.Add(new ContentMenuButton("Настройка датчиков", s_topTreeGroupName));
            _topButtons.Add(new ContentMenuButton("Настройка потребителей", s_topTreeGroupName));

            _topButtonsTreeViewItems = WrapButtonsInTreeViewItem(_topButtons);

            //_topButtonsTreeViewItems[GetTopButtonIndexByButtonName("Настройка трубопроводов")].Name = "PipelinesSettings";
            //_topButtonsTreeViewItems[GetTopButtonIndexByButtonName("Настройка потребителей")].Name = "ConsumersSettings";

            foreach (ContentMenuButton a in _topButtons)
            {
                a.RadioButtonChecked += new EventHandler(ButtonClicked);
            }

            foreach (TreeViewItem el in _topButtonsTreeViewItems)
            {
                ContentMenuEl.Items.Add(el);         
            }

            //_pipelinesButtons = CreateDeepButtons(s_pipelineGroupName, _pipelinesCount);

            //int i = 0;
            //foreach (TreeViewItem el in WrapButtonsInTreeViewItem(_pipelinesButtons))
            //{
            //    topButtonsTreeViewItems[_pipelineSettingsButtonIndex].Items.Add(el);
            //    AddPipelinesSettingsButtons(el, i++);
            //}

            //_consumersButtons = CreateDeepButtons(s_consumersGroupName, _consumersCount);


            //foreach (TreeViewItem el in WrapButtonsInTreeViewItem(_consumersButtons))
            //{
            //    _topButtonsTreeViewItems[_consumersSettingsButtonIndex].Items.Add(el);
            //}

            //_allButtons = _topButtons.Concat(_pipelinesButtons).ToArray().Concat(_consumersButtons).ToArray();

            _allButtons = _topButtons;
            //EnableButtonByName("Настройка датчиков");
            //EnableButtonByName("Общесистемные параметры");
            //EnableButtonByName("Настройка потребителей");
            //EnableButtonByName("Потребитель 1");
            //EnableButtonByName("Потребитель 2");
            //EnableButtonByName("Потребитель 3");
            //EnableButtonByName("Настройка трубопроводов");
            //EnableButtonByName("Трубопровод 1");
            //EnableButtonByName("Трубопровод 2");


        }

        private int GetTopButtonIndexByButtonName(string name)
        {
            for (int i = 0; i < _topButtons.Count; i++)
            {
                if (_topButtons[i].ButtonName == name)
                {
                    return i;
                }
            }

            return -1;
        }

        private void EnableButtonByName(string name)
        {
            foreach(ContentMenuButton button in _allButtons)
            {
                if(button.ButtonName == name)
                {
                    button.EnableButton();
                    break;
                }
            }
        }

        private void AddPipelinesSettingsButtons(TreeViewItem treeViewItem, int pipelineNumber)
        {
            List<ContentMenuButton> treeViewItems = s_pipelinesSettingsButtonsNames.Select((string buttonName) =>
            {
                ContentMenuButton currentButton = new ContentMenuButton(buttonName, $"pipelinesSettings-{pipelineNumber}");
                currentButton.SetWidth(100);
                currentButton.EnableButton();

                return currentButton;
            }).ToList();

            foreach (TreeViewItem item in WrapButtonsInTreeViewItem(treeViewItems))
            {
                treeViewItem.Items.Add(item);
            }
        }

        public void SelectButtonByName(string name)
        {
            foreach (ContentMenuButton button in _allButtons)
            {
                if (button.ButtonName == name)
                {
                    button.CheckButton();
                    break;
                }
            }
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            FormChanged?.Invoke(sender, e);
        }

        public void AddDeepButtonsByZeroOneString(DeepButtonsNames buttonName, string zeroOneString)
        {

            TreeViewItem container;
            switch (buttonName)
            {
                case DeepButtonsNames.PIPELINES:
                    container = _topButtonsTreeViewItems[GetTopButtonIndexByButtonName("Настройка трубопроводов")];
                    
                    break;
                case DeepButtonsNames.CONSUMERS:
                    container = _topButtonsTreeViewItems[GetTopButtonIndexByButtonName("Настройка потребителей")];
                    break;
                default:
                    container = new TreeViewItem();
                    break;
            }

            List<int> buttonsNumbers = GetButtonsNumbersFromZeroOneString(zeroOneString);
            List<ContentMenuButton> buttons = CreateDeepButtons(buttonName, buttonsNumbers);
            TreeViewItem[] TreeViewItemsWithButtonInside = WrapButtonsInTreeViewItem(buttons);

            for(int i = 0; i < buttons.Count; i++)
            {
                container.Items.Add(TreeViewItemsWithButtonInside[i]);
                if(buttonName == DeepButtonsNames.PIPELINES)
                {
                    AddPipelinesSettingsButtons(TreeViewItemsWithButtonInside[i], i);
                }
            }

        }

        private List<int> GetButtonsNumbersFromZeroOneString(string zeroOneString)
        {

            List<int> buttonsNumbers = new List<int>();

            for (int i = 0; i < zeroOneString.Length; i++)
            {
                if (zeroOneString[i] == '1')
                {
                    buttonsNumbers.Add(i + 1);
                }
            }

            return buttonsNumbers;
        }

        private TreeViewItem[] WrapButtonsInTreeViewItem(List<ContentMenuButton> buttons)
        {

            return buttons.Select((ContentMenuButton button) =>
            {
                return new TreeViewItem
                {
                    Header = button,
                    Margin = new Thickness(0, 10, 0, 0)
            };
            }).ToArray();
        }

        private List<ContentMenuButton> CreateDeepButtons(DeepButtonsNames deepButtonName, List<int> deepButtonNumbers)
        {

            string buttonGroupName = "";
            string buttonTitle = "";

            switch (deepButtonName)
            {
                case DeepButtonsNames.PIPELINES:
                    buttonGroupName = s_pipelineGroupName;
                    buttonTitle = "Трубопровод";
                    break;
                case DeepButtonsNames.CONSUMERS:
                    buttonGroupName = s_consumersGroupName;
                    buttonTitle = "Потребитель";
                    break;
                default:
                    break;
            }


            List<ContentMenuButton> buttons = new List<ContentMenuButton>(deepButtonNumbers.Count);

            foreach (int number in deepButtonNumbers)
            {
                ContentMenuButton currentButton = new ContentMenuButton($"{buttonTitle} {number}", buttonGroupName);
                currentButton.SetWidth(120);
                buttons.Add(currentButton);
            }

            return buttons;

        }
    }
}
