using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var sportCar = new SportCar(250,600);

            sportCar.Drive(10);
            Console.WriteLine(sportCar.Fuel);
        }
    }
}
