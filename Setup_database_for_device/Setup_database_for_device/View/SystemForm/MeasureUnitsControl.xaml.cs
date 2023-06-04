using System.Collections.Generic;
using System.Windows.Controls;


namespace Setup_database_for_device.View.SystemForm
{
    public partial class MeasureUnitsControl : UserControl
    {

        private ComboboxControl _pressureCombobox;
        private ComboboxControl _powerCombobox;

        public ComboboxControl PowerCombobox {get { return _powerCombobox; } }
        public ComboboxControl PressureCombobox { get { return _pressureCombobox; } }

        public MeasureUnitsControl()
        {
            InitializeComponent();


            _pressureCombobox = new ComboboxControl("Давление/перепады давления:", new string[] { "СИ(МПа, кПа)", "Практическая система(кгс/ см², кгс / м²)" });
            _powerCombobox = new ComboboxControl("Тепловая энергия/мощность:", new string[] { "энергия - ГДж, мощность - Гдж / ч", "энергия - Гкал, мощность - Гкал / ч", "энергия - МВт * ч, мощность - МВт" });

            _pressureCombobox.SetValue(Grid.RowProperty, 1);
            _pressureCombobox.SetValue(Grid.ColumnProperty, 0);
            _powerCombobox.SetValue(Grid.RowProperty, 2);
            _powerCombobox.SetValue(Grid.ColumnProperty, 0);

            _pressureCombobox.Margin = new System.Windows.Thickness(5, 0, 0, 0);
            _powerCombobox.Margin = new System.Windows.Thickness(5, 0, 0, 0);

            MeasureUnitsControlBlock.Children.Add(_pressureCombobox);
            MeasureUnitsControlBlock.Children.Add(_powerCombobox);
        }

        public Dictionary<string, string> GetResult()
        {
            return new Dictionary<string, string>() {

                { "030н00", $"{_pressureCombobox.Value}{_powerCombobox.Value}" }
            };
        }
    }
}
