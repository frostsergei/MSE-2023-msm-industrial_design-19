using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View
{
    public partial class ConsumerForm : WindowForm
    {
        public ImageList newImageList;
        public List<ComboBox> ComboBoxesList;
        //Конструктор принимает массив номеров активных трубопроводов  
        public ConsumerForm(List<int> pipelinesNumbers, int consumerNumber) : base($"Потребитель {consumerNumber}")
        {
            InitializeComponent();

            _formIndex = consumerNumber;

            ElementHost host = new ElementHost();

            host.Child = _backOkComponent;
            host.Dock = DockStyle.Fill;
            OkButtonContainer.Controls.Add(host);

            schemeNumberControl.ComboBoxMain.SelectedIndex = 0;
            labelConsumerTitle.Text = "Потребитель №" + consumerNumber.ToString();
            int leftMargin = 10;
            int topMargin = 10;
            int comboBoxWidth = 360;
            ComboBoxesList = new List<ComboBox>();
            int curY = elementHost1.Location.Y + elementHost1.Height + topMargin * 2;
            for (int i = 0; i < pipelinesNumbers.Count; i++)
            {
                Label label = new Label
                {
                    Text = "Трубопровод №" + pipelinesNumbers[i].ToString(),
                    AutoSize = true
                };

                ComboBox comboBox = new ComboBox
                {
                    Name = "combobox" + pipelinesNumbers[i].ToString(),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                comboBox.Items.Add("Не задействован в данной схеме");
                comboBox.Items.Add("Задействован как подающий");
                comboBox.Items.Add("Задействован как обратный");
                comboBox.Items.Add("Задействован как подпитка или трубопровод ГВС");
                comboBox.SelectedIndex = 0;
                comboBox.Width = comboBoxWidth;
                label.Location = new Point(leftMargin, curY);
                comboBox.Location = new Point(3 * leftMargin + label.Size.Width, curY);
                Controls.Add(label);
                Controls.Add(comboBox);
                ComboBoxesList.Add(comboBox);
                curY += comboBox.Size.Height + topMargin;
            }
        }
    }
}
