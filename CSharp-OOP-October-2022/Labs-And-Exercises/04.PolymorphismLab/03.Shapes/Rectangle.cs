namespace Shapes
{
    using System;

    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid height!");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get { return this.width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid width!");
                }

                this.width = value;
            }
        }

        public override double CalculateArea() => this.Height * this.Width;

        public override double CalculatePerimeter() => 2 * (this.Height + this.Width);

        public override string Draw()
            => base.Draw() + this.GetType().Name;
    }
}
