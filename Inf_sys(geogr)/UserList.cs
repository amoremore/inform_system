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
    public partial class UserList : Form
    {
        adminMain adminMain;
        public UserList(adminMain adminMain)
        {
            InitializeComponent();
            this.adminMain = adminMain;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminMain.Show();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "informsysDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.informsysDataSet.Users);

        }

        private void UpdateDataGridView()
        {
            this.usersTableAdapter.Fill(this.informsysDataSet.Users);
        }
        private void usersDataGridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                var context = new informsysEntities();
                Users users = context.Users.Find(Convert.ToInt32(usersDataGridview.Rows[e.RowIndex].Cells[0].Value));

                context.Users.Remove(users);
                context.SaveChanges();
                
                UpdateDataGridView();
            }

            
        }
    }
}
