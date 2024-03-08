namespace _03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{nameof(Paladin)} - {Name} healed for {Power}";
        }

        public Paladin(string name) : base(name)
        {
        }
    }
}