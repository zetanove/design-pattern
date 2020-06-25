using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Rectangle
    {
        public double Height { get; set; }
        public double  Width { get; set; }

        public double Area() => Height * Width;


        //spostare in RectangleView
        //public void Draw()
        //{
        //    //usa librerie di disegno 
        //}
    }

    class RectangleView
    {
        public void Draw(Rectangle rect)
        {
            //usa librerie di disegno 
        }
    }
}
