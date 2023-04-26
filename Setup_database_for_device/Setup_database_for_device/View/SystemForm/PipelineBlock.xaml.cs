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
    public partial class PipelineBlock : UserControl
    {

        private PipelineControl[] _pipelinesSettings;

        public PipelineBlock()
        {
            InitializeComponent();

            _pipelinesSettings = new PipelineControl[4];

            //_pipelinesSettings[0] = new PipelineControl("Температура холодной воды:");
            //_pipelinesSettings[1] = new PipelineControl("Давление холодной воды:");
            //_pipelinesSettings[2] = new PipelineControl("Барометрическое давление:");
            //_pipelinesSettings[3] = new PipelineControl("Температура наружного воздуха:");


        }
    }
}
