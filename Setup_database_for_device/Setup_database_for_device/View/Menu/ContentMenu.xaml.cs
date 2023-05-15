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

        //private static readonly string[] s_pipelinesSettingsButtonsNames = new string[] { "Теплоноситель", "Первая настройка трубопровода", "Вторая настройка трубопровода" };
        private static readonly string[] s_pipelinesSettingsButtonsNames = new string[] { "Теплоноситель", "Первая настройка трубопровода" };

        private List<ContentMenuButton> _topButtons = new List<ContentMenuButton>(5);
        private ContentMenuButton[] _pipelinesButtons;
        private ContentMenuButton[] _consumersButtons;
        private List<ContentMenuButton> _allButtons;


        private TreeViewItem[] _topButtonsTreeViewItems;

        public ContentMenu(string deviceName)
        {

            InitializeComponent();
            

            _topButtons.Add(new ContentMenuButton(deviceName, s_topTreeGroupName));
            _topButtons.Add(new ContentMenuButton("Общесистемные параметры", s_topTreeGroupName));
            _topButtons.Add(new ContentMenuButton("Настройка трубопроводов", s_topTreeGroupName));
            _topButtons.Add(new ContentMenuButton("Настройка датчиков", s_topTreeGroupName));
            _topButtons.Add(new ContentMenuButton("Настройка потребителей", s_topTreeGroupName));

            _topButtonsTreeViewItems = WrapButtonsInTreeViewItem(_topButtons);

            foreach (ContentMenuButton a in _topButtons)
            {
                a.RadioButtonChecked += new EventHandler(ButtonClicked);
            }

            foreach (TreeViewItem el in _topButtonsTreeViewItems)
            {
                ContentMenuEl.Items.Add(el);         
            }

            _allButtons = _topButtons;


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
                ContentMenuButton currentButton = new ContentMenuButton($"{buttonName} {pipelineNumber}", $"pipelinesSettings-{pipelineNumber}"); ;
                currentButton.SetWidth(120);
                currentButton.EnableButton();
                currentButton.RadioButtonChecked += new EventHandler(ButtonClicked);

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
                    AddPipelinesSettingsButtons(TreeViewItemsWithButtonInside[i], buttonsNumbers[i]);
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
                currentButton.SetWidth(140);
                currentButton.RadioButtonChecked += new EventHandler(ButtonClicked);
                buttons.Add(currentButton);
            }

            return buttons;

        }
    }
}
