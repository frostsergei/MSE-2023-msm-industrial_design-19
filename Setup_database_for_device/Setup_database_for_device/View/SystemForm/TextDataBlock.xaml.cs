using System.Collections.Generic;
using System.Windows.Controls;


namespace Setup_database_for_device.View.SystemForm
{
    public partial class TextDataBlock : UserControl
    {

        private static readonly string[] s_parametersNames = { "030н01", "030н02", "024", "025", "008" };

        private TextBoxControl[] _textFields;
        private CheckboxControl _checkbox;

        public TextDataBlock()
        {
            InitializeComponent();

            _textFields = new TextBoxControl[5];
            _textFields[0] = new TextBoxControl("Дискретность показаний массы теплоносителя:");
            _textFields[1] = new TextBoxControl("Дискретность показаний тепловой энергии:");
            _textFields[2] = new TextBoxControl("Расчетный час для формирования архивов за сутки:");
            _textFields[3] = new TextBoxControl("Расчетный день для формирования архивов за месяц:");
            _textFields[4] = new TextBoxControl("Номер прибора для идентификации внешними системами:");
            _checkbox = new CheckboxControl("При записи НБД в прибор ввести текущие время/дату?");
            
            for(int i = 0; i < _textFields.Length; i++)
            {
                _textFields[i].SetValue(Grid.RowProperty, i);
                _textFields[i].SetValue(Grid.ColumnProperty, 0);
                TextDataSection.Children.Add(_textFields[i]);
            }

            _checkbox.SetValue(Grid.RowProperty, 5);
            _checkbox.SetValue(Grid.ColumnProperty, 0);
            TextDataSection.Children.Add(_checkbox);

        }

        public Dictionary<string, string> GetResult()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            for(int i = 0; i < _textFields.Length; i++)
            {
                result.Add(s_parametersNames[i], _textFields[i].Value);
            }

            result.Add("CurrentTimeAndDate", _checkbox.Value);

            return result;
        }
    }
}
