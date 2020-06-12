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
    public partial class Form1 : Form
    {
        public string nameuser;
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Sing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sing_Up sing_Up = new Sing_Up(this);
            this.Hide();
            sing_Up.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
          informsysEntities context = new informsysEntities();
          Users users = context.Users.Where(p => p.username == Login.Text).FirstOrDefault();
          wrongdata.Visible = false;

           nameuser = users.username;

            if (users != null && users.passwordd == password.Text)
            {
                Main_user main_User = new Main_user();
                this.Hide();
                main_User.Show();
            }
            else { wrongdata.Visible = true; }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Admin admin = new Admin(this);
            this.Hide();
            admin.Show();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wrongdata.Visible = false;
        }
    }
}
