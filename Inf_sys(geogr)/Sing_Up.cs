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
    public partial class Sing_Up : Form
    {
        Form1 Form1;
        public Sing_Up(Form1 form1)
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
            Users users = context.Users.Where(p => p.username == login.Text).FirstOrDefault();
            Users emaill = context.Users.Where(p => p.Email == email.Text).FirstOrDefault();
            if (users == null)
            {
                if (emaill == null)
                {
                    Users newusers = new Users();
                    newusers.username = login.Text;
                    newusers.Email = email.Text;
                    newusers.passwordd = password.Text;
                    if (password.Text == confirmpass.Text)
                    {
                        context.Users.Add(newusers);
                        context.SaveChanges();
                        this.Close();
                        Form1.Show();
                    }
                    else { attention.Visible = true; }
                      
                }
                else { busy2.Visible = true; }

            }
            else { busy.Visible = true; }
            
        }

        private void Sing_Up_Load(object sender, EventArgs e)
        {
            busy.Visible = false;
            busy2.Visible = false;
            attention.Visible = false;
        }
    }
}
