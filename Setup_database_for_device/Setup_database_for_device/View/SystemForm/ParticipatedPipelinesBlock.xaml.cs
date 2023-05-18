using System;
using System.Collections.Generic;
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


        public ParticipatedPipelinesBlock(int participatedPipelinesCount, int participatedConsumerCount)
        {
            InitializeComponent();

            Style labelStyle = new Style();
            Style borderStyle = new Style();

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



            PipelinesTitle.Style = labelStyle;
            ConsumersTitle.Style = labelStyle;
            ParticipatedPipelinesResult.Style = labelStyle;
            ParticipatedConsumersResult.Style = labelStyle;

            ParticipatedConsumersResultBorder.Style = borderStyle;
            ParticipatedPipelinesResultBorder.Style = borderStyle;

            _participatedPipelinesCheckboxes = new CheckboxesBlock(participatedPipelinesCount, s_pipelinePrefix);
            _participatedConsumersCheckboxes = new CheckboxesBlock(participatedConsumerCount, s_consumerPrefix);

            ParticipatedPipelinesResult.Text = new string('0', participatedPipelinesCount);
            ParticipatedConsumersResult.Text = new string('0', participatedConsumerCount);

            _pipelinesResult = new string('0', participatedPipelinesCount);
            _consumersResult = new string('0', participatedConsumerCount);

            ParticipatedPipelines.Children.Add(_participatedPipelinesCheckboxes);
            ParticipatedConsumers.Children.Add(_participatedConsumersCheckboxes);

            _participatedPipelinesCheckboxes.CheckBoxesChecked += new EventHandler(ChangeParticipatedPipelinesResult);
            _participatedConsumersCheckboxes.CheckBoxesChecked += new EventHandler(ChangeParticipatedConsumersResult);

        }

        public Dictionary<string, string> GetResult()
        {
            return new Dictionary<string, string>()
            {
                { "031н00", _pipelinesResult },
                { "031н01", _consumersResult }
            };
        }

        public void Disable()
        {

            _participatedPipelinesCheckboxes.DisableBlock();
            _participatedConsumersCheckboxes.DisableBlock();

            Style labelStyle = new Style();
            Style borderStyle = new Style();


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

            PipelinesTitle.Style = labelStyle;
            ConsumersTitle.Style = labelStyle;
            ParticipatedPipelinesResult.Style = labelStyle;
            ParticipatedConsumersResult.Style = labelStyle;

            ParticipatedConsumersResultBorder.Style = borderStyle;
            ParticipatedPipelinesResultBorder.Style = borderStyle;
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
