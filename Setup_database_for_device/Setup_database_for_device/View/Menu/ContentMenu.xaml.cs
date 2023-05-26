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

        private static readonly string[] s_pipelinesSettingsButtonsNames = new string[] { "Теплоноситель", "Первая настройка трубопровода", "Вторая настройка трубопровода" };

        private List<ContentMenuButton> _topButtons = new List<ContentMenuButton>(5);
        private List<ContentMenuButton> _pipelinesButtons = new List<ContentMenuButton>();
        private List<ContentMenuButton> _consumersButtons = new List<ContentMenuButton>();

        public List<ContentMenuButton> AllButtons => _topButtons.Concat(_pipelinesButtons).Concat(_consumersButtons).ToList();

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

        public void GetButtonByName(string name)
        {
            foreach(ContentMenuButton button in _topButtons)
            {

                TreeViewItem buttonWrap = button.Parent as TreeViewItem;

                if (buttonWrap.Items.Count != 0)
                {

                }
            }
        }

        public void EnableButtonByName(string name)
        {
            foreach (ContentMenuButton button in AllButtons)
            {
                if (button.ButtonName == name)
                {
                    button.EnableButton();
                    break;
                }
            }
        }

        private void DisableButtonByName(string name)
        {
            foreach(ContentMenuButton button in AllButtons)
            {
                if(button.ButtonName == name)
                {
                    button.DisableButton();
                    break;
                }
            }
        }

        private void AddPipelinesSettingsButtons(TreeViewItem container, int pipelineNumber)
        {
            List<ContentMenuButton> pipelinesSettingsButtons = s_pipelinesSettingsButtonsNames.Select((string buttonName) =>
            {
                ContentMenuButton currentButton = new ContentMenuButton($"{buttonName} {pipelineNumber}", $"pipelinesSettings-{pipelineNumber}"); ;
                currentButton.SetWidth(120);
                currentButton.EnableButton();
                currentButton.RadioButtonChecked += new EventHandler(ButtonClicked);
                currentButton.DisableButton();

                _pipelinesButtons.Add(currentButton);

                return currentButton;
            }).ToList();

            pipelinesSettingsButtons[0].EnableButton();

            foreach (TreeViewItem item in WrapButtonsInTreeViewItem(pipelinesSettingsButtons))
            {
                container.Items.Add(item);
            }
        }


        public void SelectButtonByName(string name)
        {
            foreach (ContentMenuButton button in AllButtons)
            {
                if (button.ButtonName == name)
                {
                    button.CheckButton();
                    button.EnableButton();
                    break;
                }
            }
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            FormChanged?.Invoke(sender, e);
        }

        private TreeViewItem GetContainer(DeepButtonsNames buttonName)
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

            return container;
        }

        private List<ContentMenuButton> GetButtonListByButtonType(DeepButtonsNames buttonType)
        {
            switch (buttonType)
            {
                case DeepButtonsNames.PIPELINES:
                    return _pipelinesButtons;
                case DeepButtonsNames.CONSUMERS:
                    return _consumersButtons;
                default:
                    return _topButtons;
            }
        }

        public void AddDeepButtonsInMenuByButtonsNumbers(DeepButtonsNames buttonName, List<int> buttonsNumbers)
        {

            TreeViewItem container = GetContainer(buttonName);

            List<ContentMenuButton> buttons = GetDeepButtonsByNumbers(buttonName, buttonsNumbers);
            TreeViewItem[] TreeViewItemsWithButtonInside = WrapButtonsInTreeViewItem(buttons);
            List<ContentMenuButton> listToAddButton = GetButtonListByButtonType(buttonName);

            container.Items.Clear();
            listToAddButton.Clear();

            for (int i = 0; i < buttons.Count; i++)
            {
                container.Items.Add(TreeViewItemsWithButtonInside[i]);
                listToAddButton.Add(buttons[i]);

                if (buttonName == DeepButtonsNames.PIPELINES)
                {
                    AddPipelinesSettingsButtons(TreeViewItemsWithButtonInside[i], buttonsNumbers[i]);
                    //DisableButtonByName($"Первая настройка трубопровода {buttonsNumbers[i]}");
                    //DisableButtonByName($"Вторая настройка трубопровода {buttonsNumbers[i]}");
                }
            }

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

        private List<ContentMenuButton> GetDeepButtonsByNumbers(DeepButtonsNames deepButtonName, List<int> deepButtonNumbers)
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
                currentButton.SetButtonType(deepButtonName);
                currentButton.RadioButtonChecked += new EventHandler(ButtonClicked);
                buttons.Add(currentButton);
            }

            return buttons;

        }
    }
}
