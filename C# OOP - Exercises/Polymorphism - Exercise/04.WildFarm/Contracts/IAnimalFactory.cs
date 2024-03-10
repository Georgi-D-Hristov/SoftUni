using _04.WildFarm.Models;

namespace _04.WildFarm.Contracts
{
    public interface IAnimalFactory
    {
        Animal CreateAnimal(params string[] args);
    }
}