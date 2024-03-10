namespace _04.WildFarm.Models
{
    using _04.WildFarm.Contracts;

    public abstract class Animal : IAnimal, IProduceSound
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public virtual void Eat(IFood food)
        {
            Weight += food.Quantity * 1;
            FoodEaten++;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name} {Weight}";
        }

        public virtual string Sound()
        {
            return string.Empty;
        }
    }
}