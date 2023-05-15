using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private List<View.WindowForm> _allForms;

        private Controller.SystemController _sysController;
        private List<View.WindowForm> _allForms = new List<View.WindowForm>();

        public MainForm(Model.Device device, Form deviceSelectionForm)
        {
            InitializeComponent();
            _device = device;
            _deviceSelectionForm = deviceSelectionForm;
            _exitFlag = true;
            _model = new Model.Model(device);
            string deviceName = "";
            switch (_device)
            {
                case Model.Device.SPT961:
                    deviceName = "СПТ 961.1";
                    break;
                case Model.Device.SPT962:
                    deviceName = "СПТ 962";
                    break;
                case Model.Device.SPT963:
                    deviceName = "СПТ 963";
                    break;
                default:
                    break;
            }

            Text = "Настройщик базы данных " + deviceName;

            View.SystemForm.SystemForm subForm1 = new View.SystemForm.SystemForm(device);
            _sysController = new Controller.SystemController(subForm1, _model);
            //TestForm subForm2 = new TestForm("Настройка датчиков");
            //View.ConsumerForm subform3 = new View.ConsumerForm(new int[] { 1, 2 }, 1);
            //View.ConsumerForm subform4 = new View.ConsumerForm(new int[] { 1, 2 }, 2);
            //View.ConsumerForm subform5 = new View.ConsumerForm(new int[] { 1, 2 }, 3);

            _allForms.Add(subForm1);

            ElementHost host = new ElementHost();
            _allForms = new List<View.WindowForm>();
            _allForms.Add(subForm1);
            View.ContentMenu contentMenu = new View.ContentMenu("Прибор " + deviceName, 2, 4);

            host.Child = contentMenu;
            host.Dock = DockStyle.Fill;
            panelLeft.Controls.Add(host);


            FormSwitcher formSwitcher = new FormSwitcher(contentMenu, _allForms, panelContent);

            //_sysController = new Controller.SystemController(subForm, _model);

        }

        //private void CreatePipelines()
        //{
        //    CreateWindow<>();
        //}

        private View.WindowForm GetFormByName(string name)
        {
            foreach (View.WindowForm form in _allForms)
            {
                if (form.Name == name)
                {
                    return form;
                }
            }

            return null;
        }

       


        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxResult confirmResult = System.Windows.MessageBox.Show("Вы уверены, что хотите начать ввод заново?", "Создание новой БД - подтверждение", MessageBoxButton.YesNo);

            if (confirmResult == MessageBoxResult.Yes)
            {
                _deviceSelectionForm.Show();
                _exitFlag = false;
                Close();
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
                saveDataFromAllForms();
                _model.SaveDataToFile(saveFileDialog.FileName.Substring(0, saveFileDialog.FileName.Length-4), "");
            }
        }

        private void saveDataFromAllForms()
        {
            foreach (var form in _allForms)
            {
                Controller.Controller controller = null;
                if (form.FormName.StartsWith("Общесистемные"))
                {
                    controller = new Controller.SystemController((View.SystemForm.SystemForm)form, _model);
                }
                else if (form.FormName.StartsWith("Потребитель"))
                {
                    controller = new Controller.ConsumerController((View.ConsumerForm)form, _model, int.Parse(Regex.Match(form.FormName, @"\d+$").Value) - 1);
                }
                else if (form.FormName.StartsWith("Теплоноситель"))
                {
                    controller = new Controller.CoolantController((View.CoolantSelectionForm)form, _model, int.Parse(Regex.Match(form.FormName, @"\d+$").Value) - 1);
                }
                else if (form.FormName.StartsWith("Первая настройка трубопровода"))
                {
                    controller = new Controller.PipelineController1((View.PipelineSettingsLimits)form, _model, int.Parse(Regex.Match(form.FormName, @"\d+$").Value) - 1);
                }
                else if (form.FormName.StartsWith("Вторая настройка трубопровода"))
                {
                    controller = new Controller.PipelineController2((View.PipelineSettings2Form)form, _model, int.Parse(Regex.Match(form.FormName, @"\d+$").Value) - 1);
                }
                if (controller != null)
                    controller.SaveDataToModel();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
