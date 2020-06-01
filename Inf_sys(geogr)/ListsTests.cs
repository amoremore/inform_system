using System;
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
    public partial class ListsTests : Form
    {
        public int Selectedtest;
        Main_user main_User;
        public ListsTests(Main_user main_User)
        {
            InitializeComponent();
            this.main_User = main_User;
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            main_User.Show();
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            FinalTests finalTests = new FinalTests(this);
            Selectedtest = 1;
            this.Hide();
            finalTests.Show();

        }
    }
}
