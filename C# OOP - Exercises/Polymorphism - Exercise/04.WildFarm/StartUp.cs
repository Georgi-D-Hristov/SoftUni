namespace _04.WildFarm
{
    using _04.WildFarm.Models;

    public class StartUp
    {
        private static void Main(string[] args)
        {
            var animals = new List<Animal>();
            var animalFactory = new AnimalFactory();
            var foodFactory = new FoodFactory();
            string commandLine;
            while ((commandLine = Console.ReadLine()) != "End")
            {
                try
                {
                    var animalArgs = commandLine
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    var animalType = commandLine[0];
                    var animal = animalFactory.CreateAnimal(animalArgs);
                    animals.Add(animal);
                    Console.WriteLine(animal.Sound());

                    var foodsArgs = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var food = foodFactory.CreateFood(foodsArgs[0], int.Parse(foodsArgs[1]));

                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException io)
                {
                    Console.WriteLine(io.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}