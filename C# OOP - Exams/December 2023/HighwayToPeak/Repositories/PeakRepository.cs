namespace HighwayToPeak.Repositories
{
    using HighwayToPeak.Models.Contracts;
    using HighwayToPeak.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PeakRepository : IRepository<IPeak>
    {
        private List<IPeak> _all;

        public PeakRepository()
        {
            _all = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => _all.AsReadOnly();

        public void Add(IPeak model)
        {
            _all.Add(model);
        }

        public IPeak Get(string name)
        {
            var peak = _all.FirstOrDefault(p => p.Name == name);
            return peak;
        }
    }
}