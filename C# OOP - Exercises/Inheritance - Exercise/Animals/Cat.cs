﻿namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cat : Animal
    {
        public Cat(string name, int age, string gender) : base(name, age, gender)
        {
        }
        public Cat(string name, int age) : base(name, age) { }

        public override string ProduceSound()
        {
            return "Meow meow";
        }

        public override string ToString()
        {
            Console.WriteLine("Cat");
            return base.ToString();
        }
    }
}
