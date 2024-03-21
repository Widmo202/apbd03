using ConsoleApp1.interfaces;
using ConsoleApp1.Exceptions;

namespace ConsoleApp1.Containers;

public class GasContainer : Container, IHazardNotifier
{
    public double pressure { get; set; }
    public GasContainer(double cargoMass, double height, double tareWeight, double depth, double pressure) : base(cargoMass, height, tareWeight,depth)
    {
        this.pressure = pressure;
        base.name += "G-" + base.GenerateSerialNumber();
    }
    
    public override void Load(double cargoMass)
    {
        if (base.cargoMass+cargoMass > base.maxWeight)
        {
            IHazardNotifier.throwHazardous(this);
            throw new OverfillException("Overfill detected");
        }else if (base.cargoMass+cargoMass > base.maxWeight-(base.maxWeight/10))
        {
            Console.WriteLine("Hazardous situation detected: "+base.name);
            throw new OverfillException("Overfill detected");
        }
        else
        {
            base.Load(cargoMass);
        }
    }

    public override void Unload()
    {
        base.cargoMass /= 20;
    }
}