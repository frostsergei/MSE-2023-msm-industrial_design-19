﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Setup_database_for_device
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DB.Test test = new DB.Test();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "Кнопка нажата";
        }
    }
}