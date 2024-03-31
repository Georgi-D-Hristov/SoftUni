using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DiverRepository : IRepository<IDiver>
    {
        private HashSet<IDiver> _models;

        public DiverRepository()
        {
            _models = new HashSet<IDiver>();
        }

        public IReadOnlyCollection<IDiver> Models => _models;

        public void AddModel(IDiver model)
        {
            _models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return _models.FirstOrDefault(d => d.Name == name);
        }
    }
}
