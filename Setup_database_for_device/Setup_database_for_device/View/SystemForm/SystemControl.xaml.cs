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
    /// <summary>
    /// Interaction logic for SystemControl.xaml
    /// </summary>
    public partial class SystemControl : UserControl
    {
        public SystemControl()
        {
            InitializeComponent();

            ComboboxControl comb1 = new ComboboxControl("Давление/перепады давления:", new string[] { "СИ(МПа, кПа)", "Практическая система(кгс/ см ^ 2, кгс / м ^ 2)" });
            ComboboxControl comb2 = new ComboboxControl("Тепловая энергия/мощность:", new string[] { "энергия - ГДж, мощность - Гдж / ч", "энергия - Гкал, мощность - Гкал / ч", "энергия - МВт * ч, мощность - МВт" }); ;
            



            //SpecificationControl spec1 = new SpecificationControl(checkBox, textBox);
            //PipelineControl spec1 = new PipelineControl("Давление холодной воды", checkBox, textBox);

            MeasureUnitsControl measureUnitsBlock = new MeasureUnitsControl(comb1, comb2);

            //_pressureCombobox.SetValue(Grid.RowProperty, 1);
            //_pressureCombobox.SetValue(Grid.ColumnProperty, 0);
            ////_checkbox.AddHandler(System.Windows.Controls.Primitives.ToggleButton.CheckedEvent, new RoutedEventHandler(CheckBoxChanged));
            ////_checkbox.AddHandler(System.Windows.Controls.Primitives.ToggleButton.UncheckedEvent, new RoutedEventHandler(CheckBoxChanged));
            //_powerCombobox.SetValue(Grid.RowProperty, 2);
            //_powerCombobox.SetValue(Grid.ColumnProperty, 0);

            measureUnitsBlock.SetValue(Grid.RowProperty, 0);
            measureUnitsBlock.SetValue(Grid.ColumnProperty, 2);

            SystemWindowBlock.Children.Add(measureUnitsBlock);
        }
    }
}
