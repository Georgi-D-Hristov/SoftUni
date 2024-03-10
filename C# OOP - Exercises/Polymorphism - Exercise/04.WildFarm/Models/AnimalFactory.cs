using _04.WildFarm.Contracts;

namespace _04.WildFarm.Models
{
    using System;

    public class AnimalFactory : IAnimalFactory
    {
        public Animal CreateAnimal(params string[] args)
        {
            switch (args[0])
            {
                case "Owl":
                    return new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));

                case "Hen":
                    return new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));

                case "Mouse":
                    return new Mouse(args[1], double.Parse(args[2]), args[3]);

                case "Dog":
                    return new Dog(args[1], double.Parse(args[2]), args[3]);

                case "Cat":
                    return new Cat(args[1], double.Parse(args[2]), args[3], args[4]);

                case "Tiger":
                    return new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);

                default:
                    throw new ArgumentException("Invalid animal type!");
            }
        }
    }
}