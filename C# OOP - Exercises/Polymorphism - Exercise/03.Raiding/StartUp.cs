using _03.Raiding.Contracts;
using _03.Raiding.Models;

namespace _03.Raiding;

public class StartUp
{
    public static void Main(string[] args)
    {
        var num = int.Parse(Console.ReadLine());
        var heroes = new List<IBaseHero>();

        for (int i = 0; i < num; i++)
        {
            var name = Console.ReadLine();
            var heroType = Console.ReadLine();
            var hero = HeroFactory.CreateHero(heroType, name);
            if (hero == null)
            {
                Console.WriteLine("Invalid hero!");
            }
            else
            {
                Console.WriteLine(hero.CastAbility());

                heroes.Add(hero);
            }
        }

        var bossPower = int.Parse(Console.ReadLine());
        var raidPower = heroes.Sum(h => h.Power);

        Console.WriteLine(bossPower > raidPower ? "Defeat..." : "Victory!");
    }
}