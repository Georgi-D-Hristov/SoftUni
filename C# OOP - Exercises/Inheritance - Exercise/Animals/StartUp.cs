namespace Animals
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (input != "Beast!")
            {
                var animalType = input;
                var animalInfo = Console.ReadLine().Split().ToArray();
                var name = animalInfo[0];
                var age = int.Parse(animalInfo[1]);
                var gender = animalInfo[2];

                try
                {
                    var animal = new Animal(name, age, gender);
                    Console.WriteLine(animal);
                }
                catch (ArgumentException mesage)
                {

                    Console.WriteLine(mesage);
                }

                input = Console.ReadLine();
            }
        }
    }
}
