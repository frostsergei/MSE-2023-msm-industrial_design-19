using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;


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

            PipelineSettingLabel.Content = physicParam;


            _checkbox.SetValue(Grid.RowProperty, 1);
            _checkbox.SetValue(Grid.ColumnProperty, 1);
            _textbox.SetValue(Grid.RowProperty, 1);
            _textbox.SetValue(Grid.ColumnProperty, 0);

            PipelineControlBlock.Children.Add(_checkbox);
            PipelineControlBlock.Children.Add(_textbox);

        }
    }
}
