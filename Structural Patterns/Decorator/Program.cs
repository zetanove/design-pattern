using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rect = ShapeFactory.GetInstance().GetShape(Shapes.Rectangle);
            rect.Render();

            GraphicDecorator border=new BorderDecorator(rect, "rosso", 2);
            border.Render();

            GraphicDecorator dec=new FillDecorator(border, "giallo", "nero", "destra");
            dec.Render();
            
            GraphicDecorator all=new BorderDecorator(
                new FillDecorator(
                        new ShadowDecorator(rect, "nero", 0.6), 
                        "giallo", "verde", "destra"),
                 "rosso", 2);

            all.Render();
 
            Console.ReadLine();
        }
    }

    enum Shapes
    {
        Rectangle,
        Triangle
    }
    class ShapeFactory
    {
        private static ShapeFactory instance;
        private ShapeFactory()
        {
        }

        public static ShapeFactory GetInstance()
        {
            if(instance==null)
                instance=new ShapeFactory();
            return instance;
        }

        public Shape GetShape(Shapes type)
        {
            if(type== Shapes.Rectangle)
                return new Rectangle(){ Height = 10, Width = 20};

            return null;
        }
    }

    //Component
    public abstract class Shape
    {
        public abstract void Render();
    }

    //Concrete component
    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override void Render()
        {
            Console.WriteLine($"Disegno un rettangolo di dimensioni {Width}x{Height}");
        }
    }

    //Decorator
    public abstract class GraphicDecorator : Shape
    {
        private Shape component;

        public Shape Component
        {
            get { return component; }
        }

        public GraphicDecorator(Shape shape)
        {
            Console.WriteLine("Aggiunto " + this.GetType().Name + " al componente "+shape.GetType().Name);
            this.component = shape;
        }


        public override void Render()
        {
            component.Render();
        }
    }

    class BorderDecorator : GraphicDecorator
    {
        private string color;
        private int size;

        public BorderDecorator(Shape shape, string color, int size) : base(shape)
        {
           
            this.color = color;
            this.size = size;
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Disegno bordo di " + size + "px " + color);
        }
    }

    class FillDecorator : GraphicDecorator
    {
        private string colorStart;
        private string colorEnd;
        private string direction;

        public FillDecorator(Shape shape, string cs, string ce, string dir): base(shape)
        {
            colorStart = cs;
            colorEnd = ce;
            direction = dir;
        }

        public override void Render()
        {
            
            base.Render();
            Console.WriteLine($"Riempimento con colore da {colorStart} a {colorEnd} direzione {direction}");
        }
    }

    class ShadowDecorator : GraphicDecorator
    {
        private string color;
        private double opacity;

        public ShadowDecorator(Shape shape, string color, double op) : base(shape)
        {

            this.color = color;
            this.opacity = op;
        }

        public override void Render()
        {
            Console.WriteLine("Disegno prima rettangolo per l'ombra di colore " + color + " opacità " + opacity);
            base.Render();
        }
    }
}
