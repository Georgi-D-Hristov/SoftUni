using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TeamRepository:IRepository<ITeam>
    {
        private List<ITeam> _models;

        public TeamRepository()
        {
            _models=new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => _models.AsReadOnly();

        public void AddModel(ITeam model)
        {
            _models.Add(model);
        }

        public bool RemoveModel(string name)
        {
            var team = _models.FirstOrDefault(x => x.Name == name);
            if (team != null)
            {
                _models.Remove(team);
                return true;
            }
            return false;
        }

        public bool ExistsModel(string name)
        {
            var team = _models.FirstOrDefault(x => x.Name == name);
            if (team != null)
            {
                return true;
            }
            return false;
        }

        public ITeam GetModel(string name)
        {
            return _models.FirstOrDefault(p => p.Name == name);
        }
    }
}
