using System.Drawing;

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

    public int Width { get; private set; }
    public Point Position { get; private set; }

    public Square(string c, int w)
    {
        this.color = c;
        this.Width = w;
    }

    public void Move(int x, int y)
    {
        this.Position = new Point(x, y);
    }
}