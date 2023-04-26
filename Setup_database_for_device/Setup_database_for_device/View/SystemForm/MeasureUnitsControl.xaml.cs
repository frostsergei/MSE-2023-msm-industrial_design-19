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

        public MeasureUnitsControl()
        {
            InitializeComponent();


            _pressureCombobox = new ComboboxControl("Давление/перепады давления:", new string[] { "СИ(МПа, кПа)", "Практическая система(кгс/ см ^ 2, кгс / м ^ 2)" }); 
            _powerCombobox = new ComboboxControl("Тепловая энергия/мощность:", new string[] { "энергия - ГДж, мощность - Гдж / ч", "энергия - Гкал, мощность - Гкал / ч", "энергия - МВт * ч, мощность - МВт" });

            _pressureCombobox.SetValue(Grid.RowProperty, 1);
            _pressureCombobox.SetValue(Grid.ColumnProperty, 0);
            _powerCombobox.SetValue(Grid.RowProperty, 2);
            _powerCombobox.SetValue(Grid.ColumnProperty, 0);

            MeasureUnitsControlBlock.Children.Add(_pressureCombobox);
            MeasureUnitsControlBlock.Children.Add(_powerCombobox);
        }
    }
}
