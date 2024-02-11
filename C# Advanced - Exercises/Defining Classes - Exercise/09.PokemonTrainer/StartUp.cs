namespace _09.PokemonTrainer;

public class StartUp
{
    public static void Main(string[] args)
    {
        var trainers = new List<Trainer>();

        string trainersInput;
        while ((trainersInput = Console.ReadLine()) != "Tournament")
        {
            var trainerInfo = trainersInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var trainerName = trainerInfo[0];
            var pokemonName = trainerInfo[1];
            var pokemonElement = trainerInfo[2];
            var pokemonHealth = int.Parse(trainerInfo[3]);

            var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            var existTrainer = trainers.Where(t => t.Name == trainerName).FirstOrDefault();
            if (existTrainer == null)
            {
                var trainer = new Trainer(trainerName);
                trainer.AddPokemon(pokemon);
                trainers.Add(trainer);
            }
            else
            {
                existTrainer.AddPokemon(pokemon);
            }
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            switch (command)
            {
                case "Fire":
                    CheckCommand(trainers, command);
                    break;
                case "Water":
                    CheckCommand(trainers, command);
                    break;
                case "Electricity":
                    CheckCommand(trainers, command);
                    break;
                default:
                    break;
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
        {
            Console.WriteLine(trainer);
        }
    }

    private static void CheckCommand(List<Trainer> trainers, string command)
    {
        foreach (var train in trainers)
        {
            var pokemon = train.Pokemons.Where(p => p.Element == command).FirstOrDefault();
            if (pokemon != null)
            {
                train.NumberOfBadges++;
            }
            else
            {
                foreach (var poke in train.Pokemons)
                {
                    train.DecreasePokemonHelth(poke);
                }
                foreach (var item in trainers)
                {
                    item.RemovePokemon();
                }
            }
        }
    }
}
