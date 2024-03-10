namespace _04.WildFarm.Models
{
    using _04.WildFarm.Contracts;

    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity
        {
            get;
            init;
        }
    }
}