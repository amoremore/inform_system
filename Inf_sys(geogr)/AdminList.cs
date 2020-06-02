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

        }
    }
}
