using System;

namespace lab8
{
    interface IForma
    {
        double Square();
        double FullSquare();
        double Volume();
    }
    class Circle : IForma
    {
        private double radius = 0;
        public Circle(double radius)
        {
            CircleRadius = radius;
        }
        public double CircleRadius
        {
            get { return radius; }
            set { if (value > 0) radius = value; }
        }
        public double Square()
        {
            return Math.PI * Math.Pow(CircleRadius, 2);
        }
        public double FullSquare()
        {
            return 0;
        }
        public double Volume()
        {
            return 0;
        }

    }
    class Cone : IForma
    {
        private double height = 0;
        private double radius = 0;
        public Cone(double radius, double height)
        {
            ConeHeight = height;
            ConeRadius = radius;
        }
        public double ConeRadius
        {
            get { return radius; }
            set { if (value > 0) radius = value; }
        }
        public double ConeHeight
        {
            get { return height; }
            set { if (value > 0) height = value; }
        }
        public double Square()
        {
            return Math.PI * Math.Pow(ConeRadius, 2);
        }
        private double SqureOfSide()
        {
            return Math.PI * ConeRadius * (Math.Sqrt(Math.Pow(ConeHeight, 2) + Math.Pow(ConeRadius, 2)));
        }
        public double FullSquare()
        {
            return SqureOfSide() + Square();
        }
        public double Volume()
        {
            return (1 / 3.0) * Square() * ConeHeight;
        }
    }
    class TruncCone : IForma
    {
        private double smallRadius = 0;
        private double radius = 0;
        private double height = 0;
        public TruncCone(double radiusTC, double radiusTC2, double height)
        {
            SmallRadius = radiusTC2;
            TruncRadius = radiusTC;
            TruncHeight = height;
        }
        public double SmallRadius
        {
            get { return smallRadius; }
            set { if (value > 0) smallRadius = value; }
        }
        public double TruncRadius
        {
            get { return radius; }
            set { if (value > 0) radius = value; }
        }
        public double TruncHeight
        {
            get { return height; }
            set { if (value > 0) height = value; }
        }
        public double Square()
        {
            return Math.PI * Math.Pow(TruncRadius, 2);
        }
        private double SquareOfSide()
        {
            return Math.PI * Math.Sqrt(Math.Pow(TruncHeight, 2) + Math.Pow(TruncRadius - SmallRadius, 2)) * (TruncRadius + SmallRadius);
        }
        public double FullSquare()
        {
            return SquareOfSide() + Square() + Math.PI * Math.Pow(SmallRadius, 2);
        }
        public double Volume()
        {
            return (1 / 3.0) * Math.PI * TruncHeight * (Math.Pow(TruncRadius, 2) + TruncRadius * SmallRadius + Math.Pow(SmallRadius, 2));
        }
    }
}