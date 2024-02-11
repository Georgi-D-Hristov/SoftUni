namespace _08.CarSalesman;

using System.Text;

public class Car
{
    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
    }
    public Car(string model, Engine engine, int weight) : this(model, engine)
    {
        Weight = weight;
    }
    public Car(string model, Engine engine, string color) : this(model, engine)
    {
        Color = color;
    }
    public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
    {
        Color = color;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int? Weight { get; set; }
    public string? Color { get; set; }

    public override string? ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{Model}:");
        sb.AppendLine($"  {Engine.Model}:");
        sb.AppendLine($"    Power: {Engine.Power}");
        if (Engine.Displacement != null)
        {
            sb.AppendLine($"    Displacement: {Engine.Displacement}");
        }
        else
        {
            sb.AppendLine("    Displacement: n/a");
        }
        if (Engine.Efficiency != null)
        {
            sb.AppendLine($"    Efficiency: {Engine.Efficiency}");
        }
        else
        {
            sb.AppendLine("    Efficiency: n/a");
        }
        if (Weight != null)
        {
            sb.AppendLine($"  Weight: {Weight}");
        }
        else
        {
            sb.AppendLine($"  Weight: n/a");
        }
        if (Color != null)
        {
            sb.AppendLine($"  Color: {Color}");
        }
        else
        {
            sb.AppendLine($"  Color: n/a");
        }
        return sb.ToString().TrimEnd();
    }
}
