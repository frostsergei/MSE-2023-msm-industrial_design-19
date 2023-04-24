using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class SystemForm : Form
    {
        public SystemForm()
        {
            InitializeComponent();

            ElementHost host = new ElementHost();

            //TextBoxControl textBox = new TextBoxControl("hello world");
            //CheckboxControl checkBox = new CheckboxControl("adskfsd");
            //ComboboxControl comb1 = new ComboboxControl("dskfjk", new string[] { "dskfj", "dfkjskd"});
            //ComboboxControl comb2 = new ComboboxControl("iuiouoi", new string[] { "yreuser", "8rutreysf" });
            ////SpecificationControl spec1 = new SpecificationControl(checkBox, textBox);
            ////PipelineControl spec1 = new PipelineControl("Давление холодной воды", checkBox, textBox);
            //MeasureUnitsControl spec1 = new MeasureUnitsControl(comb1, comb2);

            SystemControl systemWindow = new SystemControl();
            host.Child = systemWindow;
            host.Dock = DockStyle.Fill;
            Controls.Add(host);
        }

        private void SystemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
