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
    public partial class Main_user : Form
    {
        
        public Main_user()
        {
            InitializeComponent();
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Main_user_Load(object sender, EventArgs e)
        {
            web.Navigate("file:///D:/Inform_system(geography)/Inf_sys(geogr)/html%20files/Main.html");
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
             Tests tests = new Tests(this);
             this.Hide();
             tests.Show();
            
        }
    }
}
