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
    public partial class FinalTests : Form
    {
        ListsTests ListsTests;
        
        public FinalTests(ListsTests listsTests)
        {
            InitializeComponent();
            this.ListsTests = listsTests;
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?\n Изменения не будут сохранены!","", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                ListsTests.Show();
            }
            
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private Users Loadingtest()
        {
            informsysEntities context = new informsysEntities();
            Users users = context.Users.Find(ListsTests.Selectedtest);
            return users;
        }


        private void FinalTests_Load(object sender, EventArgs e)
        {
           
            Users users = Loadingtest();
            quest.Text = users.username;
            ListsTests.Selectedtest++;
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            informsysEntities context = new informsysEntities();
            
            Users users = Loadingtest();
            quest.Text = users.username;
            ListsTests.Selectedtest++;
        }
    }
}
