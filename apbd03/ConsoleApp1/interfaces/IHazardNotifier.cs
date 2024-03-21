namespace ConsoleApp1.interfaces;

public interface IHazardNotifier
{
    public static void throwHazardous(Container container)
    {
        Console.WriteLine("Hazardous situation detected: "+container.name);
    }
}