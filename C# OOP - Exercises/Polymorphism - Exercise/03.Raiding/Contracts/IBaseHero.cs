namespace _03.Raiding.Contracts;

public interface IBaseHero
{
    string Name { get; init; }
    int Power { get; init; }

    string CastAbility();
}