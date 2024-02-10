var names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input;

while ((input = Console.ReadLine()) != "Party!")

{

    var commands = input.Split();
    var command = commands[0];
    var creteria = commands[1];
    var parameter = commands[2];


    Func<string, bool> predicate = GetPredicate(creteria, parameter);

    switch (command)
    {
        case "Double":
            names = Double(names, predicate);
            break;
        case "Remove":
            names = Remove(names, predicate);
            break;
    }
}

if (!names.Any())
{
    Console.WriteLine("Nobody is going to the party!");
}
else
{
    Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
}

Func<string, bool> GetPredicate(string command, string parameter)
{
    if (command == "StartsWith")
    {
        return x => x.StartsWith(parameter);

    }

    if (command == "EndsWith")
    {
        return x => x.EndsWith(parameter);
    }

    if (command == "Length")
    {
        return x => x.Length == int.Parse(parameter);
    }

    return default;
}

static List<string> Double(List<string> guestList, Func<string, bool> predicate)
{
    var result = new List<string>();

    foreach (var guest in guestList)
    {
        if (predicate(guest))
        {
            result.Add(guest);
        }
        result.Add(guest);
    }
    return result;
}

static List<string> Remove(List<string> guestList, Func<string, bool> predicate)
{
    var result = guestList.Where(name => predicate(name) == false).ToList();
    return result;
}
