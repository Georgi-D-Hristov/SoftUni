namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        public OxygenClimber(string name)
            : base(name, stamina: 10)
        {
        }

        public override void Rest(int daysCount)
        {
            Stamina += daysCount;

        }
    }
}