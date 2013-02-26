using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;


namespace FeedTheSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FeedTheSnakeGame game;
        private int level = 2;
        public MainWindow()
        {
            InitializeComponent();
        }
        public ICommand GameLevel
        {
            get;
            internal set;
        }
        //show help message
        private void CommandHelpBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("The object of the game is to guide the head of the snake and eat  randomly appearing food. The length of the snake increases every time it eats the food. The food shows for a random period of time and disappears after that time ends.", "Help");
        }
        //when the new game is pressed
        private void CommandNewGameBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            game = new FeedTheSnakeGame(gamePlace,result,level);
            game.GameStart();
            
        }
        //when we choiced level
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
                MenuItem m = (MenuItem)sender;
                level = 2;
                level *= int.Parse((string)m.Header);
                 
        }
      
    }
}
