﻿using System;
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
    
    public partial class ListsTests : Form
    {
        public string json;
        public int Selectedtest;
        Main_user main_User;
        public ListsTests(Main_user main_User)
        {
            InitializeComponent();
            this.main_User = main_User;
        }

        private void bunifuFlatButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            main_User.Show();
        }

        private void bunifuFlatButton13_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            FinalTests finalTests = new FinalTests(this);
            Test test = new Test();

            SetQuestion setQuestion = new SetQuestion { question = "Что такое миграция", answer = new string[] { "первое", "второе", "третье" } };
            test.setQuestions.Add(setQuestion);

            setQuestion = new SetQuestion();
            setQuestion.question = "aaaaa";
            setQuestion.answer = new string[] { "bbbb", "ccc", "hhh" };

            test.setQuestions.Add(setQuestion);

            setQuestion = new SetQuestion();
            setQuestion.question = "llllllll";
            setQuestion.answer = new string[] { "kkkkkkkk", "jjjjjj", "ooooooo" };

            test.setQuestions.Add(setQuestion);

            json = JsonSerializer.Serialize<Test>(test);
            MessageBox.Show(json);

         
            //test.setQuestions.Add(setQuestion);
            //json = JsonSerializer.Serialize<Test>(test);
            this.Hide();
            finalTests.Show();

        }
    }

    class SetQuestion
    {
        public string question { get; set; }
        public string[] answer { get; set; }
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
