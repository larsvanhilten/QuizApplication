using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ScoreWindow.xaml
    /// </summary>
    public partial class ScoreWindow : Window
    {
        public ScoreWindow(int points, string name)
        {
            InitializeComponent();
            score.Content = points + "%";
            SaveScore(points, name);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }

        private void SaveScore(int score, string name) {
            string filepath = "scores.txt";
            string oldScores = "";
            if (File.Exists(filepath))
            {
                oldScores = System.IO.File.ReadAllText(@"scores.txt");
            }

            
            string lines = oldScores + name + ": " + score;

            // Write the string to a file.
            System.IO.StreamWriter file = new System.IO.StreamWriter("scores.txt");
            file.WriteLine(lines);
            file.Close();
        }
    }
}
