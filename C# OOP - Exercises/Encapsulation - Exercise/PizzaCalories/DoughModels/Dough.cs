namespace PizzaCalories.DoughModels;

using System;

public class Dough
{
    private const int _MaxWeigh = 200;
    private const int _MinWeigh = 1;

    private string _flourType;
    private string _bakingTechnique;
    private int _weigh;
    private readonly Dictionary<string, double> doughTypes = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
    private readonly Dictionary<string, double> bakingTechniques = new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

    public Dough(string flourType, string bakingTechnique, int weigh)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weigh = weigh;
    }

    public int Weigh
    {
        get { return _weigh; }
        private set
        {
            if (value < _MinWeigh || value > _MaxWeigh)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            _weigh = value;
        }
    }

    public string BakingTechnique
    {
        get { return _bakingTechnique.ToLower(); }
        private set
        {
            if (!Enum.TryParse(value.ToLower(), out BakingTechnique _))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            _bakingTechnique = value;
        }
    }

    public string FlourType
    {
        get { return _flourType.ToLower(); }
        private set
        {
            if (!Enum.TryParse(value.ToLower(), out FlourType _))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            _flourType = value;
        }
    }

    public double GetCalories()
    {
        return 2 * Weigh * doughTypes[FlourType] * bakingTechniques[BakingTechnique];
    }
}

public enum FlourType
{
    white,
    wholegrain
}

public enum BakingTechnique
{
    crispy,
    chewy,
    homemade
}