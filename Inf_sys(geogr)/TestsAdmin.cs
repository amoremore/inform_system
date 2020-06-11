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
    public partial class TestsAdmin : Form
    {
        Test test = new Test();
        public string json;
        public int position = 30;
        public TextBox[] tb = new TextBox[0];
        //TimeSpan timeSpan;
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

            string[] textfortextbox = new string[0];
            
            for (int i = 0; i < tb.Length; i++)
            {
                Array.Resize(ref textfortextbox, textfortextbox.Length + 1);
                textfortextbox[i] += tb[i].Text;
            }
            return textfortextbox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Array.Resize(ref tb, tb.Length + 1);
                    tb[tb.Length-1] = new System.Windows.Forms.TextBox();
                    tb[tb.Length-1].Location = new System.Drawing.Point(24, 155 + (tb.Length-1) * position);
                    tb[tb.Length-1].Name = "answerr" + (tb.Length-1).ToString();
                    tb[tb.Length-1].Size = new System.Drawing.Size(362, 23);
                    tb[tb.Length-1].TabIndex = tb.Length-1;
                    tb[tb.Length-1].Text = "";

                    tabPage1.Controls.Add(tb[tb.Length-1]);
                   
                
           
        }

        private void ClearPanel(Panel panel)//Очистка всех textbox на tabPage;
        {
            foreach (var ctrl in panel.Controls)
            {
                if (ctrl is TextBox tbox)
                {
                    tbox.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetQuestion setQuestion = new SetQuestion();

            setQuestion.question = quest.Text;
            setQuestion.answer = readtest();
            setQuestion.trueAnswer = trueAnswerr.Text;

            test.setQuestions.Add(setQuestion);

            quest.Text = "";
            trueAnswerr.Text = "";

            for (int i = 0; i < tb.Length; i++)
            {
                tb[i].Text = "";
            }

            if (!(string.IsNullOrEmpty(quest.Text)) && !(string.IsNullOrEmpty(trueAnswerr.Text)))
            {
                quest.Text = "";
                trueAnswerr.Text = "";
            }

            //MessageBox.Show(timeSpan.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string time = timetest.Text;
            string[] values = time.Split(':');
            TimeSpan timeSpan = new TimeSpan(Convert.ToInt32(values[0]), Convert.ToInt32(values[1]), 0);

            informsysEntities context = new informsysEntities();
            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            json = JsonSerializer.Serialize<Test>(test, jso);

            AllForTests allForTests = new AllForTests();

            allForTests.QuestAnswerTrueAnswer = json;
            allForTests.TestTopic = testtopic.Text;


            allForTests.TestTime = timeSpan;
            allForTests.TestScores = Convert.ToInt32(scorestest.Text);

            context.AllForTests.Add(allForTests);
            context.SaveChanges();

            MessageBox.Show(json);

            ClearPanel(tabPage1);
        }

        private void TestsAdmin_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "informsysDataSet1.AllForTests". При необходимости она может быть перемещена или удалена.
            this.allForTestsTableAdapter.Fill(this.informsysDataSet1.AllForTests);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "informsysDataSet.Testjson". При необходимости она может быть перемещена или удалена.
           // this.testjsonTableAdapter.Fill(this.informsysDataSet.Testjson);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                informsysEntities context = new informsysEntities();
                AllForTests allForTests = context.AllForTests.Find(dateGridViewAllfortests.Rows[e.RowIndex].Cells[0].Value);
                context.AllForTests.Remove(allForTests);
                context.SaveChanges();

                this.allForTestsTableAdapter.Fill(this.informsysDataSet1.AllForTests);
            }
        }
    }
}
