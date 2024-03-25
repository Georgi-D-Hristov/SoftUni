using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Controller : IController
    {
        private IRepository<IPeak> _peaks;
        public Controller()
        {
            _peaks = new PeakRepository();
        }


        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            var peak = new Peak(name, elevation, difficultyLevel);

            if (_peaks.Get(name) == null)
            {
                return $"{name} is already added as a valid mountain destination.";

            }

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return $"{difficultyLevel} peaks are not allowed for international climbers.";
            }

            _peaks.Add(peak);
            return $"{name} is allowed for international climbing. See details in {_peaks.GetType().Name}.";
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {

        }

        public string AttackPeak(string climberName, string peakName)
        {
            throw new NotImplementedException();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            throw new NotImplementedException();
        }

        public string BaseCampReport()
        {
            throw new NotImplementedException();
        }

        public string OverallStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
