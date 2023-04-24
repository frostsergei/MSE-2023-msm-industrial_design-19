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

        public PipelineControl(string physicParam, CheckboxControl IsSensorUsedCheckbox, TextBoxControl ConstantValueInput)
        {
            InitializeComponent();

            PipelineSettingLabel.Content = physicParam;

            _checkbox = IsSensorUsedCheckbox;
            _textbox = ConstantValueInput;

            _checkbox.SetValue(Grid.RowProperty, 1);
            _checkbox.SetValue(Grid.ColumnProperty, 1);
            //_checkbox.AddHandler(System.Windows.Controls.Primitives.ToggleButton.CheckedEvent, new RoutedEventHandler(CheckBoxChanged));
            //_checkbox.AddHandler(System.Windows.Controls.Primitives.ToggleButton.UncheckedEvent, new RoutedEventHandler(CheckBoxChanged));
            _textbox.SetValue(Grid.RowProperty, 1);
            _textbox.SetValue(Grid.ColumnProperty, 0);

            PipelineControlBlock.Children.Add(_checkbox);
            PipelineControlBlock.Children.Add(_textbox);

        }
    }
}
