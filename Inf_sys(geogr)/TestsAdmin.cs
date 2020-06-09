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
    public partial class TestsAdmin : Form
    {
        TextBox[] tb = new TextBox[5];
        adminMain adminMain;
        public TestsAdmin(adminMain adminMain)
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }


        private string[] readtest()
        {
            string[] textfortextbox = new string[] { };
            for (int i = 0; i < tb.Length; i++)
            {
                textfortextbox[i] += tb[i].Text;
            }
            return textfortextbox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextBox[] tb = new TextBox[5];
            for (int i = 0; i < tb.Length; i++)
            {
                tb[i] = new System.Windows.Forms.TextBox();
                tb[i].Location = new System.Drawing.Point(344, 133 + i * 30);
                tb[i].Name = "answerr" + i.ToString();
                tb[i].Size = new System.Drawing.Size(362, 23);
                tb[i].TabIndex = i;
                tb[i].Text = "";
                
                tabPage1.Controls.Add(tb[i]);
            }
        }

        
    }
}
