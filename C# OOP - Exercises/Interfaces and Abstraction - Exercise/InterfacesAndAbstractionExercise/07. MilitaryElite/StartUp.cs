namespace _07._MilitaryElite;

using _07._MilitaryElite.Contracts;
using _07._MilitaryElite.Enums;
using _07._MilitaryElite.Models;
using System.Runtime.Versioning;

public class StartUp
{
    public static void Main(string[] args)
    {
        var solders = new List<ISoldier>();
        var privateSolders = new List<Private>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var solderArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var solderType = solderArgs[0];
            var solderId = int.Parse(solderArgs[1]);
            var solderFirstName = solderArgs[2];
            var solderLastName = solderArgs[3];
            var solderSalary = decimal.Parse(solderArgs[4]);

            switch (solderType)
            {
                case "Private":
                    var solderPrivate = new Private(solderId, solderFirstName, solderLastName, solderSalary);
                    solders.Add(solderPrivate);
                    privateSolders.Add(solderPrivate);
                    break;
                case "Engineer":
                    Corps corp;
                    var isCorpsValid = Enum.TryParse(solderArgs[5], out corp);
                    if (isCorpsValid)
                    {
                        var engineer = new Engineer(solderId, solderFirstName, solderLastName, solderSalary, corp);
                        solders.Add(engineer);

                        if (solderArgs.Length >= 7)
                        {
                            for (int i = 7; i < solderArgs.Length; i += 2)
                            {
                                var part = solderArgs[i];
                                var hours = int.Parse(solderArgs[i + 1]);
                                var repair = new Repair(part, hours);
                                engineer.AddRepairs(repair);
                            }
                        }

                    }

                    break;
                case "LieutenantGeneral":
                    var leutenantGeneral = new LieutenantGeneral(solderId, solderFirstName, solderLastName, solderSalary);
                    foreach (var prev in privateSolders)
                    {
                        
                         leutenantGeneral.AddPrivate((Private)prev);
                        
                    }
                    solders.Add(leutenantGeneral);
                    break;
                case "Commando":
                    Corps corpus;
                    var isCorpusValid = Enum.TryParse(solderArgs[5], out corpus);
                    if (isCorpusValid)
                    {
                        var commando = new Commando(solderId, solderFirstName, solderLastName, solderSalary, corpus);
                        solders.Add(commando);

                        if (solderArgs.Length >= 7)
                        {
                            for (int i = 7; i < solderArgs.Length; i += 2)
                            {
                                var code = solderArgs[i];
                                State state;
                                var isStatusValid = Enum.TryParse(solderArgs[i + 1], out state);
                                if (isStatusValid)
                                {
                                    var mission = new Mission(code, state);
                                    commando.AddMissions(mission);
                                }

                            }
                        }


                    }
                    break;
                case "Spy":
                    var spy = new Spy(solderId, solderFirstName, solderLastName, int.Parse(solderArgs[4]));
                    solders.Add(spy);
                    break;
            }
        }

        Console.WriteLine(string.Join("\n", solders));
    }
}
