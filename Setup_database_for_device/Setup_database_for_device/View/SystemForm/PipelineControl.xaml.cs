using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace Setup_database_for_device.View.SystemForm
{

    public partial class PipelineControl : UserControl
    {

        private CheckboxControl _checkbox;
        private TextBoxControl _textbox;

        public PipelineControl(string physicParam, string defaultValue)
        {
            InitializeComponent();

            _checkbox = new CheckboxControl("Датчик");
            _textbox = new TextBoxControl("Константное значение", defaultValue);

            PipelineSettingLabel.Content = physicParam;


            _checkbox.SetValue(Grid.RowProperty, 1);
            _checkbox.SetValue(Grid.ColumnProperty, 3);
            _textbox.SetValue(Grid.RowProperty, 1);
            _textbox.SetValue(Grid.ColumnProperty, 0);
            _textbox.Margin = new System.Windows.Thickness(5, 5, 0, 0);

            PipelineControlBlock.Children.Add(_checkbox);
            PipelineControlBlock.Children.Add(_textbox);

        }

        public void DisablePipelineControl()
        {
            BorderBrush = new SolidColorBrush(Color.FromRgb(118, 118, 118));
            PipelineSettingLabel.Foreground = new SolidColorBrush(Color.FromRgb(118, 118, 118));
            _textbox.DisableControl();
            _checkbox.DisableControl();
        }

        public void EnablePipelineControl()
        {
            BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            PipelineSettingLabel.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            _textbox.EnableTextBox();
            _checkbox.EnableControl();
        }

        public Dictionary<string, string> Value => new Dictionary<string, string>()
            {
                { "TextFieldValue", _textbox.Value },
                { "CheckboxValue", _checkbox.Value }
            };
    }
}
