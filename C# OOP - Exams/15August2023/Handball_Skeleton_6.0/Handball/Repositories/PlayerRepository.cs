using Handball.Models.Contracts;

namespace Handball.Repositories
{
    using Handball.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PlayerRepository: IRepository<IPlayer>
    {
        private List<IPlayer> _models;

        public PlayerRepository()
        {
            _models=new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => _models.AsReadOnly();

        public void AddModel(IPlayer model)
        {
           _models.Add(model);
        }

        public bool RemoveModel(string name)
        {
            var player = _models.FirstOrDefault(x => x.Name == name);
            if (player != null)
            {
                _models.Remove(player);
                return true;
            }
            return false;
        }

        public bool ExistsModel(string name)
        {
            var player = _models.FirstOrDefault(x => x.Name == name);
            if (player != null)
            {
                return true;
            }
            return false;
        }

        public IPlayer GetModel(string name)
        {
            return _models.FirstOrDefault(p => p.Name == name);
        }
    }
}
