namespace Restaurant
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var caffee = new Coffee("fff", 10);
            Console.WriteLine(caffee.Price);
        }
    }
}