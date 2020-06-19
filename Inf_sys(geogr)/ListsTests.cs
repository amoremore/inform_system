using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace Inf_sys_geogr_
{
    
    public partial class ListsTests : Form
    {
        public string name;
        public string json;
        public int Selectedtest;
        public ListsTests()
        {
            InitializeComponent();
            
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            Program.Context.MainForm = new Main_user();
            this.Close();
            Program.Context.MainForm.Show();
            
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            Test test = new Test();
          

            
            Selectedtest = 3;
            FinalTests finalTests = new FinalTests(this);
            finalTests.nameuser = name;

            this.Hide();
            finalTests.Show();

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            Selectedtest = 4;
            FinalTests finalTests = new FinalTests(this);
            this.Hide();
            finalTests.Show();

        }
    }

    class SetQuestion
    {
        public string question { get; set; }
        public string[] answer { get; set; }

        public string trueAnswer { get; set; }
    }

    class Test
    {
        public List<SetQuestion> setQuestions { get; set; }
        public Test()
        {
            this.setQuestions = new List<SetQuestion>();
        }
    }
}
