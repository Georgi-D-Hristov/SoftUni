using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    using System.Collections.Generic;

    public class BaseCamp : IBaseCamp
    {
        private List<string> _residents;

        public BaseCamp()
        {
            _residents = new List<string>();
        }

        public IReadOnlyCollection<string> Residents => _residents.AsReadOnly();

        public void ArriveAtCamp(string climberName)
        {
            _residents.Add(climberName);
            _residents = _residents.OrderBy(c => c).ToList();
        }

        public void LeaveCamp(string climberName)
        {
            _residents.Remove(climberName);
        }
    }
}