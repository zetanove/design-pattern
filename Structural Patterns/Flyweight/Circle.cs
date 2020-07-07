using System.Drawing;
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

    private int radius;
    public int Radius
    {
        get
        {
            return radius;
        }
    }

    private Point position;
    public Point Position
    { 
        get
        {
            return position;
        }
    }

    public Circle(string c, int r)
    {
        this.color = c;
        this.radius = r;
    }

    public void Move(int x, int y)
    {
        this.position = new Point(x, y);
    }
}
