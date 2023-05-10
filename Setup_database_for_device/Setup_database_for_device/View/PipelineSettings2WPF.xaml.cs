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
    public partial class PipelineSettings2WPF : UserControl
    {
        public string lowerlimitValue
        {
            get { return (string)GetValue(lowerValue); }
            set { SetValue(lowerValue, value); }
        }

        public static DependencyProperty lowerValue =
            DependencyProperty.Register("lowerlimitValue", typeof(string), typeof(PipelineSettings2WPF), new PropertyMetadata(""));

        public string par115t01n00Value
        {
            get { return (string)GetValue(par115); }
            set { SetValue(par115, value); }
        }

        public static DependencyProperty par115 =
            DependencyProperty.Register("par115t01n00Value", typeof(string), typeof(PipelineSettings2WPF), new PropertyMetadata(""));

        public string constConsumptionValue
        {
            get { return (string)GetValue(constCons); }
            set { SetValue(constCons, value); }
        }

        public static DependencyProperty constCons =
            DependencyProperty.Register("constConsumptionValue", typeof(string), typeof(PipelineSettings2WPF), new PropertyMetadata("0"));

        public PipelineSettings2WPF()
        {
            InitializeComponent();
        }

        public Dictionary<string, string> GetPipelineSettings()
        {
            string low_val = LowerValueTextBox.Text.Replace(',', '.');
            Dictionary<string, string> res = new Dictionary<string, string>()
            {
                { "115н00", $"{Par115.Content}" },
                { "115н01", $"{low_val}" },
                { "120", $"{textbox2.Text}" },
            };
            return res;
        }
        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            LowerValueTextBox.IsEnabled = false;
        }
        private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            LowerValueTextBox.IsEnabled = true;
        }
        private void comboChanged(object sender, RoutedEventArgs e)
        {
            if (Combo1.SelectedIndex == -1 || Combo2.SelectedIndex == -1)
            {
                notDefinedLabel.Visibility = Visibility.Visible;
                Par115.Content = "";
            }
            else
            {
                notDefinedLabel.Visibility = Visibility.Hidden;
                Par115.Content = Combo1.SelectedIndex.ToString() + Combo2.SelectedIndex.ToString();
                SetValue(par115, Combo1.SelectedIndex.ToString() + Combo2.SelectedIndex.ToString());
            }
        }

        private void Resize(object sender, RoutedEventArgs e)
        {
            if (Combo2.ActualWidth > 440.0f)
            {
                combo2textblock21.Text = "1 - усреднение производится независимо от величины расхода";
                combo2textblock22.Visibility = Visibility.Hidden;
            }
            else
            {
                combo2textblock21.Text = "1 - усреднение производится независимо от";
                combo2textblock22.Visibility = Visibility.Visible;
            }


            if (Combo1.ActualWidth > 625.0f)
            {
                combo1textblock11.Text = "0 - диапазон изменений ограничивается по нижнему пределу вычисленного массового расхода";
                combo1textblock12.Visibility = Visibility.Hidden;

                combo1textblock21.Text = "1 - диапазон ограничивается по измененным значениям перепада давления/объемного расхода";
                combo1textblock22.Visibility = Visibility.Hidden;
            }
            
            else
            {
                combo1textblock11.Text = "0 - диапазон изменений ограничивается по нижнему";
                combo1textblock12.Visibility = Visibility.Visible;

                combo1textblock21.Text = "1 - диапазон ограничивается по измененным";
                combo1textblock22.Visibility = Visibility.Visible;
            }
            
        }
    }
}
