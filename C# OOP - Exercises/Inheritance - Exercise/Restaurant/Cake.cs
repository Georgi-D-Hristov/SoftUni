namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name)
            : base(name, price:5, grams:250, calories:1000)
        {
        }
    }
}
