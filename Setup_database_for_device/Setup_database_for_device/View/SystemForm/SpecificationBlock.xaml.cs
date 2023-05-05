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
    public partial class SpecificationBlock : UserControl
    {

        private SpecificationControl _spec1;
        private SpecificationControl _spec2;

        public SpecificationBlock()
        {
            InitializeComponent();

            TextBoxControl spec1Textbox = new TextBoxControl("Текущее значение");
            CheckboxControl spec1Checkbox = new CheckboxControl("Изменить Спецификация-1 внешнего оборудования?");

            TextBoxControl spec2Textbox = new TextBoxControl("Текущее значение");
            CheckboxControl spec2Checkbox = new CheckboxControl("Изменить Спецификация-2 внешнего оборудования?");

            _spec1 = new SpecificationControl(spec1Checkbox, spec1Textbox);
            _spec2 = new SpecificationControl(spec2Checkbox, spec2Textbox);

            _spec1.SetValue(Grid.RowProperty, 0);
            _spec1.SetValue(Grid.ColumnProperty, 0);
            _spec1.SetValue(Grid.ColumnSpanProperty, 2);
            _spec2.SetValue(Grid.RowProperty, 1);
            _spec2.SetValue(Grid.ColumnProperty, 0);

            SpecificationSection.Children.Add(_spec1);
            SpecificationSection.Children.Add(_spec2);
        }

        public Dictionary<string, string> GetResult()
        {
            return new Dictionary<string, string>() {
                { "003", _spec1.Value },
                { "004", _spec2.Value }
            };
        }
    }
}
