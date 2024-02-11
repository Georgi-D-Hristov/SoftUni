namespace _09.PokemonTrainer;

public class Pokemon
{
    public Pokemon(string name, string element, int helth)
    {
        Name = name;
        Element = element;
        Helth = helth;
    }

    public string Name { get; set; }
    public string Element { get; set; }
    public int Helth { get; set; }
}
