using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

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
            warning.Visible = false;

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

            if (e.ColumnIndex == 4)
            {
                using (var context = new informsysEntities())
                {
                    Users users = context.Users.Find(Convert.ToInt32(usersDataGridview.Rows[e.RowIndex].Cells[0].Value));
                    if (users != null)
                    {
                        if (!(String.IsNullOrEmpty(usersDataGridview.Rows[e.RowIndex].Cells[1].Value.ToString())) && !(String.IsNullOrEmpty(usersDataGridview.Rows[e.RowIndex].Cells[2].Value.ToString()))
                            && !(String.IsNullOrEmpty(usersDataGridview.Rows[e.RowIndex].Cells[3].Value.ToString())))
                        {
                            warning.Visible = false;
                            users.username = usersDataGridview.Rows[e.RowIndex].Cells[1].Value.ToString();
                            users.Email = usersDataGridview.Rows[e.RowIndex].Cells[2].Value.ToString();
                            users.passwordd = usersDataGridview.Rows[e.RowIndex].Cells[3].Value.ToString();

                            context.Entry(users).State = EntityState.Modified;
                            context.SaveChanges();

                            UpdateDataGridView();
                        }
                        else { warning.Visible = true; }
                    }
                    else { MessageBox.Show("Пользователь не найден"); }
                }
            }
            
        }
    }
}
