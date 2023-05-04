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
    public partial class CheckboxesBlock : UserControl
    {

        public event EventHandler CheckBoxesChecked;

        private static int s_countCheckboxesInLine = 8;

        private CheckBox[] _checkboxes;
        private string _result = "";

        public string Result
        {
            get { return _result; }
        }

        public CheckboxesBlock(int countCheckboxes, string prefix, bool isEnabled)
        {
            InitializeComponent();

            _checkboxes = new CheckBox[countCheckboxes];

            
            Style labelStyle = new Style();

            if(!isEnabled)
            {
                labelStyle.Setters.Add(
                new Setter
                {
                    Property = ForegroundProperty,
                    Value = new SolidColorBrush(Color.FromRgb(118, 118, 118))
                });

            } else
            {
                labelStyle.Setters.Add(
                new Setter
                {
                    Property = ForegroundProperty,
                    Value = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                });
            }
            
        
            for (int i = 0; i < countCheckboxes; i++)
            {

                _result += "0";

                if(i % 8 == 0)
                {
                    Checkboxes.RowDefinitions.Add(new RowDefinition());
                }
                StackPanel panel = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                Label currentLabel = new Label
                {
                    Content = $"{prefix}{i + 1}",
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    FontFamily = new FontFamily("Vendena"),
                    FontSize = 9 * (96.0 / 72.0),
                    Style = labelStyle
                };

                CheckBox currentCheckbox = new CheckBox
                {
                    Width = 20,
                    VerticalAlignment = VerticalAlignment.Center,
                    IsEnabled = isEnabled
                };

                currentCheckbox.Click += new RoutedEventHandler(Checkbox_Checked);


                _checkboxes[i] = currentCheckbox;

                panel.Children.Add(currentCheckbox);
                panel.Children.Add(currentLabel);

                Grid.SetRow(panel, i / s_countCheckboxesInLine);
                Grid.SetColumn(panel, i % s_countCheckboxesInLine);

                Checkboxes.Children.Add(panel);

            }

             
        }

        public void DisableBlock()
        {
            for(int i = 0; i < _checkboxes.Length; i++)
            {

            }
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {

            _result = "";

            foreach(CheckBox checkbox in _checkboxes)
            {
                _result += (bool)checkbox.IsChecked ? "1" : "0";
            }

            Console.WriteLine(_result);
            CheckBoxesChecked(this, EventArgs.Empty);

        }

        //private void Checkboxes_changed(object sender, RoutedEventArgs e)
        //{
        //    if (CheckBoxesChecked != null)
        //    {
        //        Console.WriteLine("checked");
                
        //    }

        //}

        //CheckBoxesChecked
    }
}
