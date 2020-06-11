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

namespace Inf_sys_geogr_
{
    public partial class FinalTests : Form
    {
        string b;
        ListsTests ListsTests;
        public int kol_voprosov = 1;
        public float ballsfortest = 0;
        string datejson;
        public int count;
        public string[] qust = new string[0];
        int balls;
        float ballfortrueanswer;
        

        public FinalTests(ListsTests listsTests)
        {
            InitializeComponent();
            this.ListsTests = listsTests;
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?\n Изменения не будут сохранены!", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                ListsTests.Show();
            }

        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        
        private void update()
        {
            quest.Items.Clear();
        }

        private void resetRadioButton()
        {
            otvet1.Checked = false;
            otvet2.Checked = false;
            otvet3.Checked = false;
            otvet4.Checked = false;
        }

        private void usageСheckRadioButton()
        {

        }

        private string CheckRadiobuttons(GroupBox gb)
        {
            
            foreach (Control elm in gb.Controls)
            {
                RadioButton rb = (RadioButton)elm;
                if (rb.Checked)
                {
                    b = rb.Text;
                }
                
            }
            return b;
            
        }


        private AllForTests Loadingtest()
        {
            informsysEntities context = new informsysEntities();
            AllForTests allForTests = context.AllForTests.Find(ListsTests.Selectedtest);
            return allForTests;
        }


        private void FinalTests_Load(object sender, EventArgs e)
        {

            AllForTests allForTests = Loadingtest();

            Test test = new Test();

            datejson = allForTests.QuestAnswerTrueAnswer;


            test = JsonSerializer.Deserialize<Test>(datejson);

            count = test.setQuestions.Count;

            balls = allForTests.TestScores;

            ballfortrueanswer = balls / count;

            int time = Convert.ToInt32(allForTests.TestTime);

            TimeSpan timeSpan = new TimeSpan(time);

            MessageBox.Show(ballfortrueanswer.ToString());


            Array.Resize(ref qust, qust.Length + 1);

            quest.Items.Add(test.setQuestions[qust.Length - 1].question);

            otvet1.Text = test.setQuestions[qust.Length - 1].answer[0];
            otvet2.Text = test.setQuestions[qust.Length - 1].answer[1];
            if (test.setQuestions[qust.Length - 1].answer[2] != null)
            {
                otvet3.Text = test.setQuestions[qust.Length - 1].answer[2];
            }
            else if (test.setQuestions[qust.Length - 1].answer[3] != null)
            {
                otvet4.Text = test.setQuestions[qust.Length - 1].answer[3];
            }
            else { otvet3.Visible = false;
                   otvet4.Visible = false;
            }
        }



        public void Timerfortests()
        {
            
        }



        //Users users = Loadingtest();
        //quest.Text = users.username;
        //ListsTests.Selectedtest++;
        //Test outtest = JsonSerializer.Deserialize<Test>(ListsTests.json);

        //for (int i = 0; i < outtest.setQuestions.Count; i++)
        //{
        //    quest.Items.Add(outtest.setQuestions[i].question);

        //    for (int j = 0; j<outtest.setQuestions[i].answer.Length; j++)
        //    {
        //        quest.Items.Add(outtest.setQuestions[i].answer[j]);
        //    }

        ////}

        //switch (ListsTests.Selectedtest)
        //{
        //    case 1:
        //        for (int i = 0; i < ListsTests.Selectedtest; i++)
        //        {
        //            quest.Items.Add(outtest.setQuestions[i].question);

        //            for (int j = 0; j < outtest.setQuestions[i].answer.Length; j++)
        //            {
        //                //quest.Items.Add(outtest.setQuestions[i].answer[j]);
        //                otvet1.Text = outtest.setQuestions[i].answer[0];
        //                otvet2.Text = outtest.setQuestions[i].answer[1];
        //                otvet3.Text = outtest.setQuestions[i].answer[2];
        //                otvet4.Text = outtest.setQuestions[i].answer[3];
        //            }
        //        }
        //        break;

        //    case 2:
        //        for (int i = 1; i < ListsTests.Selectedtest; i++)
        //        {
        //            quest.Items.Add(outtest.setQuestions[0].question);

        //            for (int j = 0; j < outtest.setQuestions[i].answer.Length; j++)
        //            {
        //                quest.Items.Add(outtest.setQuestions[i].answer[j]);
        //            }
        //        }
        //        break;
        //    default:
        //        MessageBox.Show("do svyazi");
        //        break;
        //}





