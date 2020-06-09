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
        ListsTests ListsTests;
        public int kol_voprosov = 1;
        
        public FinalTests(ListsTests listsTests)
        {
            InitializeComponent();
            this.ListsTests = listsTests;
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?\n Изменения не будут сохранены!","", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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

        private Users Loadingtest()
        {
            informsysEntities context = new informsysEntities();
            Users users = context.Users.Find(ListsTests.Selectedtest);
            return users;
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


        private void FinalTests_Load(object sender, EventArgs e)
        {

            //Users users = Loadingtest();
            //quest.Text = users.username;
            //ListsTests.Selectedtest++;
            Test outtest = JsonSerializer.Deserialize<Test>(ListsTests.json);

            //for (int i = 0; i < outtest.setQuestions.Count; i++)
            //{
            //    quest.Items.Add(outtest.setQuestions[i].question);

            //    for (int j = 0; j<outtest.setQuestions[i].answer.Length; j++)
            //    {
            //        quest.Items.Add(outtest.setQuestions[i].answer[j]);
            //    }

            //}

            switch (ListsTests.Selectedtest)
            {
                case 1:
                    for (int i = 0; i < ListsTests.Selectedtest; i++)
                    {
                        quest.Items.Add(outtest.setQuestions[i].question);

                        for (int j = 0; j < outtest.setQuestions[i].answer.Length; j++)
                        {
                            //quest.Items.Add(outtest.setQuestions[i].answer[j]);
                            otvet1.Text = outtest.setQuestions[i].answer[0];
                            otvet2.Text = outtest.setQuestions[i].answer[1];
                            otvet3.Text = outtest.setQuestions[i].answer[2];
                            otvet4.Text = outtest.setQuestions[i].answer[3];
                        }
                    }
                    break;

                case 2:
                    for (int i = 1; i < ListsTests.Selectedtest; i++)
                    {
                        quest.Items.Add(outtest.setQuestions[0].question);

                        for (int j = 0; j < outtest.setQuestions[i].answer.Length; j++)
                        {
                            quest.Items.Add(outtest.setQuestions[i].answer[j]);
                        }
                    }
                    break;
                default:
                    MessageBox.Show("do svyazi");
                    break;
            }

          



        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (ListsTests.Selectedtest)
            {
                case 1:
                    ++kol_voprosov;
                    //update();
                    //informsysEntities context = new informsysEntities();

                    //Users users = Loadingtest();
                    //quest.Text = users.username;
                    //ListsTests.Selectedtest++;
                    Test outtest1 = JsonSerializer.Deserialize<Test>(ListsTests.json);
                   
                    for (int i = 1; i < kol_voprosov; i++)
                    {
                        resetRadioButton();
                        update();
                        quest.Items.Add(outtest1.setQuestions[i].question);
                        for (int j = 0; j < outtest1.setQuestions[i].answer.Length; j++)
                        {
                            //quest.Items.Add(outtext1.setQuestions[i].answer[j]);
                            otvet1.Text = outtest1.setQuestions[i].answer[0];
                            otvet2.Text = outtest1.setQuestions[i].answer[1];
                            otvet3.Text = outtest1.setQuestions[i].answer[2];
                            otvet4.Text = outtest1.setQuestions[i].answer[3];
                        }

                    }
                    break;

                case 2:
                    ++kol_voprosov;
                    //update();
                    //informsysEntities context = new informsysEntities();

                    //Users users = Loadingtest();
                    //quest.Text = users.username;
                    //ListsTests.Selectedtest++;
                    Test outtext2 = JsonSerializer.Deserialize<Test>(ListsTests.json);

                    for (int i = 1; i < kol_voprosov; i++)
                    {
                        update();
                        quest.Items.Add(outtext2.setQuestions[i].question);
                        for (int j = 0; j < outtext2.setQuestions[i].answer.Length; j++)
                        {
                            quest.Items.Add(outtext2.setQuestions[i].answer[j]);
                        }

                    }
                    break;

                default:
                    MessageBox.Show("do svyazi2");
                    break;

                    
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // kol_voprosov--;
        }
    }
}
