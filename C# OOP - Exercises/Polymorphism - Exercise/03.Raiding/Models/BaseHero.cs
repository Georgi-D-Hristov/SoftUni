using _03.Raiding.Contracts;

namespace _03.Raiding.Models;

using System;

public abstract class BaseHero : IBaseHero
{
    public BaseHero(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    public virtual int Power { get; init; }

    public virtual string CastAbility()
    {
        return String.Empty;
    }
}