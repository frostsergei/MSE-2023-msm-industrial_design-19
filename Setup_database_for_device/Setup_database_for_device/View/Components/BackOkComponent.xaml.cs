using System;
using System.Windows.Controls;

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
            BackButtonClickedEvent?.Invoke(this, e);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            OkButtonClickedEvent?.Invoke(this, e);
        }
    }
}
