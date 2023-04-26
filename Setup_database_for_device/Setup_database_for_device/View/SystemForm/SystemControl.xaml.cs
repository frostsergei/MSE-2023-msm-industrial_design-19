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
    public partial class SystemControl : UserControl
    {


        public SystemControl(bool isBacked)
        {
            InitializeComponent();

            MeasureUnitsControl measureUnitsBlock = new MeasureUnitsControl();
            TextDataBlock textDataBlock = new TextDataBlock();
            SpecificationBlock specificationBlock = new SpecificationBlock();
            ParticipatedPipelinesBlock participatedPipelinesBlock = new ParticipatedPipelinesBlock(12, 8, !isBacked);
            PipelineBlock pipelineBlock = new PipelineBlock(isBacked);

            participatedPipelinesBlock.SetValue(Grid.RowProperty, 0);
            participatedPipelinesBlock.SetValue(Grid.RowSpanProperty, 5);
            participatedPipelinesBlock.SetValue(Grid.ColumnProperty, 0);

            pipelineBlock.SetValue(Grid.RowProperty, 5);
            pipelineBlock.SetValue(Grid.RowSpanProperty, 7);
            pipelineBlock.SetValue(Grid.ColumnProperty, 0);

            measureUnitsBlock.SetValue(Grid.RowProperty, 0);
            measureUnitsBlock.SetValue(Grid.RowSpanProperty, 3);
            measureUnitsBlock.SetValue(Grid.ColumnProperty, 2);

            textDataBlock.SetValue(Grid.RowProperty, 3);
            textDataBlock.SetValue(Grid.RowSpanProperty, 5);
            textDataBlock.SetValue(Grid.ColumnProperty, 2);

            specificationBlock.SetValue(Grid.RowProperty, 8);
            specificationBlock.SetValue(Grid.RowSpanProperty, 3);
            specificationBlock.SetValue(Grid.ColumnProperty, 2);

            SystemWindowBlock.Children.Add(measureUnitsBlock);
            SystemWindowBlock.Children.Add(textDataBlock);
            SystemWindowBlock.Children.Add(specificationBlock);
            SystemWindowBlock.Children.Add(participatedPipelinesBlock);
            SystemWindowBlock.Children.Add(pipelineBlock);
        }

    }
}
