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

        public SystemControl(Model.Device device)
        {
            InitializeComponent();

            _measureUnitsBlock = new MeasureUnitsControl();
            _measureUnitsBlock.PowerCombobox.ComboboxInput.SelectionChanged += PowerComboboxInput_SelectionChanged;
            _measureUnitsBlock.PressureCombobox.ComboboxInput.SelectionChanged += PressureComboboxInput_SelectionChanged;
            _textDataBlock = new TextDataBlock();
            _specificationBlock = new SpecificationBlock();

            if (device == Model.Device.SPT963)
                _participatedPipelinesBlock = new ParticipatedPipelinesBlock(16, 8);
            else
                _participatedPipelinesBlock = new ParticipatedPipelinesBlock(12, 6);
            _pipelineBlock = new PipelineBlock();

            _participatedPipelinesBlock.SetValue(Grid.RowProperty, 0);
            _participatedPipelinesBlock.SetValue(Grid.RowSpanProperty, 5);
            _participatedPipelinesBlock.SetValue(Grid.ColumnProperty, 0);

            _pipelineBlock.SetValue(Grid.RowProperty, 5);
            _pipelineBlock.SetValue(Grid.RowSpanProperty, 7);
            _pipelineBlock.SetValue(Grid.ColumnProperty, 0);

            _measureUnitsBlock.SetValue(Grid.RowProperty, 0);
            _measureUnitsBlock.SetValue(Grid.RowSpanProperty, 2);
            _measureUnitsBlock.SetValue(Grid.ColumnProperty, 2);

            _textDataBlock.SetValue(Grid.RowProperty, 2);
            _textDataBlock.SetValue(Grid.RowSpanProperty, 5);
            _textDataBlock.SetValue(Grid.ColumnProperty, 2);

            _specificationBlock.SetValue(Grid.RowProperty, 6);
            _specificationBlock.SetValue(Grid.RowSpanProperty, 3);
            _specificationBlock.SetValue(Grid.ColumnProperty, 2);

            SystemWindowBlock.Children.Add(_measureUnitsBlock);
            SystemWindowBlock.Children.Add(_textDataBlock);
            SystemWindowBlock.Children.Add(_specificationBlock);
            SystemWindowBlock.Children.Add(_participatedPipelinesBlock);
            SystemWindowBlock.Children.Add(_pipelineBlock);

            DisableSensorsSettings();
        }

        void PressureComboboxInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object objLabel = _pipelineBlock.PipelinesSettings[1].FindName("MeasurementUnitLabel");
            System.Windows.Controls.Label label = (System.Windows.Controls.Label)objLabel;
            int index = _measureUnitsBlock.PressureCombobox.ComboboxInput.SelectedIndex;
            if (index == 0) label.Content = "МПа";
            else label.Content = "кгс/см²";
        }

        void PowerComboboxInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object energyLabel = _textDataBlock.FindName("energyLabel");
            System.Windows.Controls.Label tmp = (System.Windows.Controls.Label)energyLabel;
            int index = _measureUnitsBlock.PowerCombobox.ComboboxInput.SelectedIndex;
            if (index == 0) tmp.Content = "ГДж";
            if (index == 1) tmp.Content = "ГКал";
            if (index == 2) tmp.Content = "МВт*ч";
        }

        public void SetOkBackButtons(Components.BackOkComponent backOkButtons)
        {
            backOkButtons.SetValue(Grid.RowProperty, 11);
            backOkButtons.SetValue(Grid.RowSpanProperty, 2);
            SystemWindowBlock.Children.Add(backOkButtons);
        }

        public void DisableSensorsSettings()
        {
            _pipelineBlock.DisableBlock();
        }

        public void EnableSensorsSettings()
        {
            _pipelineBlock.EnableBlock();
        }

        public void DisableParticipatedPipelinesAndConsumersBlock()
        {
            _participatedPipelinesBlock.Disable();
        }

        public Dictionary<string, string> GetAllSystemSettings()
        {

            Dictionary<string, string> measureUnitsData = _measureUnitsBlock.GetResult();
            Dictionary<string, string> textData = _textDataBlock.GetResult();
            Dictionary<string, string> specData = _specificationBlock.GetResult();
            Dictionary<string, string> participatedPipelinesData = _participatedPipelinesBlock.GetResult();
            Dictionary<string, string> pipelinesData = _pipelineBlock.GetResult();

            foreach (KeyValuePair<string, string> a in measureUnitsData)
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
