using _03.Raiding.Contracts;

namespace _03.Raiding.Models
{
    public class HeroFactory
    {
        public static IBaseHero CreateHero(string type, string name)
        {
            IBaseHero hero = null;
            if (type.Equals("Druid"))
            {
                hero = new Druid(name);
            }
            else if (type.Equals("Paladin"))
            {
                hero = new Paladin(name);
            }
            else if (type.Equals("Rogue"))
            {
                hero = new Rogue(name);
            }
            else if (type.Equals("Warrior"))
            {
                hero = new Warrior(name);
            }
            return hero;
        }
    }
}