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

namespace Setup_database_for_device.View.Components
{
    public partial class BackOkComponent : UserControl
    {

        public event EventHandler LeftButtonClickedEvent;
        public event EventHandler RightButtonClickedEvent;

        public BackOkComponent()
        {
            InitializeComponent();
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            LeftButtonClickedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            RightButtonClickedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
