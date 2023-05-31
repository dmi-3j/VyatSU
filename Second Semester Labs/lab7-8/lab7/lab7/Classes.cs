using System;

namespace lab7
{
    abstract class Forma
    {
        public abstract double Square();
        public abstract double FullSquare();
        public abstract double Volume();
    }
    class Circle : Forma
    {
        private double radius = 0;
        public Circle(double radius)
        {
            CircleRadius = radius;
        }
        public double CircleRadius 
        {
            get { return radius; }
            set { if(value > 0) radius = value; }
        }
        public override double Square()
        {
            return Math.PI * Math.Pow(CircleRadius, 2);
        }
        public override double FullSquare()
        {
            return 0;
        }
        public override double Volume()
        {
            return 0;
        }

    }
    class Cone : Circle
    {
        private double height = 0;
        public Cone(double radius, double height) : base(radius)
        {
            ConeHeight = height; 
        }
        public double ConeHeight
        {
            get { return height; }
            set { if (value > 0) height = value; }
        }
        private double SqureOfSide()
        {
            return Math.PI * CircleRadius * (Math.Sqrt(Math.Pow(ConeHeight, 2) + Math.Pow(CircleRadius, 2)));
        }
        public  override double FullSquare()
        {
            return SqureOfSide() + Square();
        }
        public  override double Volume()
        {
            return (1 / 3.0) * Square() * ConeHeight;
        }
    }
    class TruncCone : Cone
    {
        private double smallRadius = 0;
        public TruncCone(double radiusTC, double radiusTC2, double height) : base(radiusTC, height)
        {
            SmallRadius = radiusTC2;
        }
        public double SmallRadius
        {
            get { return smallRadius; }
            set { if (value > 0) smallRadius = value; }
        }
        private double SquareOfSide()
        {
            return Math.PI * Math.Sqrt(Math.Pow(ConeHeight, 2) + Math.Pow(CircleRadius - SmallRadius, 2)) * (CircleRadius + SmallRadius);
        }
        public override double FullSquare()
        {
            return SquareOfSide() + Square() + Math.PI * Math.Pow(SmallRadius, 2);
        }
        public override double Volume()
        {
            return (1 / 3.0) * Math.PI * ConeHeight * (Math.Pow(CircleRadius, 2) + CircleRadius * SmallRadius + Math.Pow(SmallRadius, 2));
        }
    }
}