using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flyweight
{
    public partial class Form1 : Form
    {
        public List<IShape> Shapes = new List<IShape>();
        ShapeFactory factory;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            factory = new ShapeFactory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in Shapes)
            {
                if (shape is Circle circle)
                {
                    circle.Move(rnd.Next(0, this.panel1.Width), rnd.Next(0, this.panel1.Height));
                    e.Graphics.FillEllipse(new SolidBrush(Color.FromName(circle.Color)),
                        circle.Position.X, 
                        circle.Position.Y, 
                        circle.Radius*2,  
                        circle.Radius*2);
                }
                else if(shape is Square square)
                {
                    square.Move(rnd.Next(0, this.panel1.Width), rnd.Next(0, this.panel1.Height));
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromName(square.Color)),
                        square.Position.X,
                        square.Position.Y,
                        square.Width,
                        square.Width);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> colors = new List<string>() { "Red", "Blue", "Yellow" };
            for (int i = 0; i < 100; i++)
            {
                if (rnd.Next(1,19)>5)
                {
                    Circle c = (Circle)factory.GetShape(typeof(Circle), colors.OrderBy(g => Guid.NewGuid()).First());
                    c.Radius = 10;
                    Shapes.Add(c);
                }
                else
                {
                    Square c = (Square)factory.GetShape(typeof(Square), colors.OrderBy(g => Guid.NewGuid()).First());
                    c.Width = 10;
                    Shapes.Add(c);
                }
                
            }

            labTotIstanze.Text = $"Figure totali: {Shapes.Count} - Istanze : {factory.Count}";

            panel1.Invalidate();
        }
    }
}

//Flyweight Factory
public class ShapeFactory
{
    Dictionary<string, IShape> _shapes = new Dictionary<string, IShape>();

    public int Count
    {
        get
        {
            return _shapes.Count;
        }
    }

    public IShape GetShape(Type shapeType, string color)
    {
        string type = shapeType.Name;
        if (_shapes.ContainsKey(color + type))
        {
            return _shapes[color + type];
        }
        else
        {
            if (shapeType == typeof(Circle))
            {
                Circle c = new Circle(color);
                _shapes.Add(color + type, c);
                return c;
            }
            else if (shapeType == typeof(Square))
            {
                Square s = new Square(color);
                _shapes.Add(color + type, s);
                return s;
            }
        }

        return null;

    }
}

    //Flyweight interface
    public interface IShape
    {
        void Move(int x, int y);
    }

//concrete fly weight
public class Circle : IShape
{
    //stato intrinseco
    private string color;

    public string Color
    {
        get
        {
            return color;
        }
    }

    public int Radius;
    public Point Position;

    public Circle(string c)
    {
        this.color = c;
    }

    public void Move(int x, int y)
    {
        this.Position = new Point(x, y);
    }
}

public class Square : IShape
{

    //stato intrinseco
    private string color;

    public string Color
    {
        get
        {
            return color;
        }
    }

    public int Width;
    public Point Position;

    public Square(string c)
    {
        this.color = c;
    }

    public void Move(int x, int y)
    {
        this.Position = new Point(x, y);
    }
}