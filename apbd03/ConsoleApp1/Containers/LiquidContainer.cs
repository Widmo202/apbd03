using ConsoleApp1.Exceptions;
using ConsoleApp1.interfaces;

namespace ConsoleApp1.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool hazardous { get; set; }
    public string cargoName { get; set; }
    public LiquidContainer(double cargoMass, double height, double tareWeight, double depth, bool hazardous, string cargoName) : base(cargoMass, height, tareWeight,depth)
    {
        this.cargoName = cargoName;
        this.hazardous = hazardous;
        base.name += "L-" + base.GenerateSerialNumber();
    }

    public override void Load(double cargoMass)
    {
        if (base.cargoMass+cargoMass > base.maxWeight/2 && hazardous)
        {
            IHazardNotifier.throwHazardous(this);
            throw new OverfillException("Overfill detected");
        }else if (base.cargoMass+cargoMass > base.maxWeight-(base.maxWeight/10))
        {
            IHazardNotifier.throwHazardous(this);
            throw new OverfillException("Overfill detected");
        }
        else
        {
            base.Load(cargoMass);
        }
    }
}