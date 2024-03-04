namespace _07._MilitaryElite.Models
{
    using _07._MilitaryElite.Contracts;
    using System.Collections.Generic;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        

        private readonly 
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
        {
            Privates = new List<Private>();
        }

        public List<IPrivate> Privates;

        List<IPrivate> IPrivates => throw new NotImplementedException();

        public void AddPrivate(Private priv)
        {
            Privates.Add(priv);
        }
    }
}
