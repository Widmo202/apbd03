namespace ConsoleApp1.Containers;

public class LiquidContainer : Container
{
    public LiquidContainer(double cargoMass, double height) : base(cargoMass, height)
    {
        
    }

    public override void Load(double cargoMass)
    {
        base.Load(cargoMass);
    }
}