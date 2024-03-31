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
        private IRepository<IClimber> _climbers;
        private IBaseCamp _baseCamp;
        public Controller()
        {
            _peaks = new PeakRepository();
            _climbers = new ClimberRepository();
            _baseCamp = new BaseCamp();
        }


        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            var peak = new Peak(name, elevation, difficultyLevel);

            if (_peaks.Get(name) != null)
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
            if (_climbers.Get(name) != null)
            {
                return $"{name} is a participant in {_climbers.GetType().Name} and cannot be duplicated.";
            }

            if (isOxygenUsed)
            {
                IClimber climber = new OxygenClimber(name);
                _climbers.Add(climber);
                _baseCamp.ArriveAtCamp(name);
            }
            else
            {
                IClimber climber = new NaturalClimber(name);
                _climbers.Add(climber);
                _baseCamp.ArriveAtCamp(name);
            }

            return $"{name} has arrived at the BaseCamp and will wait for the best conditions.";
        }

        public string AttackPeak(string climberName, string peakName)
        {
            if (_climbers.Get(climberName) == null)
            {
                return $"Climber - {climberName}, has not arrived at the BaseCamp yet.";
            }

            if (_peaks.Get(peakName) == null)
            {
                return $"{peakName} is not allowed for international climbing.";
            }

            if (!_baseCamp.Residents.Contains(climberName))
            {
                return
                    $"{climberName} not found for gearing and instructions. The attack of {peakName} will be postponed.";
            }

            if (_peaks.Get(peakName).DifficultyLevel == "Extreme" && _climbers.Get(climberName).GetType().Name == "NaturalClimber")
            {
                return $"{climberName} does not cover the requirements for climbing {peakName}.";
            }

            _baseCamp.LeaveCamp(climberName);
            var peak = _peaks.Get(peakName);
            var climber = _climbers.Get(climberName);
            climber.Climb(peak);

            if (climber.Stamina == 0)
            {
                return $"{climberName} did not return to BaseCamp.";
            }
            else
            {
                _baseCamp.ArriveAtCamp(climberName);
                return $"{climberName} successfully conquered {peakName} and returned to BaseCamp.";
            }
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            var climber = _climbers.Get(climberName);

            if (!_baseCamp.Residents.Contains(climberName))
            {
                return $"{climberName} not found at the BaseCamp.";
            }

            if (climber.Stamina == 10)
            {
                return $"{climberName} has no need of recovery.";
            }

            climber.Rest(daysToRecover);
            return $"{climberName} has been recovering for {daysToRecover} days and is ready to attack the mountain.";

        }

        public string BaseCampReport()
        {
            if (_baseCamp.Residents.Count==0)
            {
                return "BaseCamp is currently empty.";
            }

            var sb = new StringBuilder();

            sb.AppendLine("BaseCamp residents:");

            foreach (var climberName in _baseCamp.Residents)
            {
                var climber = _climbers.Get(climberName);

                sb.AppendLine($"Name: { climber.Name}, Stamina: { climber.Stamina}, Count of Conquered Peaks: { climber.ConqueredPeaks.Count}");
            }

            return sb.ToString().Trim();
        }

        public string OverallStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");

            foreach (var climber in _climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count).ThenBy(c=>c.Name))
            {
                sb.AppendLine(climber.ToString());
                foreach (var climberConqueredPeak in climber.ConqueredPeaks)
                {
                    sb.AppendLine(_peaks.Get(climberConqueredPeak).ToString());
                }

            }

            return sb.ToString().Trim();
        }
    }
}
