using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Setup_database_for_device.View
{
    public partial class ConsumerForm : Form
    {
        public ImageList newImageList;
        public List<ComboBox> ComboBoxesList;
        //Конструктор принимает массив номеров активных трубопроводов
        public ConsumerForm(int[] pipelinesNumbers, int consumerNumber)
        {
            InitializeComponent();
            schemeNumberControl.ComboBoxMain.SelectedIndex = 0;
            labelConsumerTitle.Text = "Потребитель №" + consumerNumber.ToString();
            int leftMargin = 10;
            int topMargin = 10;
            int comboBoxWidth = 360;
            ComboBoxesList = new List<ComboBox>();
            int curY = elementHost1.Location.Y + elementHost1.Height + topMargin * 2;
            for (int i = 0; i < pipelinesNumbers.Length; i++)
            {
                Label label = new Label();
                label.Text = "Трубопровод №" + pipelinesNumbers[i].ToString();
                label.AutoSize = true;
                ComboBox comboBox = new ComboBox();
                comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox.Items.Add("Не задействован в данной схеме");
                comboBox.Items.Add("Задействован как подающий");
                comboBox.Items.Add("Задействован как обратный");
                comboBox.Items.Add("Задействован как подпитка или трубопровод ГВС");
                comboBox.Width = comboBoxWidth;
                label.Location = new Point(leftMargin, curY);
                comboBox.Location = new Point(3 * leftMargin + label.Size.Width, curY);
                this.Controls.Add(label);
                this.Controls.Add(comboBox);
                ComboBoxesList.Add(comboBox);
                curY += comboBox.Size.Height + topMargin;
            }
        }
    }
}
