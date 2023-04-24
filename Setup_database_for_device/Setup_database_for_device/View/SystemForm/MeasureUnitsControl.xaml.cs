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
    public partial class MeasureUnitsControl : UserControl
    {

        private ComboboxControl _pressureCombobox;
        private ComboboxControl _powerCombobox;

        public MeasureUnitsControl(ComboboxControl pressureCombobox, ComboboxControl powerCombobox)
        {
            InitializeComponent();

            _pressureCombobox = pressureCombobox;
            _powerCombobox = powerCombobox;

            _pressureCombobox.SetValue(Grid.RowProperty, 1);
            _pressureCombobox.SetValue(Grid.ColumnProperty, 0);
            //_checkbox.AddHandler(System.Windows.Controls.Primitives.ToggleButton.CheckedEvent, new RoutedEventHandler(CheckBoxChanged));
            //_checkbox.AddHandler(System.Windows.Controls.Primitives.ToggleButton.UncheckedEvent, new RoutedEventHandler(CheckBoxChanged));
            _powerCombobox.SetValue(Grid.RowProperty, 2);
            _powerCombobox.SetValue(Grid.ColumnProperty, 0);

            MeasureUnitsControlBlock.Children.Add(_pressureCombobox);
            MeasureUnitsControlBlock.Children.Add(_powerCombobox);
        }
    }
}