        private void button1_Click(object sender, EventArgs e)
        {
            Test test1 = JsonSerializer.Deserialize<Test>(datejson);

            if (CheckRadiobuttons(groupBox1) == test1.setQuestions[qust.Length - 1].trueAnswer) ballsfortest+=ballfortrueanswer;
            MessageBox.Show(ballsfortest.ToString());


            update();

            if (qust.Length < count)
            {
                

                Array.Resize(ref qust, qust.Length + 1);
                quest.Items.Add(test1.setQuestions[qust.Length - 1].question);

                otvet1.Text = test1.setQuestions[qust.Length - 1].answer[0];
                otvet2.Text = test1.setQuestions[qust.Length - 1].answer[1];
                otvet3.Text = test1.setQuestions[qust.Length - 1].answer[2];
                otvet4.Text = test1.setQuestions[qust.Length - 1].answer[3];
                resetRadioButton();
            }
            else
            {
                MessageBox.Show("TEST OKONCHEN");
            }
        }



        //switch (ListsTests.Selectedtest)
        //{

        //    case 3:


        //otvet1.Text = test1.setQuestions[qust.Length - 1].answer[0];
        //otvet1.Text = test1.setQuestions[qust.Length - 1].answer[1];
        //otvet1.Text = test1.setQuestions[qust.Length - 1].answer[2];
        //otvet1.Text = test1.setQuestions[qust.Length - 1].answer[3];








        //for (int i = 0; i < count; i++)
        //{
        //    if (test1.setQuestions[i].trueAnswer == CheckRadiobuttons(groupBox1))
        //    {
        //        { MessageBox.Show("NEKRASAVA"); }
        //    }
        //    else { MessageBox.Show("sdaa"); }   //string str = test1.setQuestions[i].trueAnswer;
        //string str1 = CheckRadiobuttons(groupBox1);
        //if (String.Equals(str,str1))



        //if (CheckRadiobuttons(groupBox1) == test1.setQuestions[i].trueAnswer[j].ToString())
        //{
        //    MessageBox.Show("gfdgjdlpg");
        //}
        //else { MessageBox.Show("иди нахуй"); }

        // }

        // MessageBox.Show(CheckRadiobuttons(groupBox1));

        //update();
        //informsysEntities context = new informsysEntities();

        //Users users = Loadingtest();
        //quest.Text = users.username;
        //ListsTests.Selectedtest++;
        // Test outtest1 = JsonSerializer.Deserialize<Test>(ListsTests.json);
        //Test test1 = JsonSerializer.Deserialize<Test>(datejson);
        //++kol_voprosov;
        //for (int i = 1; i < count; i++)
        //{
        //    resetRadioButton();
        //    update();
        //    quest.Items.Add(test1.setQuestions[i].question);
        //    for (int j = 0; j < test1.setQuestions[i].answer.Length; j++)
        //    {
        //        //quest.Items.Add(outtext1.setQuestions[i].answer[j]);
        //        otvet1.Text = test1.setQuestions[i].answer[0];
        //        otvet2.Text = test1.setQuestions[i].answer[1];
        //        otvet3.Text = test1.setQuestions[i].answer[2];
        //        otvet4.Text = test1.setQuestions[i].answer[3];
        //    }

        // }
        //    break;

        //case 4:
        //    ++kol_voprosov;
        //    //update();
        //    //informsysEntities context = new informsysEntities();

        //    //Users users = Loadingtest();
        //    //quest.Text = users.username;
        //    //ListsTests.Selectedtest++;
        //    Test outtext2 = JsonSerializer.Deserialize<Test>(ListsTests.json);

        //    for (int i = 1; i < kol_voprosov; i++)
        //    {
        //        update();
        //        quest.Items.Add(outtext2.setQuestions[i].question);
        //        for (int j = 0; j < outtext2.setQuestions[i].answer.Length; j++)
        //        {
        //            quest.Items.Add(outtext2.setQuestions[i].answer[j]);
        //        }

        //    }
        //    break;

        //default:
        //    MessageBox.Show("do svyazi2");
        //    break;


        // }




        private void button2_Click(object sender, EventArgs e)
        {
           // kol_voprosov--;
        }

        
    }
}
