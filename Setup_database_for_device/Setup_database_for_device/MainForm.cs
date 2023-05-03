﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace Setup_database_for_device
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            //DB.Test test = new DB.Test();
            TestForm subForm = new TestForm();
            subForm.TopLevel = false;
            subForm.AutoScroll = true;
            subForm.Dock = DockStyle.Fill;
            subForm.FormBorderStyle = FormBorderStyle.None;
            panelContent.Controls.Add(subForm);
            subForm.BringToFront();
            subForm.Show();

            ElementHost host = new ElementHost();


            View.ContentMenu contentMenu = new View.ContentMenu("прибор СПТ963", 10, 4);
            contentMenu.FormChanged += new EventHandler(ChangeForm);


            host.Child = contentMenu;
            host.Dock = DockStyle.Fill;
            ContentMenuPanel.Controls.Add(host);

        }

        private void ChangeForm(object sender, EventArgs e)
        {
            panelContent.Controls.Clear();
        }
    }
}
