using ConsoleApp1.Exceptions;
using ConsoleApp1.interfaces;

namespace ConsoleApp1;

public abstract class Container : IContainer
{
    public string name { get; set; }
    public int number { get; set; }
    public double cargoMass { get; set; }
    public double tareWeight { get; set; }
    public double maxWeight { get; set; }
    
    public double height { get; set; }
    public double depth { get; set; }

    private static int lastSerialNumber = 0;

    protected Container(double cargoMass, double height, double tareWeight, double depth, double maxWeight)
    {
        this.cargoMass = cargoMass;
        this.height = height;
        this.cargoMass = cargoMass;
        this.tareWeight = tareWeight;
        this.depth = depth;
        this.maxWeight = maxWeight;
        name = "KON-";
    }

    public virtual void Unload()
    {
        cargoMass = 0;
    }

    public virtual void Load(double loadMass)
    {
        if (cargoMass + loadMass > maxWeight)
            throw new OverfillException();
        else
            cargoMass += loadMass;
    }
    public int GenerateSerialNumber()
    {
        lastSerialNumber++;
        number = lastSerialNumber;
        return lastSerialNumber;
    }

    public virtual void Info()
    {
        Console.WriteLine($"""
                          Name: {name}
                          Current cargo: {cargoMass}
                          Tare Weight: {tareWeight}
                          Height: {height}
                          Depth: {depth}
                          """);
    }
}