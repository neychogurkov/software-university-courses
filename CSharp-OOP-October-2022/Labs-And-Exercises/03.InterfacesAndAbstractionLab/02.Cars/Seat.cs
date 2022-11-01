using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start() => "Engine start";
        public string Stop() => "Breaaak!";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}")
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}