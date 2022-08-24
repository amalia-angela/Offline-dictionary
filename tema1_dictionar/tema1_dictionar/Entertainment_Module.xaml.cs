using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dictionar
{
    /// <summary>
    /// Interaction logic for Entertainment_Module.xaml
    /// </summary>
    public partial class Entertainment_Module : Window
    {
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int percentage;
        int totalQuestions;
        bool next = false;
        string[] cuvinte;
        string[] descriere;
        string[] imagine;
        string[] categorie;
        public Entertainment_Module()
        {
            InitializeComponent();

            read();

            askQuestion(questionNumber);

            totalQuestions = 5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }
        private int choseRandom()
        {
            Random rand = new Random();
            int index = rand.Next(cuvinte.Length);
            return index;

        }

        public int choseRandomOption(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }


        private void checkAnswerEvent(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;

            int buttonTag = Convert.ToInt32(senderObject.Tag);
            if (next == true)
            {
                if (buttonTag == correctAnswer)
                {
                    score++;
                    MessageBox.Show(
                        "Correct"
                        );
                }
                else
                {
                    MessageBox.Show(
                       "Incorect"
                       );
                }

                if (questionNumber == totalQuestions)
                {
                    // calculam procentul

                    percentage = (int)Math.Round((double)(score * 100) / totalQuestions);

                    MessageBox.Show(
                        "Quiz Ended!" + Environment.NewLine +
                        "You have answered " + score + " questions correctly." + Environment.NewLine +
                        "Your total percentage is " + percentage + "%" + Environment.NewLine +
                        "Click OK to play again"
                        );

                    score = 0;
                    questionNumber = 0;
                    askQuestion(questionNumber);

                }

                questionNumber++;
                askQuestion(questionNumber);
            }

        }

        private void askQuestion(int qnum)
        {
            int cuvantindex, op;
            switch (qnum)
            {

                case 1:
                    cuvantindex = choseRandom();
                    op = choseRandomOption(1, 2);
                    if (op == 1)
                    {
                        if (imagine[cuvantindex] == "None")
                        {
                            lblQuestion.Content = descriere[cuvantindex];
                        }
                        else
                        {
                            //pictureBox1.Image = Properties.Resources.imagine[cuvantindex];
                        }
                    }
                    else
                    {
                        lblQuestion.Content = descriere[cuvantindex];
                    }

                    button1.Content = cuvinte[cuvantindex];
                    button2.Content = "B";
                    button3.Content = "C";
                    button4.Content = "D";

                    correctAnswer = 1;

                    break;
                case 2:
                    cuvantindex = choseRandom();
                    op = choseRandomOption(1, 2);
                    if (op == 1)
                    {
                        if (imagine[cuvantindex] == "None")
                        {
                            lblQuestion.Content = descriere[cuvantindex];
                        }
                        else
                        {
                            //pictureBox1.Image = Properties.Resources.imagine[cuvantindex];
                        }
                    }
                    else
                    {
                        lblQuestion.Content = descriere[cuvantindex];
                    }
                    button1.Content = "A";
                    button2.Content = cuvinte[cuvantindex];
                    button3.Content = "C";
                    button4.Content = "D";

                    correctAnswer = 2;

                    break;
                case 3:
                    cuvantindex = choseRandom();
                    op = choseRandomOption(1, 2);
                    if (op == 1)
                    {
                        if (imagine[cuvantindex] == "None")
                        {
                            lblQuestion.Content = descriere[cuvantindex];
                        }
                        else
                        {
                            //pictureBox1.Image = Properties.Resources.imagine[cuvantindex];
                        }
                    }
                    else
                    {
                        lblQuestion.Content = descriere[cuvantindex];
                    }
                    button1.Content = "A";
                    button2.Content = "B";
                    button3.Content = "C";
                    button4.Content = cuvinte[cuvantindex];

                    correctAnswer = 4;

                    break;
                case 4:
                    cuvantindex = choseRandom();
                    op = choseRandomOption(1, 2);
                    if (op == 1)
                    {
                        if (imagine[cuvantindex] == "None")
                        {
                            lblQuestion.Content = descriere[cuvantindex];
                        }
                        else
                        {
                            //pictureBox1.Image = Properties.Resources.imagine[cuvantindex];
                        }
                    }
                    else
                    {
                        lblQuestion.Content = descriere[cuvantindex];
                    }
                    button1.Content = "A";
                    button2.Content = "B";
                    button3.Content = cuvinte[cuvantindex]; ;
                    button4.Content = "D";

                    correctAnswer = 3;

                    break;

                case 5:
                    cuvantindex = choseRandom();
                    op = choseRandomOption(1, 2);
                    if (op == 1)
                    {
                        if (imagine[cuvantindex] == "None")
                        {
                            lblQuestion.Content = descriere[cuvantindex];
                        }
                        else
                        {
                            //pictureBox1.Image = Properties.Resources.imagine[cuvantindex];
                        }
                    }
                    else
                    {
                        lblQuestion.Content = descriere[cuvantindex];
                    }
                    button1.Content = cuvinte[cuvantindex];
                    button2.Content = "B";
                    button3.Content = "C";
                    button4.Content = "D";

                    correctAnswer = 1;

                    break;

            }

        }

        private void read()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Public\cuvinte.txt");
            int indexi = 0, index = 0;
            //cuvant categorie descriere imagine
            while (index < lines.Length)
            {
                cuvinte[indexi] = lines[index];
                categorie[indexi] = lines[index + 1];
                descriere[indexi] = lines[index + 2];
                imagine[indexi] = lines[index + 3];
                index += 4;
                indexi += 1;
            }
        }

        private void okey_Click(object sender, RoutedEventArgs e)
        {
            next = true;
        }
    }
}
