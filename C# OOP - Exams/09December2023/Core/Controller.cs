using Microsoft.VisualBasic;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public class Controller : IController
    {
        private IRepository<IDiver> _divers;
        private IRepository<IFish> _fishes;
        public Controller()
        {
            _divers = new DiverRepository();
            _fishes = new FishRepository();
        }
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType is not ("FreeDiver" or "ScubaDiver"))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (_divers.GetModel(diverName) is not null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, _divers.GetType().Name);
            }

            if (diverType == "FreeDiver")
            {
                _divers.AddModel(new FreeDiver(diverName));
            }
            else if (diverType == "ScubaDiver")
            {

                _divers.AddModel(new ScubaDiver(diverName));
            }

            return string.Format(OutputMessages.DiverRegistered, diverName, _divers.GetType().Name);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType is not ("ReefFish" or "DeepSeaFish" or "PredatoryFish"))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (_fishes.GetModel(fishName) is not null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, _fishes.GetType().Name);
            }

            if (fishType == "ReefFish")
            {
                _fishes.AddModel(new ReefFish(fishName, points));
            }

            if (fishType == "DeepSeaFish")
            {
                _fishes.AddModel(new DeepSeaFish(fishName, points));
            }

            if (fishType == "PredatoryFish")
            {
                _fishes.AddModel(new PredatoryFish(fishName, points));
            }

            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            var diver = _divers.GetModel(diverName);
            var fish = _fishes.GetModel(fishName);

            

            if (diver is null)
            {
                return string.Format(OutputMessages.DiverNotFound, _divers.GetType().Name, diverName);
            }

            if (fish is null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.OxygenLevel == 0)
            {
                diver.UpdateHealthStatus();
            }

            if (diver.HasHealthIssues == true)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);

            }

            if (diver.OxygenLevel == fish.TimeToCatch && isLucky == true)
            {
                diver.Hit(fish);
                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
            }
            if (diver.OxygenLevel == fish.TimeToCatch && isLucky == false)
            {
                diver.Miss(fish.TimeToCatch);
               
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

            diver.Hit(fish);
            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);

        }

        public string HealthRecovery()
        {
            var diversWithHelthIssues = _divers.Models.Where(d => d.HasHealthIssues == true||d.OxygenLevel==0).ToList();

            foreach (var diver in diversWithHelthIssues)
            {
                if (diver.HasHealthIssues==true)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                }
                else
                {
                    diver.RenewOxy();
                }
                
                
            }

            return string.Format(OutputMessages.DiversRecovered, diversWithHelthIssues.Count);
        }

        public string DiverCatchReport(string diverName)
        {
            var diver = _divers.GetModel(diverName);

            var sb = new StringBuilder();

            sb.AppendLine($"Diver [ Name: {diverName}, Oxygen left: {diver.OxygenLevel}, Fish caught: {diver.Catch.Count}, Points earned: {diver.CompetitionPoints} ]");
            sb.AppendLine("Catch Report:");
            foreach (var fishName in diver.Catch)
            {
                var fish = _fishes.GetModel(fishName);
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            var sb = new StringBuilder();

            sb.AppendLine("**Nautical-Catch-Challenge**");
            var resultDivers = _divers.Models
                .Where(d=>d.HasHealthIssues==false&&d.OxygenLevel>0)
                .OrderByDescending(d => d.CompetitionPoints)
                .ThenByDescending(d => d.Catch.Count)
                .ThenBy(d => d.Name).ToList();

            foreach (var diver in resultDivers)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
