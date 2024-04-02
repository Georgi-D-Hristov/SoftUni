using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FishRepository:IRepository<IFish>
    {
        private List<IFish> _models;
            
        public FishRepository()
        {
            _models=new List<IFish>();
        }

        public IReadOnlyCollection<IFish> Models => _models;

        public void AddModel(IFish model)
        {
            _models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return _models.FirstOrDefault(f => f.Name == name);
        }
    }
}
