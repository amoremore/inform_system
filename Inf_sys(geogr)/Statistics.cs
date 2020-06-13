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

        private void Statistics_Load(object sender, EventArgs e)
        {
            informsysEntities context = new informsysEntities();
            //UserStatistics userStatistics = context.UserStatistics.Where(p => p.UserName == ListsTests.name).FirstOrDefault();

            
            foreach (UserStatistics userStatistics in context.UserStatistics)
            {
                if (userStatistics.UserName == ListsTests.name)
                {
                    int rownumber = itogitesta.Rows.Add();
                    MessageBox.Show(userStatistics.UserName);
                    itogitesta.Rows[rownumber].Cells[0].Value = userStatistics.Nomer;
                    itogitesta.Rows[rownumber].Cells[1].Value = userStatistics.UserName;
                    itogitesta.Rows[rownumber].Cells[2].Value = userStatistics.TestName;
                    itogitesta.Rows[rownumber].Cells[3].Value = userStatistics.TrueAnswer;
                    itogitesta.Rows[rownumber].Cells[4].Value = userStatistics.SetBalls;
                    itogitesta.Rows[rownumber].Cells[5].Value = userStatistics.Way;
                    itogitesta.Rows[rownumber].Cells[6].Value = userStatistics.traveltime;
                    itogitesta.Rows[rownumber].Cells[7].Value = userStatistics.Assessment;

                }
                else { MessageBox.Show("user does not exist"); }
            }

         
        }
    }
}
