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
    public partial class PipelineSettings2Form : Form
    {
        //в конструктор передается нижний предел частоты входного сигнала
        public PipelineSettings2Form(float lowerlimit)
        {
            //float lowerlimit = 1.1f;
            InitializeComponent();
            elementHost1.Dock = DockStyle.Fill;

            (elementHost1.Child as PipelineSettings2WPF).lowerlimitValue = lowerlimit.ToString();
        }
        public Dictionary<string, string> GetPipelineWindowData()
        {
            return (elementHost1.Child as PipelineSettings2WPF).GetPipelineSettings();
        }

    }
}
