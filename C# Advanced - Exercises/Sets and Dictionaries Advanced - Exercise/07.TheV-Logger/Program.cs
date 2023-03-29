using System.Text;

var input = Console.ReadLine();

var log = new Dictionary<string, Dictionary<string, int>>();
var vloggers = new Dictionary<string, List<string>>();

while (input!= "Statistics")
{
    var argguments = input.Split().ToList();

    var vloggername = argguments[0];
    var command = argguments[1];

    if (command== "joined")
    {
        if (!log.ContainsKey(vloggername)) 
        {
            log[vloggername] = new Dictionary<string, int>();
            log[vloggername]["followers"] = 0;
            log[vloggername]["following"] = 0;
            vloggers[vloggername] = new List<string>();
        }
    }
    else
    {
        var secondVloggername = argguments[2];

        if (log.ContainsKey(secondVloggername) && 
            log.ContainsKey(vloggername) && 
            !vloggers[vloggername].Contains(secondVloggername)&&
            vloggername!=secondVloggername)
        {
            log[vloggername]["following"]++;
            log[secondVloggername]["followers"]++;
            vloggers[secondVloggername].Add(vloggername);
        }
    }

    input = Console.ReadLine();
}

var result = new StringBuilder();
var theMostFamous = vloggers.OrderByDescending(x => x.Value.Count).Select(v=>v.Key).First();

result.AppendLine($"The V-Logger has a total of {log.Count} vloggers in its logs.");
result.AppendLine($"1. {theMostFamous} : {log[theMostFamous]["followers"]} followers, {log[theMostFamous]["following"]} following");


Console.WriteLine(result.ToString().TrimEnd());