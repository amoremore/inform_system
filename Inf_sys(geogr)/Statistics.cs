﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inf_sys_geogr_
{
    public partial class Statistics : Form
    {

        ListsTests ListsTests;
        public Statistics(ListsTests listsTests)
        {
            InitializeComponent();
            this.ListsTests = listsTests;
           
            
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListsTests.Show();
            
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
