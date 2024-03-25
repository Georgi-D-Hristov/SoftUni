using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    public class ClimberRepository : IRepository<IClimber>
    {
        private List<IClimber> _all;

        public ClimberRepository()
        {
            _all = new List<IClimber>();
        }

        public IReadOnlyCollection<IClimber> All => _all.AsReadOnly();

        public void Add(IClimber model)
        {
            _all.Add(model);
        }

        public IClimber Get(string name)
        {
            var climber = _all.FirstOrDefault(c => c.Name == name);
            return climber;
        }
    }
}