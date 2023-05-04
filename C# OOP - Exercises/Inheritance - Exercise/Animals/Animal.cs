namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private int age;
        private string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name { get; set; }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender 
        {
            get
            {
                return gender;
            }
            set
            {
                if (value!="Male"&&value!="Female")
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"{nameof(Animal)}");
            output.AppendLine($"{Name} {Age} {Gender}");
            output.AppendLine($"{this.ProduceSound()}");

            return output.ToString().Trim();
        }
    }
}
