namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        public override int Power => 80;

        public override string CastAbility()
        {
            return $"{nameof(Druid)} - {Name} healed for {Power}";
        }

        public Druid(string name) : base(name)
        {
        }
    }
}