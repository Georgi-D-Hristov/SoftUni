namespace Animals
{
    using System;
    using System.Text;

    public class Animal
    {
        private string name;
        private int age;

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public Animal(string name, int age, string gender):this(name, age) 
        {

            if (gender == "Male")
            {
                Gender = Gender.Male;
            }
            else if (gender == "Female")
            {
                Gender = Gender.Female;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Invalid input!");
                }
                name = value;
            }
        }
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
                    Console.WriteLine("Invalid input!");
                }
                age = value;
            }
        }
        public Gender Gender { get; set; }

        public virtual string ProduceSound()
        {
            return "--";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().Trim();
        }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
