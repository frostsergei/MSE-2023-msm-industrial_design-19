using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Setup_database_for_device.View.SystemForm
{

    public partial class PipelineControl : UserControl
    {

        private CheckboxControl _checkbox;
        private TextBoxControl _textbox;

        public PipelineControl(string physicParam, string defaultValue, bool isEnabled = false)
        {
            InitializeComponent();

            _checkbox = new CheckboxControl("Датчик");
            _textbox = new TextBoxControl("Константное значение", defaultValue);

            if (!isEnabled)
            {
                BorderBrush = new SolidColorBrush(Color.FromRgb(118, 118, 118));
                PipelineSettingLabel.Foreground = new SolidColorBrush(Color.FromRgb(118, 118, 118));
                _textbox.DisableControl();
                _checkbox.DisableControl();
            }

            PipelineSettingLabel.Content = physicParam;
            DataContext = isEnabled;


            _checkbox.SetValue(Grid.RowProperty, 1);
            _checkbox.SetValue(Grid.ColumnProperty, 2);
            _textbox.SetValue(Grid.RowProperty, 1);
            _textbox.SetValue(Grid.ColumnProperty, 0);
            _textbox.Margin = new System.Windows.Thickness(5, 5, 0, 0);

            PipelineControlBlock.Children.Add(_checkbox);
            PipelineControlBlock.Children.Add(_textbox);

        }

        public Dictionary<string, string> Value => new Dictionary<string, string>()
            {
                { "TextFieldValue", _textbox.Value },
                { "CheckboxValue", _checkbox.Value }
            };
    }
}
