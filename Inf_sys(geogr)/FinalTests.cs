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
        public string time;
        TimeSpan timeSpan = new TimeSpan();
        public string testtopic;
        public string nameuser;
        int trueAnswer;
        int ocenka;
        TimeSpan alltime = new TimeSpan();


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

            testtopic = allForTests.TestTopic;
            

            Test test = new Test();

            datejson = allForTests.QuestAnswerTrueAnswer;


            test = JsonSerializer.Deserialize<Test>(datejson);

            count = test.setQuestions.Count;

            balls = allForTests.TestScores;

            ballfortrueanswer = balls / count;


            time = Convert.ToString(allForTests.TestTime);
           

            
            string[] timetest = time.Split(':');
            timeSpan = new TimeSpan(Convert.ToInt32(timetest[0]), Convert.ToInt32(timetest[1]), Convert.ToInt32(timetest[2]));
            alltime = timeSpan;
            label1.Text = timeSpan.ToString("hh\\:mm\\:ss");
            timer1.Start();
         

            Array.Resize(ref qust, qust.Length + 1);

            quest.Items.Add(test.setQuestions[qust.Length - 1].question);

            otvet1.Text = test.setQuestions[qust.Length - 1].answer[0];
            otvet2.Text = test.setQuestions[qust.Length - 1].answer[1];
            if (test.setQuestions[qust.Length - 1].answer[2] != null && test.setQuestions[qust.Length - 1].answer[3] != null)
            {
                otvet3.Text = test.setQuestions[qust.Length - 1].answer[2];
                otvet4.Text = test.setQuestions[qust.Length - 1].answer[3];
                
            }
            else if (test.setQuestions[qust.Length - 1].answer[2] != null)
            {
                otvet3.Text = test.setQuestions[qust.Length - 1].answer[2];
            }
            else {
                otvet3.Visible = false;
                otvet4.Visible = false;  
            }
        }

  

        private void button1_Click(object sender, EventArgs e)
        {
            Test test1 = JsonSerializer.Deserialize<Test>(datejson);

            if (CheckRadiobuttons(groupBox1) == test1.setQuestions[qust.Length - 1].trueAnswer)
            {

                ballsfortest += ballfortrueanswer;
                trueAnswer++;

            }
            
            update();

            if (qust.Length < count)
            {


                Array.Resize(ref qust, qust.Length + 1);
                quest.Items.Add(test1.setQuestions[qust.Length - 1].question);

                otvet1.Text = test1.setQuestions[qust.Length - 1].answer[0];
                otvet2.Text = test1.setQuestions[qust.Length - 1].answer[1];
                if (test1.setQuestions[qust.Length - 1].answer[2] != null && test1.setQuestions[qust.Length - 1].answer[3] != null)
                {
                    otvet3.Text = test1.setQuestions[qust.Length - 1].answer[2];
                    otvet4.Text = test1.setQuestions[qust.Length - 1].answer[3];

                }
                else if (test1.setQuestions[qust.Length - 1].answer[2] != null)
                {
                    otvet3.Text = test1.setQuestions[qust.Length - 1].answer[2];
                }
                else
                {
                    otvet3.Visible = false;
                    otvet4.Visible = false;
                }
                resetRadioButton();
            }
            else
            {
                
                timer1.Stop();

                TimeSpan passage = new TimeSpan();
                passage = alltime - timeSpan;

                string allpassage = String.Format("{0} / {1} ", passage, alltime); 

                float way = (ballsfortest * 100) / balls;
                if (way >= 90)
                {
                    ocenka = 5;
                }
                else if (way >= 75)
                {
                    ocenka = 4;
                }
                else if (way >= 50)
                {
                    ocenka = 3;
                }
                else { ocenka = 2; }

               
                string name = nameuser;


                informsysEntities context = new informsysEntities();

                UserStatistics userStatistics = new UserStatistics();

                userStatistics.UserName = name;
                userStatistics.TestName = testtopic;
                userStatistics.TrueAnswer = String.Format("{0} / {1}", trueAnswer, count);
                userStatistics.SetBalls = String.Format("{0} / {1}", ballsfortest, balls);
                userStatistics.Way = String.Format("{0}%", way);
                userStatistics.Assessment = ocenka;
                userStatistics.traveltime = allpassage;

                context.UserStatistics.Add(userStatistics);
                context.SaveChanges();



                Statistics statistics = new Statistics();
                statistics.name = nameuser;
                this.Hide();
                statistics.Show();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sender == timer1)
            {
                if (timeSpan.TotalMinutes > 0)
                {
                    timeSpan = timeSpan.Subtract(TimeSpan.FromSeconds(1));
                    label1.Text = timeSpan.ToString();
                    
                }
                else
                {
                    timer1.Stop();
                    MessageBox.Show("Exam Time is Finished");
                }
            }
        }

        private void otvet1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void otvet2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void otvet3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void otvet4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
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