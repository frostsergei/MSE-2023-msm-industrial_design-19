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
    public partial class PipelineSettingsLimitsWPF : UserControl
    {
        public string curIndicator
        {
            get { return (string)GetValue(_curIndicator); }
            set { SetValue(_curIndicator, value); }
        }

        public static DependencyProperty _curIndicator =
            DependencyProperty.Register("curIndicator", typeof(string), typeof(PipelineSettingsLimitsWPF), new PropertyMetadata("03"));

        public PipelineSettingsLimitsWPF()
        {
            InitializeComponent();
        }

        public void SetWindow()
        {
            if (curIndicator == "01" || curIndicator == "02")
            {
                textBlock1.Text = "Укажите нижний и верхний предел частоты входного сигнала.";
                textbox2_high.Text = "700";

                textBlock2.Text = "Введите цену импульса из паспорта прибора";
                text_low2.Visibility = Visibility.Hidden;
                text_high2.Visibility = Visibility.Hidden;
                textbox4_high.Visibility = Visibility.Hidden;
                textbox3_low.Margin = new Thickness(18.2, 110, 0, 0);

                measure_low1.Text = "Гц";
                measure_high1.Text = "Гц";

                measure_low2.Text = "м³";
                measure_low2.Margin = new Thickness(143.2, 113, 0, 0);
                measure_high2.Visibility = Visibility.Hidden;
            }

            else if (curIndicator == "03" || curIndicator == "04")
            {
                textBlock1.Text = "Нижний и верхний диапазон измерений по паспорту прибора. Нижний предел диапазона измерений должен соответствовать настройкам выхода расходомера.";
                textbox2_high.Text = "763.400";

                textBlock2.Text = "Нижний и верхний предел частоты входного сигнала.";
                text_low2.Visibility = Visibility.Visible;
                text_high2.Visibility = Visibility.Visible;
                textbox4_high.Visibility = Visibility.Visible;
                textbox3_low.Margin = new Thickness(109.2, 110, 0, 0);

                measure_low1.Text = "м³/час";
                measure_high1.Text = "м³/час";

                measure_low2.Text = "Гц";
                measure_low2.Margin = new Thickness(234.2, 113, 0, 0);
                measure_high2.Visibility = Visibility.Visible;
            }
        }

        public Dictionary<string, string> GetPipelineSettings()
        {
            string[] cv1 = { "040", "041", "042" };

            string combo1Value = "042";
            if (comboBox1.SelectedIndex != -1)
                combo1Value = cv1[comboBox1.SelectedIndex];

            string[] cv2 = { "023", "024", "033", "034", "043", "044", "053", "054", "063", "064" };
            string combo2Value = "043";
            if (comboBox2.SelectedIndex != -1)
                combo2Value = cv2[comboBox2.SelectedIndex];

            Dictionary<string, string> res = new Dictionary<string, string>()
            {
                { "109н00", $"{textbox5.Text}" }, //константное значение расхода т/час или м^3/час
                { "032н00", $"{combo1Value}" }, //выходной сигнал датчика избыточного давления 
                { "032н01", $"{textbox7_high.Text}" }, //верхний предел мПА или кгС/см2
                { "032н08", $"{textbox8.Text}" }, //поправка на высоту столба в имп. трубке датч. давления мПА или кгС/см2
                { "113н00", $"{textbox9.Text}" }, //константное значение абсолютного давления мПА или кгС/см2
                { "033н00", $"{combo2Value}" }, //признак подключения и тип датчика
                { "033н01", $"{textbox11_high.Text}" }, //верхний предел ºС
                { "033н02", $"{textbox10_low.Text}" }, //нижний предел ºС
                { "114н00", $"{textbox12.Text}" }, //константное значение температуры теплоносителя ºС
            };
            if (textbox4_high.IsVisible)
            {
                res.Add("034н01", $"{textbox2_high.Text}"); //верхний предел по паспорту прибора м3/час или т/час (?)
                res.Add("034н02", $"{textbox1_low.Text}"); //нижний предел по паспорту прибора м3/час или т/час (?)
                res.Add("034н06", $"{textbox4_high.Text}"); //верхний предел частоты входного сигнала 
                res.Add("034н07", $"{textbox3_low.Text}"); //нижний предел частоты входного сигнала
            }
            else
            {
                res.Add("034н06", $"{textbox2_high.Text}"); //верхний предел по паспорту прибора 
                res.Add("034н07", $"{textbox1_low.Text}"); //нижний предел по паспорту прибора
                res.Add("034н08", $"{textbox3_low.Text}"); //цена импульса - из паспорта прибора м³ или т
            }
            return res;
        }

        public void SetOkBackButtons(Components.BackOkComponent okBackButton)
        {
            okBackButton.SetValue(Grid.RowProperty, 3);
            okBackButton.VerticalAlignment = VerticalAlignment.Top;
            okBackButton.SetValue(Grid.ColumnSpanProperty, 3);
            PipelineLimitsGrid.Children.Add(okBackButton);
        }
    }
}
