using System;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;

        public Animal()
        {
        }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.age = value;
            }
        }
        public string Gender
        {
            get { return this.gender; }
            set
            {
                if (value != "Male" && value != "Female")
                {
                    throw new ArgumentException();
                }

                this.gender = value;
            }
        }

        public override string ToString()
        {
            return this.GetType().Name + Environment.NewLine + $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine + this.ProduceSound();
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }
    }
}
