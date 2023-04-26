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
    public partial class ParticipatedPipelinesBlock : UserControl
    {

        private static string s_pipelinePrefix = "т";
        private static string s_consumerPrefix = "п";

        private string _pipelinesResult;
        private string _consumersResult;

        private CheckboxesBlock _participatedPipelinesCheckboxes;
        private CheckboxesBlock _participatedConsumersCheckboxes;


        public ParticipatedPipelinesBlock(int participatedPipelinesCount, int participatedConsumerCount)
        {
            InitializeComponent();

            StackPanel a = FindName("ParticipatedPipelines") as StackPanel;

            _participatedPipelinesCheckboxes = new CheckboxesBlock(10, s_pipelinePrefix);
            _participatedConsumersCheckboxes = new CheckboxesBlock(8, s_consumerPrefix);

            ParticipatedPipelines.Children.Add(_participatedPipelinesCheckboxes);
            ParticipatedConsumers.Children.Add(_participatedConsumersCheckboxes);

            _participatedPipelinesCheckboxes.CheckBoxesChecked += new EventHandler(ChangeParticipatedPipelinesResult);
            _participatedConsumersCheckboxes.CheckBoxesChecked += new EventHandler(ChangeParticipatedConsumersResult);

        }

        private void ChangeParticipatedPipelinesResult(object sender, EventArgs e)
        {
            _pipelinesResult = _participatedPipelinesCheckboxes.Result;
            ParticipatedPipelinesResult.Text = _pipelinesResult;
        }

        private void ChangeParticipatedConsumersResult(object sender, EventArgs e)
        { 
            _consumersResult = _participatedConsumersCheckboxes.Result;
            ParticipatedConsumersResult.Text = _consumersResult;
        }
    }
}
