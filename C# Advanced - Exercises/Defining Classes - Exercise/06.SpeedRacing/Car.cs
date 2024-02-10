namespace _06.SpeedRacing;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionPerKilometer;
    private double travelledDistance;

    public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        TravelledDistance = 0;
    }

    public double FuelConsumptionPerKilometer
    {
        get { return fuelConsumptionPerKilometer; }
        set { fuelConsumptionPerKilometer = value; }
    }

    public double TravelledDistance
    {
        get { return travelledDistance; }
        set { travelledDistance = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }


    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private void CalcTravelledDistance(double amountOfKm)
    {
        TravelledDistance += amountOfKm;
    }
    public void Drive(double distance)
    {
        var possibleDriveDistance = FuelAmount / fuelConsumptionPerKilometer;

        if (possibleDriveDistance >= distance)
        {
            CalcTravelledDistance(distance);
            FuelAmount -= (FuelConsumptionPerKilometer * distance);
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string? ToString()
    {
        return $"{Model} {FuelAmount:f2} {TravelledDistance}";
    }
}
