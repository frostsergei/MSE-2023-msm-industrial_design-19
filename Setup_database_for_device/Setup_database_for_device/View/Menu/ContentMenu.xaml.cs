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
        private static readonly string s_pipelineGroupName = "PipelinesButton";
        private static readonly string s_consumersGroupName = "ConsumersButton";

        private static readonly Dictionary<string, string> s_russianNames = new Dictionary<string, string>
        {
            { "PipelinesButton", "Трубопровод" },
            { "ConsumersButton", "Потребитель" }
        };

        private ContentMenuButton[] _topButtons = new ContentMenuButton[5];
        private ContentMenuButton[] _pipelinesButtons;
        private ContentMenuButton[] _consumersButtons;
        private ContentMenuButton[] _allButtons;

        private ContentMenuButton _currentCheckedButton;


        private int _pipelineSettingsButtonIndex = 2;
        private int _consumersSettingsButtonIndex = 4;

        private int _pipelinesCount;
        private int _consumersCount;

        public ContentMenu(string deviceName, int pipelinesCount, int consumersCount)
        {

            InitializeComponent();

            _pipelinesCount = pipelinesCount;
            _consumersCount = consumersCount;

            _topButtons[0] = new ContentMenuButton(deviceName, s_topTreeGroupName);
            _topButtons[1] = new ContentMenuButton("Общесистемные параметры", s_topTreeGroupName);
            _topButtons[2] = new ContentMenuButton("Настройка трубопроводов", s_topTreeGroupName);
            _topButtons[3] = new ContentMenuButton("Настройка датчиков", s_topTreeGroupName);
            _topButtons[4] = new ContentMenuButton("Настройка потребителей", s_topTreeGroupName);


            //_currentCheckedButton = _topButtons[1];

            TreeViewItem[] topButtonsTreeViewItems = WrapButtonsInTreeViewItem(_topButtons);

            topButtonsTreeViewItems[_pipelineSettingsButtonIndex].Name = "PipelinesSettings";
            topButtonsTreeViewItems[_consumersSettingsButtonIndex].Name = "ConsumersSettings";

            foreach(ContentMenuButton a in _topButtons)
            {
                a.RadioButtonChecked += new EventHandler(ButtonClicked);
            }

            foreach (TreeViewItem el in topButtonsTreeViewItems)
            {
                ContentMenuEl.Items.Add(el);
                
            }

            _pipelinesButtons = CreateDeepButtons(s_pipelineGroupName, _pipelinesCount);

            foreach(TreeViewItem el in WrapButtonsInTreeViewItem(_pipelinesButtons))
            {
                topButtonsTreeViewItems[_pipelineSettingsButtonIndex].Items.Add(el);
            }

            _consumersButtons = CreateDeepButtons(s_consumersGroupName, _consumersCount);

            foreach (TreeViewItem el in WrapButtonsInTreeViewItem(_consumersButtons))
            {
                topButtonsTreeViewItems[_consumersSettingsButtonIndex].Items.Add(el);
            }

            _allButtons = _topButtons.Concat(_pipelinesButtons).ToArray().Concat(_consumersButtons).ToArray();

            EnableButtonByName("Настройка датчиков");
            EnableButtonByName("Общесистемные параметры");
            EnableButtonByName("Настройка потребителей");
            EnableButtonByName("Потребитель 1");
            EnableButtonByName("Потребитель 2");
            EnableButtonByName("Потребитель 3");


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

        public void SelectButtonByName(string name)
        {

            //UnselectButtons();

            foreach (ContentMenuButton button in _allButtons)
            {
                if (button.ButtonName == name)
                {
                    button.CheckButton();
                    break;
                }
            }
        }

        //public void UnselectButtons()
        //{
        //    foreach (ContentMenuButton button in _allButtons)
        //    {
        //        button.UncheckButton();
        //    }
        //}

        private void ButtonClicked(object sender, EventArgs e)
        {
            FormChanged?.Invoke(sender, e);
        }


        private TreeViewItem[] WrapButtonsInTreeViewItem(ContentMenuButton[] buttons)
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

        private ContentMenuButton[] CreateDeepButtons(string name, int itemsCount)
        {

            ContentMenuButton[] buttons = new ContentMenuButton[itemsCount];

            for (int i = 0; i < itemsCount; i++)
            {
                buttons[i] = new ContentMenuButton($"{s_russianNames[name]} {i + 1}", name, 120);
                buttons[i].RadioButtonChecked += new EventHandler(ButtonClicked);
            }

            return buttons;

        }
    }
}
