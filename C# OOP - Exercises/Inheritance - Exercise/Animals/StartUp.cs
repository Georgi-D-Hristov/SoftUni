namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();
            var input = Console.ReadLine();

            while (input != "Beast!")
            {
                var animalType = input;
                var animalInfo = Console.ReadLine().Split().ToArray();
                var name = animalInfo[0];
                var age = int.Parse(animalInfo[1]);
                if (animalInfo.Length == 3)
                {
                    var gender = animalInfo[2];
                    if (animalType=="Cat")
                    {
                        var cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    if (animalType == "Dog")
                    {
                        var dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    if(animalType == "Frog")
                    {
                        var frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    if (animalType == "Kitten")
                    {
                        var kitten = new Kitten(name, age);     
                        animals.Add(kitten);
                    }
                    if (animalType == "Tomcat")
                    {
                        var tom = new Tomcat(name, age);
                        animals.Add(tom);
                    }
                }
                if (animalType == "Kitten")
                {
                    var kitten = new Kitten(name, age);
                    animals.Add(kitten);
                }
                if (animalType == "Tomcat")
                {
                    var tom = new Tomcat(name, age);
                    animals.Add(tom);
                }

                input = Console.ReadLine();
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
