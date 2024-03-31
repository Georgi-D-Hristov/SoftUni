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
            if (diverType is not("FreeDiver" or "ScubaDiver"))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (_divers.GetModel(diverName) is not null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, _divers.GetType().Name);
            }

            if (diverType== "FreeDiver")
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

            if (fishType== "ReefFish")
            {
                _fishes.AddModel(new ReefFish(fishName, points));
            }

            if (fishType== "DeepSeaFish")
            {
                _fishes.AddModel(new DeepSeaFish(fishName, points));
            }

            if (fishType== "PredatoryFish")
            {
                _fishes.AddModel(new PredatoryFish(fishName, points));
            }

            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            throw new NotImplementedException();
        }

        public string HealthRecovery()
        {
            throw new NotImplementedException();
        }

        public string DiverCatchReport(string diverName)
        {
            throw new NotImplementedException();
        }

        public string CompetitionStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
