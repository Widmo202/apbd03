namespace ConsoleApp1.Containers;

public class RefrigeratedContainer : Container
{
    public PossibleProducts product { get; set; }
    public double temp { get; set; }

    public RefrigeratedContainer(double cargoMass, double height, double tareWeight, double depth, PossibleProducts product, int temp, Dictionary<PossibleProducts,Double> dictionary) : base(cargoMass, height, tareWeight,depth)
    {
        if (dictionary[product] > temp)
        {
            Console.WriteLine("Temperature is too low - rising temp to minimum");
            this.temp = dictionary[product];
        }
        else
            this.temp = temp;

        base.name += "C-" + base.GenerateSerialNumber();
        
    }
}