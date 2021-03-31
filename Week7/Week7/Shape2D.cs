using System;
namespace Week7
{
    public abstract class Shape2D
    {
        public Point2D Centre { get; private set; }

        public Shape2D(Point2D c)
        {
            Centre = c;
        }
        public void Translate (double x, double y)
        {
            Centre += new Point2D(x, y);
        }
        public abstract Point2D[] GerVertices();

        public abstract bool ContainsPoint(Point2D p);
        public abstract double Area { get; }
        public abstract double Perimeter { get; }
    }
}
