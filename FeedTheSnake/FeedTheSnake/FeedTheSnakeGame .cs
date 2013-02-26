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

namespace FeedTheSnake
{
    public class FeedTheSnakeGame
    {
        private Snake snake;
        private Food snakeFood;
        private Canvas placeForPlaing;
        private Random myRandom;
        private Label gameState;
        //timer for food
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private Obstacle[] obstacles;
        private int level;
        //show result of the game 
        private Label result;
        //default constructor
        public FeedTheSnakeGame(Canvas c,Label resultParam,int levelParam) 
        {
            snake = new Snake();
            snakeFood = new Food();
            myRandom = new Random();
            gameState = new Label();
            placeForPlaing = c;
            result = resultParam;
            level = levelParam;
            GameObstacles = new Obstacle[level];
        }
        //property for get or set the snake objekt
        public Snake Snake
        {
            get { return snake; }
            set
            {
                if (value != null)
                {
                    snake = new Snake(value);

                }
            }
        }//end property

        //property for get or set the snakeFood
        public Food SnakeFood 
        {
            get { return snakeFood; }
            set 
            {
                if (value != null)
                {
                    snakeFood = new Food(value);
                }
            }
        }//end property
        
        //property for get or set array of obstacle 
        public Obstacle[] GameObstacles
        {
            get { return obstacles; }
            set 
            {
                if (value != null && value is Obstacle[])
                {
                    obstacles = new Obstacle[value.Length];
                    for (var i = 0; i < level; i++)
                    {
                        //if some of referece is null
                        if (value[i] == null)
                        {
                            obstacles[i] = new Obstacle();
                            obstacles[i].Width = myRandom.Next(20, 80);
                        }
                        else { obstacles[i] = new Obstacle(value[i]); } 
                    }
                }
                else 
                {
                    obstacles = new Obstacle[level];
                    for (var i = 0; i < level;i++ )
                    {
                       obstacles[i] = new Obstacle();
                       obstacles[i].Width = myRandom.Next(20, 80);
                    }
                }
            }
        }//end property

