namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        public override int Power => 80;

        public override string CastAbility()
        {
            return $"{nameof(Rogue)} - {Name} hit for {Power} damage";
        }

        public Rogue(string name) : base(name)
        {
        }
    }
}