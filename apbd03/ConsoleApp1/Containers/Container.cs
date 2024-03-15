using ConsoleApp1.Exceptions;
using ConsoleApp1.interfaces;

namespace ConsoleApp1;

public abstract class Container : IContainer
{
    public double cargoMass { get; set; }
    public double height { get; set; }

    protected Container(double cargoMass, double height)
    {
        this.cargoMass = cargoMass;
        this.height = height;
    }

    public void Unload()
    {
        throw new NotImplementedException();
    }

    public virtual void Load(double cargoMass)
    {
        throw new OverfillException();
    }
}