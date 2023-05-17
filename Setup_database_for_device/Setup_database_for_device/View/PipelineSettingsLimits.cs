using Setup_database_for_device.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View
{
    public partial class PipelineSettingsLimits : WindowForm

    {
        private PipelineSettings2Form _pipelineSettings2WPF;
<<<<<<< Updated upstream
        private string _curIndicator;// убрать после подсодинения к моделе                                   

        public PipelineSettingsLimits(int index) : base($"Первая настройка трубопровода {index}")
=======
        private string _curIndicator;

        public PipelineSettingsLimits(int index) : base($"Первая настройка трубопровода {index}", true)
>>>>>>> Stashed changes
        {
            InitializeComponent();
                       
            Text = "Настройка трубопроводов.Ввод значений расхода, давления и температуры";

            ElementHost host = new ElementHost
            {
                Child = _backOkComponent,
                Dock = DockStyle.Fill
            };
            OkBackButtonsPanel.Controls.Add(host);
        }

        public Dictionary<string, string> GetPipelineWindowData()
        {
            string combo1Value = "042";
            if (comboBox1.SelectedIndex == 0)
                combo1Value = "040";
            else if (comboBox1.SelectedIndex == 1)
                combo1Value = "041";
            else if (comboBox1.SelectedIndex == 2)
                combo1Value = "042";

            string combo2Value = "043";
            if (comboBox2.SelectedIndex == 0)
                combo2Value = "023";
            else if (comboBox2.SelectedIndex == 1)
                combo2Value = "024";
            else if (comboBox2.SelectedIndex == 2)
                combo2Value = "033";
            else if (comboBox2.SelectedIndex == 3)
                combo2Value = "034";
            else if (comboBox2.SelectedIndex == 4)
                combo2Value = "043";
            else if (comboBox2.SelectedIndex == 5)
                combo2Value = "044";
            else if (comboBox2.SelectedIndex == 6)
                combo2Value = "053";
            else if (comboBox2.SelectedIndex == 7)
                combo2Value = "054";
            else if (comboBox2.SelectedIndex == 8)
                combo2Value = "063";
            else if (comboBox2.SelectedIndex == 9)
                combo2Value = "064";

            Dictionary<string, string> res = new Dictionary<string, string>()
            {
                { "109н00", $"{textBox5.Text}" }, //константное значение расхода
                { "032н00", $"{combo1Value}" }, //выходной сигнал датчика избыточного давления 
                { "032н01", $"{textBox6.Text}" }, //верхний предел
                { "032н02", $"{textBox7.Text}" }, //нижний предел
                { "032н08", $"{textBox8.Text}" }, //поправка на высоту столба в имп. трубке датч. давления
                { "113н00", $"{textBox9.Text}" }, //константное значение абсолютного давления 033н00
                { "033н00", $"{combo2Value}" }, //признак подключения и тип датчика
                { "033н01", $"{textBox10.Text}" }, //верхний предел
                { "033н02", $"{textBox11.Text}" }, //нижний предел
                { "114н00", $"{textBox12.Text}" },
            };
            if (_curIndicator == "03" || _curIndicator == "04")
            {
                res.Add("034н01", $"{textBox2.Text}"); //верхний предел по паспорту прибора
                res.Add("034н02", $"{textBox1.Text}"); //нижний предел по паспорту прибора
                res.Add("034н06", $"{textBox3.Text}"); //верхний предел частоты входного сигнала
                res.Add("034н07", $"{textBox4.Text}"); //нижний предел частоты входного сигнала
            }
            else if (_curIndicator == "01" || _curIndicator == "02")
            {
                res.Add("034н01", $"{textBox13.Text}"); //верхний предел по паспорту прибора 
                res.Add("034н02", $"{textBox14.Text}"); //нижний предел по паспорту прибора
                res.Add("034н08", $"{textBox15.Text}"); //цена импульса - из паспорта прибора
            }

            return res;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PipelineSettingLimits_Load(object sender, EventArgs e)
        {
            
        }
        
        public void SetNextPipelineSettings(PipelineSettings2Form form)
        {
            _pipelineSettings2WPF = form;
        }
    
        public void SetCurIndicator(string curIndicator)
        {

            _curIndicator = $"{curIndicator[0]}{curIndicator[1]}";

            if (_curIndicator == "03" || _curIndicator == "04")
            {
                richTextBox1.Visible = true;
                richTextBox2.Visible = true;

                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;

                label1.Visible = true;
                label2.Visible = true;

                label3.Visible = true;
                label4.Visible = true;

                //turning off

                richTextBox13.Visible = false;
                textBox13.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox14.Visible = false;

                textBox15.Visible = false;
                richTextBox14.Visible = false;
            }
            if (_curIndicator == "01" || _curIndicator == "02")
            {
                richTextBox13.Visible = true;
                textBox13.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                textBox14.Visible = true;

                textBox15.Visible = true;
                richTextBox14.Visible = true;

                //turning off
                richTextBox1.Visible = false;
                richTextBox2.Visible = false;

                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;

                label1.Visible = false;
                label2.Visible = false;

                label3.Visible = false;
                label4.Visible = false;
            }
        }

        protected override bool IsAbleToGoToNext()
        {
            return true;
        }
    }

}
