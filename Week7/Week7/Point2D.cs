using System;
namespace Week7
{
    public class Point2D
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
        public static Point2D operator +(Point2D a,Point2D )
    }
}
