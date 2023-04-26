using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


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


        public ParticipatedPipelinesBlock(int participatedPipelinesCount, int participatedConsumerCount, bool isEnabled)
        {
            InitializeComponent();

            Style labelStyle = new Style();
            Style borderStyle = new Style();

            if(!isEnabled)
            {
                labelStyle.Setters.Add(
                   new Setter
                   {
                       Property = ForegroundProperty,
                       Value = new SolidColorBrush(Color.FromRgb(118, 118, 118))
                   });

                borderStyle.Setters.Add(
                   new Setter
                   {
                       Property = BorderBrushProperty,
                       Value = new SolidColorBrush(Color.FromRgb(118, 118, 118))
                   });
            } else
            {
                labelStyle.Setters.Add(
                   new Setter
                   {
                       Property = ForegroundProperty,
                       Value = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                   });

                borderStyle.Setters.Add(
                   new Setter
                   {
                       Property = BorderBrushProperty,
                       Value = new SolidColorBrush(Color.FromRgb(0, 0, 0))
                   });
            }

            PipelinesTitle.Style = labelStyle;
            ConsumersTitle.Style = labelStyle;
            ParticipatedPipelinesResult.Style = labelStyle;
            ParticipatedConsumersResult.Style = labelStyle;

            ParticipatedConsumersResultBorder.Style = borderStyle;
            ParticipatedPipelinesResultBorder.Style = borderStyle;

            _participatedPipelinesCheckboxes = new CheckboxesBlock(participatedPipelinesCount, s_pipelinePrefix, isEnabled);
            _participatedConsumersCheckboxes = new CheckboxesBlock(participatedConsumerCount, s_consumerPrefix, isEnabled);

            ParticipatedPipelinesResult.Text = getNZerosString(participatedPipelinesCount);
            ParticipatedConsumersResult.Text = getNZerosString(participatedConsumerCount);

            ParticipatedPipelines.Children.Add(_participatedPipelinesCheckboxes);
            ParticipatedConsumers.Children.Add(_participatedConsumersCheckboxes);

            _participatedPipelinesCheckboxes.CheckBoxesChecked += new EventHandler(ChangeParticipatedPipelinesResult);
            _participatedConsumersCheckboxes.CheckBoxesChecked += new EventHandler(ChangeParticipatedConsumersResult);

        }

        private string getNZerosString(int countZeros)
        {

            string result = "";
            for(int i = 0; i < countZeros; i++)
            {
                result += "0";
            }

            return result;
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
