namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender) : base(name, age, gender: Gender.Female.ToString())
        {
        }
        public Kitten(string name, int age) : base(name, age) { }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Kitten");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().Trim();
        }
    }
}

