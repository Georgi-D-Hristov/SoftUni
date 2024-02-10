namespace _07.RawData;

public class Car
{
    private List<Tire> tires= new List<Tire>();

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        Model = model;
        Engine = engine;
        Cargo = cargo;
        Tires=tires;
    }
    public List<Tire> Tires { get; set; }
    public string Model { get; set; }
    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public override string? ToString()
    {
        return Model;
    }
}
