namespace _05.BirthdayCelebrations;

public class Citizen : IIdentical, IBirthable
{
    public Citizen(string name, int age, string id, string birthDay)
    {
        Name = name;
        Id = id;
        Birthday = birthDay;
    }

    public string Name { get; set; }
    public string Id { get; init; }
    public string Birthday { get; init; }
    public int Age { get; set; }
}