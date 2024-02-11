namespace _09.PokemonTrainer;

public class Trainer
{
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        Name = name;
        NumberOfBadges = 0;
        Pokemons = new List<Pokemon>();
    }

    public string Name { get; set; }
    public int NumberOfBadges { get; set; }
    public List<Pokemon> Pokemons { get => pokemons; set => pokemons = value; }

    public void AddPokemon(Pokemon pokemon)
    {
        pokemons.Add(pokemon);
    }
    public void DecreasePokemonHelth(Pokemon pokemon)
    {
        pokemon.Helth -= 10;
        //if (pokemon.Helth<=0)
        //{
        //    Pokemons.Remove(pokemon);
        ////}
    }
    public void RemovePokemon()
    {
        var deadPokemon =pokemons.Where(p=>p.Helth<=0).FirstOrDefault();
        if (deadPokemon!=null)
        {
            pokemons.Remove(deadPokemon);
        }
    }

    public override string? ToString()
    {
        return $"{Name} {NumberOfBadges} {Pokemons.Count}";
    }
}
