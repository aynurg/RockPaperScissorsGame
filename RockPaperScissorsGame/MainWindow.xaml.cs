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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RockPaperScissorsGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        readonly GameVM gameVM = new GameVM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = gameVM;
            gameVM.rndNumber();
        }
        
        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            gameVM.Clear();
        }

        public void btnPaper_Click(object sender, RoutedEventArgs e)
        {

            gameVM.playerChoice = "Paper";
            gameVM.gameWinner();
        }

        public void btnRock_Click(object sender, RoutedEventArgs e)
        {
            gameVM.playerChoice = "Rock";
            gameVM.gameWinner();
        }

        public void btnScissors_Click(object sender, RoutedEventArgs e)
        {
            gameVM.playerChoice = "Scissors";
            gameVM.gameWinner();
        }
        
       
    }
}
