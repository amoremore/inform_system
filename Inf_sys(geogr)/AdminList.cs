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
    public partial class AdminList : Form
    {
        adminMain adminMain;
        
        public AdminList(adminMain adminMain)
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

        private void AdminList_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "informsysDataSet.Admins". При необходимости она может быть перемещена или удалена.
            this.adminsTableAdapter.Fill(this.informsysDataSet.Admins);

        }

        private void adminDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                informsysEntities context = new informsysEntities();
                Admins admins = context.Admins.Find(adminDataGridView.Rows[e.RowIndex].Cells[0].Value);

                if (admins != null)
                {
                    if (!(String.IsNullOrEmpty(adminDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString())) && !(String.IsNullOrEmpty(adminDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString())))
                    {
                        warning1.Visible = false;
                        admins.username = adminDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                        admins.passwords = adminDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        context.Entry(admins).State = EntityState.Modified;
                        context.SaveChanges();

                        this.adminsTableAdapter.Fill(this.informsysDataSet.Admins);
                    }
                    else { warning1.Visible = true; }
                }
                else { MessageBox.Show("Такого пользователя не сущетвует"); }    
            }

            if (e.ColumnIndex == 4)
            {
                informsysEntities context = new informsysEntities();
                Admins deliteadmin = context.Admins.Find(adminDataGridView.Rows[e.RowIndex].Cells[0].Value);

                context.Admins.Remove(deliteadmin);
                context.SaveChanges();

                this.adminsTableAdapter.Fill(this.informsysDataSet.Admins);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addadmin.Visible = false;
            user.Visible = true;
            pass.Visible = true;
            add.Visible = true;
        }

        private void add_Click(object sender, EventArgs e)
        {
            warrring.Visible = false;
            if (!(String.IsNullOrEmpty(user.Text)) && !(String.IsNullOrEmpty(pass.Text)))
            {
                informsysEntities context = new informsysEntities();
                Admins admins = context.Admins.Where(p => p.username == user.Text).FirstOrDefault();
                if (admins == null)
                {
                    Admins newadmins = new Admins();
                    newadmins.username = user.Text;
                    newadmins.passwords = pass.Text;

                    context.Admins.Add(newadmins);
                    context.SaveChanges();
                    this.adminsTableAdapter.Fill(this.informsysDataSet.Admins);
                }
                else { warrring.Visible = true; }
            }
            else { MessageBox.Show("sdadasa"); }

            user.Text = null;
            pass.Text = null;
        }
    }
}
