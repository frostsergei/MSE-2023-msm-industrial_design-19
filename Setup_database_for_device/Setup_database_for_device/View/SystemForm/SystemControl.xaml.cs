using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;


namespace Setup_database_for_device.View.SystemForm
{
    public partial class SystemControl : UserControl
    {

        private MeasureUnitsControl _measureUnitsBlock;
        private TextDataBlock _textDataBlock;
        private SpecificationBlock _specificationBlock;
        private ParticipatedPipelinesBlock _participatedPipelinesBlock;
        private PipelineBlock _pipelineBlock;

        public SystemControl(bool isBacked)
        {
            InitializeComponent();

            _measureUnitsBlock = new MeasureUnitsControl();
            _textDataBlock = new TextDataBlock();
            _specificationBlock = new SpecificationBlock();
// Change back pipelineblock and participatedpipelines
            _participatedPipelinesBlock = new ParticipatedPipelinesBlock(12, 6, isBacked);
            _pipelineBlock = new PipelineBlock(isBacked);

            _participatedPipelinesBlock.SetValue(Grid.RowProperty, 0);
            _participatedPipelinesBlock.SetValue(Grid.RowSpanProperty, 5);
            _participatedPipelinesBlock.SetValue(Grid.ColumnProperty, 0);
            
            _pipelineBlock.SetValue(Grid.RowProperty, 5);
            _pipelineBlock.SetValue(Grid.RowSpanProperty, 7);
            _pipelineBlock.SetValue(Grid.ColumnProperty, 0);
            
            _measureUnitsBlock.SetValue(Grid.RowProperty, 0);
            _measureUnitsBlock.SetValue(Grid.RowSpanProperty, 3);
            _measureUnitsBlock.SetValue(Grid.ColumnProperty, 2);

            _textDataBlock.SetValue(Grid.RowProperty, 3);
            _textDataBlock.SetValue(Grid.RowSpanProperty, 5);
            _textDataBlock.SetValue(Grid.ColumnProperty, 2);
            
            _specificationBlock.SetValue(Grid.RowProperty, 8);
            _specificationBlock.SetValue(Grid.RowSpanProperty, 3);
            _specificationBlock.SetValue(Grid.ColumnProperty, 2);

            SystemWindowBlock.Children.Add(_measureUnitsBlock);
            SystemWindowBlock.Children.Add(_textDataBlock);
            SystemWindowBlock.Children.Add(_specificationBlock);
            SystemWindowBlock.Children.Add(_participatedPipelinesBlock);
            SystemWindowBlock.Children.Add(_pipelineBlock);

        }

        public Dictionary<string, string> GetAllSystemSettings()
        {

            Dictionary<string, string> measureUnitsData = _measureUnitsBlock.GetResult();
            Dictionary<string, string> textData = _textDataBlock.GetResult();
            Dictionary<string, string> specData = _specificationBlock.GetResult();
            Dictionary<string, string> participatedPipelinesData = _participatedPipelinesBlock.GetResult();
            Dictionary<string, string> pipelinesData = _pipelineBlock.GetResult();

            foreach(KeyValuePair<string, string> a in measureUnitsData)
            {
                string e = a.Key;
                string b = a.Value;
            }

            Dictionary<string, string> result = measureUnitsData
                .Union(textData)
                .Union(specData)
                .Union(participatedPipelinesData)
                .Union(pipelinesData)
                .ToDictionary(x => x.Key, x => x.Value);

            return result;
        }
    }
}
