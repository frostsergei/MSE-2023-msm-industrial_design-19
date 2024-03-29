﻿using System.Windows.Controls;

namespace Setup_database_for_device.View.SystemForm
{
    public partial class ComboboxControl : UserControl
    {
        public ComboboxControl(string label, string[] comboboxItems)
        {
            InitializeComponent();

            for(int i = 0; i < comboboxItems.Length; i++)
            {
                ComboboxInput.Items.Add(comboboxItems[i]);
            }

            ComboboxInput.SelectedIndex = 0;

            InputLabel.Text = label;
        }

        public string Value => ComboboxInput.SelectedIndex.ToString();

    }
}
