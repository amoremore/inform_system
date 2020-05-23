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
    public partial class Admin : Form
    {
        Form1 Form1;
        public Admin(Form1 form1)
        {
            InitializeComponent();
            this.Form1 = form1;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            informsysEntities context = new informsysEntities();
            Admins admins = context.Admins.Where(p => p.username == user.Text).FirstOrDefault();
            if (admins != null && admins.passwords == password.Text)
            {
                this.Close();
                adminMain adminMain = new adminMain(Form1);
                adminMain.Show();
            }
            else { atten.Visible = true; }

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            atten.Visible = false;
        }
    }
}
