using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        //private List<View.WindowForm> _allForms;

        private Controller.SystemController _sysController;
        private LinkedList<View.WindowForm> _allForms = new LinkedList<View.WindowForm>();

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


            ElementHost host = new ElementHost();

            _allForms.AddFirst(subForm1);
            View.ContentMenu contentMenu = new View.ContentMenu("Прибор " + deviceName);


            host.Child = contentMenu;
            host.Dock = DockStyle.Fill;
            panelLeft.Controls.Add(host);


            FormsBuilder formsBuilder = new FormsBuilder(_allForms);
            FormSwitcher formSwitcher = new FormSwitcher(contentMenu, _allForms, panelContent);
            MenuBuilder menuBuilder = new MenuBuilder(contentMenu);
            formsBuilder.NewFormCreatedEvent += new EventHandler(formSwitcher.SetEventListenersForForm);
            formsBuilder.MenuShouldBeUpdatedEvent += new EventHandler<EventsArgs.MenuEventArgs>(menuBuilder.AddNewItemInMenu);
        }

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
