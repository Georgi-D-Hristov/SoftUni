namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender) : base(name, age, gender:Gender.Male.ToString())
        {
        }
        public Tomcat(string name, int age):base(name, age)
        {
            
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Tomcat");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());

            return sb.ToString().Trim();
        }
    }
}
