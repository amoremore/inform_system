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
            Selectedtest = 1;
            FinalTests finalTests = new FinalTests(this);

            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            Test test = new Test();

            informsysEntities context = new informsysEntities();
            AllForTests allForTests = new AllForTests();


            SetQuestion setQuestion = new SetQuestion { question = "Что такое миграция", answer = new string[] { "Отъезд из страны", "Приезд в страну", "Любые переезды граждан", "Переезды внутри страны" } };
            test.setQuestions.Add(setQuestion);

            setQuestion = new SetQuestion();
            setQuestion.question = "Как называется отъезд за рубеж?";
            setQuestion.answer = new string[] { "Иммиграция", "Эмиграция", "Миграция", "Переселение" };

            test.setQuestions.Add(setQuestion);

            setQuestion = new SetQuestion();
            setQuestion.question = "Как называются миграции на постоянное место жительства?";
            setQuestion.answer = new string[] { "Переезд", "Безвозвратные", "Получение гражданства", "Получение вида на жительство" };

            test.setQuestions.Add(setQuestion);

            setQuestion = new SetQuestion();
            setQuestion.question = "Какая часть мигрантов учитывается при расчете миграционного прироста?";
            setQuestion.answer = new string[] { "Все количество", "Трудовые мигранты", "Прибывшие или выбывшие на постоянное место жительство", "Туристы" };

            test.setQuestions.Add(setQuestion);

            setQuestion = new SetQuestion();
            setQuestion.question = "Какие показатели учитываются при расчете прироста населения?";
            setQuestion.answer = new string[] { "Естественный прирост", "Рождаемость", "Количество иммигрантов", "Сумма естественного и миграционного прироста" };

            test.setQuestions.Add(setQuestion);

            //json = JsonSerializer.Serialize<Test>(test,jso);

            //allForTests.questAndAnswerOptions = json;
           // allForTests.testTime = 5;
            context.AllForTests.Add(allForTests);
            context.SaveChanges();



            //test.setQuestions.Add(setQuestion);
            //json = JsonSerializer.Serialize<Test>(test);
            this.Hide();
            finalTests.Show();

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            Selectedtest = 2;
            FinalTests finalTests = new FinalTests(this);
            Test test = new Test();

            SetQuestion setQuestion = new SetQuestion { question = "Что такое мигранты", answer = new string[] { "первое1", "второе2", "третье3" } };
            test.setQuestions.Add(setQuestion);

            setQuestion = new SetQuestion();
            setQuestion.question = "вопрос";
            setQuestion.answer = new string[] { "1", "2", "3" };

            test.setQuestions.Add(setQuestion);

            setQuestion = new SetQuestion();
            setQuestion.question = "вопрос2";
            setQuestion.answer = new string[] { "4", "5", "6" };

            test.setQuestions.Add(setQuestion);

            //json = JsonSerializer.Serialize<Test>(test);



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
