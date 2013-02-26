using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;

namespace FeedTheSnake
{
   public class Snake
    {
       //head of the snake on the canvas
       private Ellipse head;
       //body of the snake on the canvas
       private Polyline snakeBody;
      // general purpose constructor
       public Snake(Ellipse headElipse,Polyline p,Brush color,int width) 
       {
           Head = headElipse;
           SnakeBody = p;
           SnakeColor = color;
           SnakeWidth = width;
       }
       //default constructor
       public Snake() : this(new Ellipse(), new Polyline(),Brushes.Pink, 6) { }
       //copy constructor
       public Snake(Snake cpy):this(cpy.Head,cpy.SnakeBody,cpy.SnakeColor,cpy.SnakeWidth) { }
       //property for get or set body of the snake
       public Polyline SnakeBody 
       {
           get { return snakeBody;}
           set
           {
               if (value != null && value is Polyline)
               {
                   snakeBody = new Polyline();
                   snakeBody.Points = ((Polyline)value).Points;
               }
               else { snakeBody = new Polyline(); }
           }
       }//end property

       //property for get or set head of the snake
       public Ellipse Head
       {
           get{return head;}
           set 
           {
               if (value != null && value is Ellipse)
               {
                   head = new Ellipse();
                   Ellipse tmpElipse = (Ellipse)value;
                   head.Width = tmpElipse.Width;
                   head.Height = tmpElipse.Height;
                   head.Fill = tmpElipse.Fill;
               }
               else { head = new Ellipse(); }
           }
       }//end property

       //this property set color of the snake
       public Brush SnakeColor
       {
           get { return head.Fill; }
           set
           {
               if (value != null && value is Brush)
               {
                   head.Fill = (Brush)value;
                   snakeBody.Stroke = (Brush)value;
               }
           }
       }//end property

       //property only for get length of the snake
       public int Length
       {
           get { return snakeBody.Points.Count;}
       }//end property

       //property for get or set a value that represent the snake's width
       public int SnakeWidth 
       {
           get { return (int)snakeBody.StrokeThickness; }
           set 
           {
               if (value > 0) 
               {
                   snakeBody.StrokeThickness = value;
                   head.Width = value +3;
                   head.Height = value + 3;
               }
           }
       }//end property

       //this method is calling every time when snake moving
       public void GrowToStart(Point p) { snakeBody.Points.Insert(0, (Point)p); }
       //this method adds point at the end of the snake
       public void GrowToEnd(Point p) { snakeBody.Points.Add(p); }
       //remove last point of the snake
       public void SnakeRemoveLast() 
       {
           if (snakeBody.Points.Count > 0) 
           {
               snakeBody.Points.RemoveAt(snakeBody.Points.Count - 1);
           }
       }
    }
}
