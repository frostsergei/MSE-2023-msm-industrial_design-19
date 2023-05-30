using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Setup_database_for_device.View
{
    public partial class ADS_97_Form : Form
    {

        public event EventHandler DataIsSetEvent;

        public ADS_97_Form()
        {
            InitializeComponent();
            AdaptersCountCombobox.SelectedIndex = 0;
            labelSecondAdapter.Visible = false;
            SecondAdapterNumber.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AdaptersCountCombobox.SelectedIndex == 0)
            {
                labelSecondAdapter.Visible = false;
                SecondAdapterNumber.Visible = false;
            }
            else
            {
                labelSecondAdapter.Visible = true;
                SecondAdapterNumber.Visible = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Dictionary<string, string> GetADS_97_results()
        {
            Dictionary<string, string> result = new Dictionary<string, string>()
            {
                { "38н00", AdaptersCountCombobox.SelectedItem.ToString() },
                { "38н01", FirstAdapterNumber.Value.ToString()},
                { "38н02", SecondAdapterNumber.Value.ToString()}
            };

            return result;
        }

        private void ADS_97_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataIsSetEvent?.Invoke(this, FormClosedEventArgs.Empty);
        }
    }
}
