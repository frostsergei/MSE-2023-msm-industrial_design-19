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

        public event EventHandler BackButtonClickedEvent;
        public event EventHandler OkButtonClickedEvent;

        public BackOkComponent()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonClickedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            OkButtonClickedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
