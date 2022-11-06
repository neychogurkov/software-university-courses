namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get { return this.radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid radius!");
                }

                this.radius = value;
            }
        }

        public override double CalculateArea() => Math.PI * Math.Pow(this.Radius, 2);

        public override double CalculatePerimeter() => 2 * Math.PI * this.Radius;

        public override string Draw()
            => base.Draw() + this.GetType().Name;
    }
}
