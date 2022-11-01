using System;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine(new string(' ', this.radius) + new string('*', this.radius * 2 + 1));

            int level = this.radius - 2;

            for (int i = 0; i < this.radius - 1; i++)
            {
                Console.WriteLine(new string(' ', level) + "**" + new string(' ', this.radius * 2 + 1 + i * 2) + "**");

                if (level > 0)
                {
                    level--;
                }
            }

            Console.WriteLine("*" + new string(' ', this.radius * 2 + 1 + (this.radius - 1) * 2) + "*");

            for (int i = this.radius - 1 - 1; i >= 0; i--)
            {
                Console.WriteLine(new string(' ', level) + "**" + new string(' ', this.radius * 2 + 1 + i * 2) + "**");
                level++;
            }

            Console.WriteLine(new string(' ', this.radius) + new string('*', this.radius * 2 + 1));
        }
    }
}