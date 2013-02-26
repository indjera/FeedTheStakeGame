using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;

namespace FeedTheSnake
{
   public class Obstacle
    {
       //this rectangle is our obstacle
       private Rectangle obstacleRectangle;
       //general purpose constructor
       public Obstacle (Rectangle r,int height,int widht,Brush b,int x,int y) 
       {
           ObstacleRectangle = r;
           Width = widht;
           Height = height;
           Color = b;
           X = x;
           Y = Y;
       }
       //default and copy constructor
       public Obstacle():this(new Rectangle(),8,80,Brushes.Brown,0,0) { }
       public Obstacle(Obstacle cpy) : this(cpy.ObstacleRectangle,cpy.Height,cpy.Width,cpy.Color,cpy.X,cpy.Y) { }
       //if point is in rectangle return true else return false
       public bool InObstacle(Point p) 
       {
           if( p.X > X && p.X-X< obstacleRectangle.ActualWidth && Y < p.Y &&p.Y-Y < obstacleRectangle.ActualHeight)
           {
               return true;
           }
           else return false;
       }//end InObstacles

       //property that set color of rectangle
       public Brush Color 
       {
           get { return obstacleRectangle.Fill; }
           set 
           {
               if (value != null && value is Brush) 
               {
                   obstacleRectangle.Fill = (Brush)value;
               }
           }
       }//end property

       //set height of rectangle 
       public int Height
       {
           get { return (int)obstacleRectangle.Height;}
           set 
           {
               if (value > 0) 
               {
                   obstacleRectangle.Height = value;
               }
           }
       }//end property Height

       //set width of rectangle
       public int Width 
       {
           get { return (int)obstacleRectangle.Width; }
           set 
           {
               if (value > 0) 
               {
                   obstacleRectangle.Width = value;
               }
           }
       }//end property Width

       //property that get and set rectange of obstacle 
       public Rectangle ObstacleRectangle 
       {
           get { return obstacleRectangle; }
           set 
           {
               if (value != null && value is Rectangle)
               {
                   Rectangle tmpRectangle = (Rectangle)value;
                   obstacleRectangle = new Rectangle();
                   obstacleRectangle.Width = tmpRectangle.Width;
                   obstacleRectangle.Height = tmpRectangle.Height;
                   obstacleRectangle.Fill = tmpRectangle.Fill;
               }
               else { obstacleRectangle = new Rectangle(); }
           }
       }//end property

       //obstacle's coordinates on cnavas
       public int X { get; set; }
       public int Y { get; set; }

    }
}
