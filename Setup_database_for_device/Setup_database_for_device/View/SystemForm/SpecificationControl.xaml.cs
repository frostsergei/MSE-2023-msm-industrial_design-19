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

namespace Setup_database_for_device.View.SystemForm
{

    public partial class SpecificationControl : UserControl
    {

        private CheckboxControl _checkbox;
        private TextBoxControl _textBox;

        public SpecificationControl(CheckboxControl checkbox, TextBoxControl specificationInput)
        {
            InitializeComponent();

            _checkbox = checkbox;
            _textBox = specificationInput;

            _checkbox.SetValue(Grid.RowProperty, 0);
            _checkbox.SetValue(Grid.ColumnProperty, 0);
            _checkbox.SetValue(Grid.ColumnSpanProperty, 2);
            _checkbox.CheckBoxChecked += new EventHandler(CheckBoxChanged);    
            _textBox.SetValue(Grid.RowProperty, 1);
            _textBox.SetValue(Grid.ColumnProperty, 0);

            SpecificationControlBlock.Children.Add(_checkbox);
            SpecificationControlBlock.Children.Add(_textBox);
            
            _textBox.DisableTextBox();

        }

        private void CheckBoxChanged(object sender, EventArgs e)
        {
            if (_checkbox.IsControlCheck())
            { 
                _textBox.EnableTextBox();
            } else
            {
                _textBox.DisableTextBox();
            }
        }

    }
}
