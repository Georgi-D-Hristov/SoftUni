namespace _04.BorderControl;

using System;

public class Robot : IRobot, IIdentical, IVisitors
{
    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Model { get; }
    public string Id { get; }

    public void ValidateId(string pattern)
    {
        if (Id.EndsWith(pattern))
        {
            Console.WriteLine(Id);
        }
    }
}