using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device
{
    public partial class MainForm : Form
    {
        private Model.Device _device;

        private Form _deviceSelectionForm;

        private bool _exitFlag;

        private Model.Model _model;

        public MainForm(Model.Device device, Form deviceSelectionForm)
        {
            InitializeComponent();
            _device = device;
            _deviceSelectionForm = deviceSelectionForm;
            _exitFlag = true;
            _model = new Model.Model(device);
            string title = "Настройщик базы данных ";
            switch (_device)
            {
                case Model.Device.SPT961:
                    title = title + "СПТ 961";
                    break;
                case Model.Device.SPT962:
                    title = title + "СПТ 962";
                    break;
                case Model.Device.SPT963:
                    title = title + "СПТ 963";
                    break;
                default:
                    break;
            }
            this.Text = title;
            //DB.Test test = new DB.Test();
            TestForm subForm = new TestForm();
            subForm.TopLevel = false;
            subForm.AutoScroll = true;
            subForm.Dock = DockStyle.Fill;
            subForm.FormBorderStyle = FormBorderStyle.None;
            panelContent.Controls.Add(subForm);
            subForm.BringToFront();
            subForm.Show();

            ElementHost host = new ElementHost();


            View.ContentMenu contentMenu = new View.ContentMenu("прибор СПТ963", 10, 4);
            contentMenu.FormChanged += new EventHandler(ChangeForm);


            host.Child = contentMenu;
            host.Dock = DockStyle.Fill;
            panelLeft.Controls.Add(host);

        }

        private void ChangeForm(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxResult confirmResult = System.Windows.MessageBox.Show("Вы уверены, что хотите начать ввод заново?", "Создание новой БД - подтверждение", MessageBoxButton.YesNo);

            if (confirmResult == MessageBoxResult.Yes)
            {
                _deviceSelectionForm.Show();
                _exitFlag = false;
                this.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_exitFlag == true)
                _deviceSelectionForm.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Сохранение базы данных";
            saveFileDialog.Filter = "Configurator DB files|*.xdb";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                _model.SaveDataToFile(saveFileDialog.FileName.Substring(0, saveFileDialog.FileName.Length-4), "");
            }
        }
    }
}
