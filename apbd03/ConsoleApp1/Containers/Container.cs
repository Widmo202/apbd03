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

    protected Container(double cargoMass, double height, double tareWeight, double depth)
    {
        this.cargoMass = cargoMass;
        this.height = height;
        this.cargoMass = cargoMass;
        this.tareWeight = tareWeight;
        this.depth = depth;
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
    
}