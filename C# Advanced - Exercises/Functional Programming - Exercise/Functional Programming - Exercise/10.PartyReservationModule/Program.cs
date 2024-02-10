var inputNames = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

var resulList = new List<string>();
foreach (var name in inputNames)
{
    resulList.Add(name);
}

string inputCommands;

while ((inputCommands = Console.ReadLine()) != "Print")
{
    var commands = inputCommands.Split(";", StringSplitOptions.RemoveEmptyEntries);
    var command = commands[0];
    var filter = commands[1];
    var parameter = commands[2];

    Func<string, bool> predicate = GetPredicate(filter, parameter);

    switch (command)
    {
        case "Add filter":
            inputNames = Add(inputNames, resulList, predicate);
            break;
        case "Remove filter":
            inputNames = Remove(inputNames, resulList, predicate);
            break;
    }
}

Console.WriteLine(string.Join(" ", inputNames));

Func<string, bool> GetPredicate(string filter, string parameter)
{
    if (filter == "Starts with")
    {
        return x => x.StartsWith(parameter);
    }
    else if (filter == "Ends with")
    {
        return x => x.EndsWith(parameter);
    }
    else if (filter == "Length")
    {
        return x => x.Length == int.Parse(parameter);
    }
    else if (filter == "Contains")
    {
        return x => x.Contains(parameter);
    }

    return default;
}

static List<string> Add(List<string> guestList, List<string> resultList, Func<string, bool> predicate)
{
    return guestList = guestList.Where(x => predicate(x) == false).ToList();
}

static List<string> Remove(List<string> guestList, List<string> resultList, Func<string, bool> predicate)
{
    foreach (var guest in resultList)
    {
        if (predicate(guest))
        {
            guestList.Add(guest);
        }
    }

    return guestList;
}