namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{nameof(Warrior)} - {Name} hit for {Power} damage";
        }

        public Warrior(string name) : base(name)
        {
        }
    }
}