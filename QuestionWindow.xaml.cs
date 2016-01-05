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

namespace QuizApplication
{
    /// <summary>
    /// Interaction logic for QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        int questionCount = 1;
        int score = 0;
        string name;

        public QuestionWindow(string name)
        {
            InitializeComponent();
            SetQuestion();
            this.name = name;
        }

        private void SetQuestion()
        {
            switch (questionCount)
            {
                case 1:
                    question.Content = "In what year was .Net released?";
                    answerOne.Content = "2001";
                    answerTwo.Content = "2002";
                    answerThree.Content = "2003";
                    break;
                case 2:
                    question.Content = "In what year was Microsoft founded?";
                    answerOne.Content = "1975";
                    answerTwo.Content = "1985";
                    answerThree.Content = "1990";
                    break;
                case 3:
                    question.Content = "What language is not included in .Net \nby default?";
                    answerOne.Content = "C#";
                    answerTwo.Content = "Visual Basic";
                    answerThree.Content = "Python";
                    break;
                case 4:
                    question.Content = "On what platform is .Net not available?";
                    answerOne.Content = "Mac";
                    answerTwo.Content = "Linux";
                    answerThree.Content = "Available at both";
                    break;

            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool correct = CheckAnswer();
            if (correct) {
                score += 25;
            }

            questionCount++;
            SetQuestion();

            if (questionCount == 5) {
                ScoreWindow scoreWindow = new ScoreWindow(score, name);
                scoreWindow.Show();
                this.Close();
            }
        }

        private bool CheckAnswer()
        {
            RadioButton correctButton = new RadioButton();

            switch (questionCount)
            {
                case 1:
                    correctButton = answerTwo;
                    break;
                case 2:
                    correctButton = answerOne;
                    break;
                case 3:
                    correctButton = answerThree;
                    break;
                case 4:
                    correctButton = answerThree;
                    break;

            }

            bool answeredCorrectly = correctButton.IsChecked ?? false;


            return answeredCorrectly;
        }
    }



}
