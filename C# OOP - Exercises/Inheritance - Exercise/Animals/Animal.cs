namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private int age;

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
                if (value < 0) 
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }

        public string Gender { get; set; }

        public virtual string ProduceSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"{typeof(Animal).Name}");
            output.AppendLine($"{Name} {Age} {Gender}");
            output.AppendLine($"{ProduceSound}");

            return output.ToString().Trim();
        }
    }
}
