using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FeedTheSnake
{
   public class Food
    {
        //how much points  the food give to the snake
        private int score;
        //what we show on the canvas
       private Ellipse foodElipse;
       //general purpose constructor
       public Food(int scoreValue,Brush brushValue,Ellipse elipseValue,int diameterValue) 
       {
           FoodElipse = elipseValue;
           Score = scoreValue;
           FoodColor = brushValue;
           Diameter = diameterValue;
       }
       //default constructor
       public Food() : this(10, Brushes.Black, new Ellipse(), 8) { }
       //copy constructor
       public Food(Food cpyValue) : this(cpyValue.Score, cpyValue.FoodColor,new Ellipse(),cpyValue.Diameter) 
       {
       }
       //Property for foodElipce 
       public Ellipse FoodElipse
       {
           get
           {
               return foodElipse;
           }
           set 
           {
               if (value != null && value is Ellipse)
               {
                   foodElipse = new Ellipse();
                   Ellipse tmpElipse = (Ellipse)value;
                   foodElipse.Width = tmpElipse.Width;
                   foodElipse.Height = tmpElipse.Height;
                   foodElipse.Fill = tmpElipse.Fill;
               }
               else { foodElipse = new Ellipse(); }
           }
       }//end property

       //Property wich value is diameter of the food
       public int Diameter
       {
           get{return (int)foodElipse.Height;}
           set
           {
               if(value > 0)
               {
                   foodElipse.Height = value;
                   foodElipse.Width = value;
               }
           }
       }//end property

       //propety for score
       public int Score
       {
           get { return score; }
           set 
           {
               if (value > 0) 
               {
                   score = value;
               }
           }
       }//end property

       //property wich value is color of the food
       public Brush FoodColor
       {
           get 
           {
               return foodElipse.Fill;
           }
           set 
           {
               if (value != null && value is Brush) 
               {
                   foodElipse.Fill = (Brush)value;
               }
           }
       }
       //food's coordinates on cnavas 
       public int X { get; set; }
       public int Y { get; set; }
    }
}
