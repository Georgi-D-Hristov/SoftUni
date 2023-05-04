namespace Animals
{
    using System.Text;

    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine($"{nameof(Cat)}");
            output.AppendLine($"{Name} {Age} {Gender}");
            output.AppendLine($"{this.ProduceSound()}");

            return output.ToString().Trim();
        }
    }
}