        //property for get or set level of difficulty
        public int Leve 
        {
            get { return level; }
            set 
            {
                if (value > 0) { level = value; }
            }
        }
        //remove all obstacles on the canvas if they are Initialized
        public void RemoveObstacles()
        {
           if(obstacles != null) 
            for (int i = 0; i < level; i++)
            {
                if(obstacles[i] != null)
                placeForPlaing.Children.Remove(obstacles[i].ObstacleRectangle);
                
            }
        }
        //set obstacles in the canvas  
        public void AddObstacles() 
        {
            for (int i = 0; i < level;i++ )
            {
                if (i % 2 == 0)
                {
                    obstacles[i].Y = myRandom.Next(10, (int)placeForPlaing.ActualHeight/2 - 10);
                }
                else 
                {
                    obstacles[i].Y = myRandom.Next((int)placeForPlaing.ActualHeight/2 + 10, (int)placeForPlaing.ActualHeight - 10); 
                }
                if (obstacles[i].Y % 2 == 1)
                {
                    obstacles[i].X = myRandom.Next(10, (int)placeForPlaing.ActualWidth / 2 - obstacles[i].Width);
                }
                else
                {
                    obstacles[i].X = myRandom.Next((int)placeForPlaing.ActualWidth / 2 + 10, (int)placeForPlaing.ActualWidth - obstacles[i].Width);
                }
                //add to canvas 
                Canvas.SetTop(obstacles[i].ObstacleRectangle, obstacles[i].Y);
                Canvas.SetLeft(obstacles[i].ObstacleRectangle, obstacles[i].X);
                placeForPlaing.Children.Add(obstacles[i].ObstacleRectangle);
            }
        }
        //if point is on some obstacle return true
        public bool CheckForObstacles(Point p) 
        {
            foreach (var i in obstacles) 
            {
                if (i.InObstacle(p)) { return true; }
            }
            return false;
        }
        //property for get or set place for plaing
        public Canvas PlaceForPlaing 
        {
            get { return placeForPlaing; }
            //return referance
            set 
            {
                if (value != null && value is Canvas) 
                {
                    placeForPlaing = (Canvas)value;
                }
            }
        }
        public void AddSnakeToCanvas(Point p)
        {
            Canvas.SetTop(snake.Head,p.Y);
            Canvas.SetLeft(snake.Head,p.X);
            //adds head in the canvas with point of canvas  
            placeForPlaing.Children.Add(snake.Head);
            //set the starting size of the snake
            snake.GrowToStart(new Point(p.X,p.Y));
            for (int i = 0; i < 20; i++)
            {
                snake.GrowToEnd(p);
            }
            //adds the snake's body represent with polyline on the canvas 
            placeForPlaing.Children.Add(snake.SnakeBody);
            
        }
        public void AddFoodToCanvas() 
        {
            //while coordinates is in obstacles get new coordinates
           do{
            snakeFood.X = myRandom.Next(0, (int)placeForPlaing.ActualWidth);
            snakeFood.Y = myRandom.Next(0, (int)placeForPlaing.ActualHeight);
           }while(CheckForObstacles(new Point(snakeFood.X,snakeFood.Y)));
            Canvas.SetTop(snakeFood.FoodElipse, snakeFood.Y - snake.Head.Height / 2);
            Canvas.SetLeft(snakeFood.FoodElipse, snakeFood.X - snake.Head.Height / 2);
            snakeFood.FoodColor = Brushes.Red;
            //adds the food to canvas
            placeForPlaing.Children.Add(snakeFood.FoodElipse);
            //set the time that food is on canvas 
            timer.Interval = TimeSpan.FromSeconds(9 - level);
        }
        //adds to canvas level that show game state
        public void AddGameStateToCanvas() 
        {
            int x, y;
            x = (int)placeForPlaing.ActualWidth;
            y = (int)placeForPlaing.ActualHeight;
            //get coordinates of center of canvas  
            gameState.Height = 30;
            gameState.Width = 70;
            Canvas.SetTop(gameState, y / 2 -15 );
            Canvas.SetLeft(gameState, x / 2 - 35 );
            gameState.Background = Brushes.Beige;
            gameState.Content = "Game Start";
            placeForPlaing.Children.Add(gameState);
            //add to canvas
        }
        //move food on canvas at random position 
        public void MoveFood() 
        {
            AddFoodToCanvas();
            //define food's color and number of score 
            if (snakeFood.X % 3 == 0)
            {
                snakeFood.FoodColor = Brushes.Red;
                snakeFood.Score = 4;
            }
            else if (snakeFood.X % 3 == 1)
            {
                snakeFood.FoodColor = Brushes.Yellow;
                snakeFood.Score = 6;
            }
            else 
            {
                snakeFood.FoodColor = Brushes.Blue;
                snakeFood.Score = 10;
            }
        }
        //move the snake on the canvas  
        public void SneakeMove(Point mousePosition) 
        {
            Canvas.SetTop(snake.Head, mousePosition.Y - snake.Head.Height / 2);
            Canvas.SetLeft(snake.Head, mousePosition.X - snake.Head.Height / 2);
            //the posion of mouse became first point of the snake
            snake.GrowToStart(mousePosition);
            //remove last point of the snake 
            snake.SnakeRemoveLast();      
        }
        //release the memory that the game use
        public void GameOver() 
        {
            placeForPlaing.Children.Clear();
            gameState.Visibility = Visibility.Visible;
            gameState.Content = "Game Over";
            placeForPlaing.Children.Add(gameState);
            placeForPlaing.MouseMove -= placeForPlaing_MouseMove;
            timer.Tick -= RemoveFood;
        }
        //start watching for the game start
        public void GameStart()
        {
            placeForPlaing.Children.Clear();
            AddGameStateToCanvas();
            //game start when mouse cross level(gameState)
            gameState.MouseEnter += gameState_MouseEnter;
            result.Content = "0";
        }
        //remove the food from canvas(placeForPlaing) 
        private void RemoveFood( object sender, EventArgs e )
        {
            placeForPlaing.Children.Remove(snakeFood.FoodElipse);
            MoveFood();
        }
        //this event initialize Component of the game 
        private void gameState_MouseEnter(object sender, MouseEventArgs e)
        {
            gameState.Visibility = Visibility.Hidden;
            AddSnakeToCanvas(e.GetPosition(placeForPlaing));
            AddObstacles();
            AddFoodToCanvas();
            placeForPlaing.MouseMove += placeForPlaing_MouseMove;
            timer.Tick += RemoveFood;
            gameState.MouseEnter -= gameState_MouseEnter;
            timer.IsEnabled = true;
        }
        //is the point "c" is close to poits "a" and "b"
        private bool Cross(Point a, Point b, Point c) 
        {
            return Math.Abs(c.X - a.X) + Math.Abs(c.Y - a.Y) < 5;
        }

        //check that the snake cross it selff
        private bool SnakeCrossesItsTail (Point p)
        {
            for(int i=20; i<snake.Length-1;i++)
            {
                if (Cross(snake.SnakeBody.Points[i], snake.SnakeBody.Points[i+1],p)) { return true; }
            }
            return false;
        }
        //this event represent the kernel of the game 
        private void placeForPlaing_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(placeForPlaing);
            //checks for the end of the game 
            if (CheckForObstacles(mousePosition) || SnakeCrossesItsTail(mousePosition) || (mousePosition.X > placeForPlaing.ActualWidth || mousePosition.X < 0) || (mousePosition.Y > placeForPlaing.ActualHeight || mousePosition.Y < 0))
            {
                GameOver();
                //end of the game 
            }
            else 
            {
                //this checks "is the food eaten of snake"
                if (Math.Abs(snakeFood.X - mousePosition.X) < snakeFood.Diameter && Math.Abs(mousePosition.Y - snakeFood.Y) < snakeFood.Diameter)
                {
                    placeForPlaing.Children.Remove(snakeFood.FoodElipse);
                    //add to snake points that the food score is
                    for (int i = 0; i < snakeFood.Score; i++)
                    {
                        snake.GrowToStart(mousePosition);
                    }
                    result.Content = (int.Parse((string)result.Content) + snakeFood.Score).ToString();
                    MoveFood();
                }
                SneakeMove(mousePosition); 
            }
        }
    }
}
