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
            //var hero = HeroFactory.CreateHero(heroType, name);
            //if (hero == null)
            //{
            //    Console.WriteLine("Invalid hero!");
            //}
            //else
            //{
            //    Console.WriteLine(hero.CastAbility());

            //    heroes.Add(hero);
            //}

            if (heroType=="Druid")
            {
                var druid = new Druid(name);
                heroes.Add(druid);

            }

            else if (heroType=="Paladin")
            {
                var paladin = new Paladin(name);
                heroes.Add(paladin);
            }

            else if (heroType=="Rogue")
            {
                var rogue = new Rogue(name);
                heroes.Add(rogue);
            }

            else if (heroType=="Warrior")
            {
                var warrior = new Warrior(name);
                heroes.Add(warrior);
            }
            else
            {
                Console.WriteLine("Invalid hero!");
                i--;
            }
        }

        foreach (var hero in heroes)
        {
            Console.WriteLine(hero.CastAbility());
        }

        var bossPower = int.Parse(Console.ReadLine());
        var raidPower = heroes.Sum(h => h.Power);

        Console.WriteLine(bossPower > raidPower ? "Defeat..." : "Victory!");
    }
}