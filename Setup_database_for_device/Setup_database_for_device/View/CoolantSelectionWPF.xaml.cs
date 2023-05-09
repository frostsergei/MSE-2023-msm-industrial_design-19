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

namespace Setup_database_for_device.View
{
    public partial class CoolantSelectionWPF : UserControl
    {
        public string coolantTypeValue
        {
            get { return (string)GetValue(coolantType); }
            set { SetValue(coolantType, value); }
        }

        public static DependencyProperty coolantType =
            DependencyProperty.Register("coolantType", typeof(string), typeof(CoolantSelectionWPF), new PropertyMetadata(""));


        public string flowMeterValue
        {
            get { return (string)GetValue(flowMeter); }
            set { SetValue(flowMeter, value); }
        }

        public static DependencyProperty flowMeter =
            DependencyProperty.Register("flowMeterValue", typeof(string), typeof(CoolantSelectionWPF), new PropertyMetadata(""));


        public string sensorTypeValue
        {
            get { return (string)GetValue(sensorType); }
            set { SetValue(sensorType, value); }
        }

        public static DependencyProperty sensorType =
            DependencyProperty.Register("sensorTypeValue", typeof(string), typeof(CoolantSelectionWPF), new PropertyMetadata(""));

        public string saturationWidthValue
        {
            get { return (string)GetValue(saturationWidth); }
            set { SetValue(saturationWidth, value); }
        }

        public static DependencyProperty saturationWidth =
            DependencyProperty.Register("saturationWidthValue", typeof(string), typeof(CoolantSelectionWPF), new PropertyMetadata("0"));

        public string drynessValue
        {
            get { return (string)GetValue(dryness); }
            set { SetValue(dryness, value); }
        }

        public static DependencyProperty dryness =
            DependencyProperty.Register("drynessValue", typeof(string), typeof(CoolantSelectionWPF), new PropertyMetadata("1"));

        public class Parameter
        {
            public string ParName { get; set; }
            public string ParValue { get; set; }
            public string ParUnit { get; set; }
            public string ParDescription { get; set; }
        }

        public List<Parameter> parameters;

        public CoolantSelectionWPF()
        {
            InitializeComponent();
            Group1.Visibility = Visibility.Hidden;
            ParamsGrid.Visibility = Visibility.Hidden;

            parameters = new List<Parameter>
            {
                new Parameter() { ParName = "125н00", ParUnit = "\u00B0C", ParDescription = "Нижняя точка при температуре" },
                new Parameter() { ParName = "125н01", ParUnit = "\u00B0C", ParDescription = "Верхняя точка при температуре" },
                new Parameter() { ParName = "125н02", ParUnit = "кг/м³", ParDescription = "Плотность, соответствующая Т1" },
                new Parameter() { ParName = "125н03", ParUnit = "кг/м³", ParDescription = "Плотность, соответствующая Т2" },
                new Parameter() { ParName = "125н04", ParUnit = "кДж/кг",ParDescription = "Энтальпия, соответствующая Т1" },
                new Parameter() { ParName = "125н05", ParUnit = "кДж/кг", ParDescription = "Энтальпия, соответствующая Т2" },
                new Parameter() { ParName = "125н06", ParUnit = "мкПа*с",ParDescription = "Динамическая вязкость, соответствующая Т1" },
                new Parameter() { ParName = "125н07", ParUnit = "мкПа*с", ParDescription = "Динамическая вязкость, соответствующая Т2" }
            };

            ParamsGrid.ItemsSource = parameters;
        }

        public Dictionary<string, string> GetAllCoolantSettings()
        {
            string flowMeter = "-1";
            if (Combo2.SelectedIndex == 0)
                flowMeter = "0";
            else if (Combo2.SelectedIndex == 1)
                flowMeter = "12";

            Dictionary<string, string> res = new Dictionary<string, string>()
            {
                { "101", $"{Combo1.SelectedIndex}" }, //тип теплоносителя
                { "102н00", flowMeter }, //тип расходомера
                { "034н00", $"{0}{Combo3.SelectedIndex + 1}{0}" }, //тип датчика
                { "104", $"{textbox1.Text}" }, //ширина зоны насыщения
                { "105", $"{textbox2.Text}" }, //степень сухости
                { "125н00", $"{parameters[0].ParValue}" },
                { "125н01", $"{parameters[1].ParValue}" },
                { "125н02", $"{parameters[2].ParValue}" },
                { "125н03", $"{parameters[3].ParValue}" },
                { "125н04", $"{parameters[4].ParValue}" },
                { "125н05", $"{parameters[5].ParValue}" },
                { "125н06", $"{parameters[6].ParValue}" },
                { "125н07", $"{parameters[7].ParValue}" },
            };
            return res;
        }

        private void comboChanged(object sender, RoutedEventArgs e)
        {
            if (Combo1.SelectedIndex == 1 || Combo1.SelectedIndex == 2)
            {
                Group1.Visibility = Visibility.Visible;
            }
            else
            {
                Group1.Visibility = Visibility.Hidden;
            }

            if (Combo1.SelectedIndex == 3)
            {
                ParamsGrid.Visibility = Visibility.Visible;
            }
            else
            {
                ParamsGrid.Visibility = Visibility.Hidden;
            }
        }
    }
}
