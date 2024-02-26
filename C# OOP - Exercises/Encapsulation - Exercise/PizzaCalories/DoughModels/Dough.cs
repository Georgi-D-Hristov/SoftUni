namespace PizzaCalories.DoughModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Dough
{
    private string _flourType;
    private string _bakingTechnique;
    private int _weigh;

    public Dough(string flourType, string bakingTechnique, int weigh)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weigh = weigh;
    }

    public int Weigh
    {
        get { return _weigh; }
        private set { _weigh = value; }
    }


    public string BakingTechnique
    {
        get { return _bakingTechnique; }
        private set { _bakingTechnique = value; }
    }


    public string FlourType
    {
        get { return _flourType; }
        private set
        {
            if (!Enum.TryParse(value, out FlourType flourType))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            _flourType = value;
        }
    }

}
public enum FlourType
{
    White,
    Wholegrain
}
public enum BakingTechnique
{
    Crispy,
    Chewy,
    Homemade
}
