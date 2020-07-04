using System;
using System.Collections.Generic;
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
                Circle c = new Circle(color, 5);
                _shapes.Add(color + type, c);
                return c;
            }
            else if (shapeType == typeof(Square))
            {
                Square s = new Square(color, 10);
                _shapes.Add(color + type, s);
                return s;
            }
        }
        return null;
    }
}
