var wardrobe = new Dictionary<string, Dictionary<string, int>>();

var numberOfLines = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfLines; i++)
{
    var line = Console.ReadLine().Split("->").ToList();

    var color = line[0];
    var clothes = line[1].Split(",", StringSplitOptions.TrimEntries).ToList();

    if (!wardrobe.Keys.Contains(color))
    {
        wardrobe[color] = new Dictionary<string, int>();

        foreach (var item in clothes)
        {
            if (!wardrobe[color].Keys.Contains(item))
            {
                wardrobe[color][item] = 1;
            }
            else
            {
                wardrobe[color][item] += 1;
            }
        }
    }
    else
    {
        foreach (var item in clothes)
        {
            if (!wardrobe[color].Keys.Contains(item))
            {
                wardrobe[color][item] = 1;
            }
            else
            {
                wardrobe[color][item] += 1;
            }
        }
    }
}

var searchClothe = Console.ReadLine().Split(" ", StringSplitOptions.TrimEntries).ToList();
var colorOfClothe = searchClothe[0];
var clothe = searchClothe[1];

foreach (var item in wardrobe)
{
    Console.WriteLine($"{item.Key}clothes:");
    foreach (var thing in item.Value)
    {
        if (colorOfClothe == item.Key.Trim() && clothe == thing.Key.Trim())
        {
            Console.WriteLine($"* {thing.Key} - {thing.Value} (found!)");
        }
        else
        {
            Console.WriteLine($"* {thing.Key} - {thing.Value}");
        }


    }
}
