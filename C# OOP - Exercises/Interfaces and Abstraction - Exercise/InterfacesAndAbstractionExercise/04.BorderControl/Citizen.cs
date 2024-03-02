namespace _04.BorderControl;

using System;

public class Citizen : IHuman, IIdentical, IVisitors
{
    public Citizen(string name, int age, string id)
    {
        Name = name;
        Age = age;
        Id = id;
    }

    public string Name { get; }
    public int Age { get; set; }
    public string Id { get; }

    public void ValidateId(string pattern)
    {
        if (Id.EndsWith(pattern))
        {
            Console.WriteLine(Id);
        }
    }
}