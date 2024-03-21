namespace ConsoleApp1.Ships;

public class Ship
{
    public double maxSpeed { get; set; }
    public double maxWeight { get; set; }
    public int maxContainers { get; set; }
    
    public List<Container> Containers = new List<Container>();

    public Ship(double maxSpeed, double maxWeight, int maxContainers)
    {
        this.maxSpeed = maxSpeed;
        this.maxWeight = maxWeight;
        this.maxContainers = maxContainers;
    }

    public bool LoadContainer(Container container)
    {
        if (maxContainers < Containers.Count+1)
        {
            Console.WriteLine("Too many containers on ship.");
            return false;
        }

        double currWeight = 0;
        foreach (var vcontainer in Containers)
        {
            currWeight += (vcontainer.tareWeight + vcontainer.cargoMass);
        }

        if (maxWeight > currWeight+container.cargoMass+container.tareWeight)
        {
            Containers.Add(container);
            Console.WriteLine("Container added");
            return true;
        }
        Console.WriteLine("Container is to heavy to load");
        return false;
    }

    public bool LoadContainer(List<Container> containersToLoad)
    {
        
        if (maxContainers < Containers.Count + containersToLoad.Count)
        {
            Console.WriteLine("Too many containers on ship.");
            return false;
        }

        double currWeight = 0;
        double toLoadWeight = 0;
        foreach (var container in Containers)
        {
            currWeight += (container.tareWeight + container.cargoMass);
        }

        foreach (var container in containersToLoad)
        {
            toLoadWeight += (container.tareWeight + container.cargoMass);
        }

        if (maxWeight > currWeight+toLoadWeight)
        {
            Containers.AddRange(containersToLoad);
            Console.WriteLine("Containers added");
            return true;
        }
        Console.WriteLine("Containers are to heavy to load");
        return false;
    
    }

    public void UnloadContainer(Container container)
    {
        Containers.Remove(container);
        Console.WriteLine("Container was unloaded");
    }

    public void ReplaceContainer(Container toLoad, int toUnload)
    {
        Container cont = null;
        foreach (var container in Containers)
        {
            if (container.number == toUnload)
            {
                cont = container;
            }
        }

        if (cont != null)
        {
            UnloadContainer(cont);
            LoadContainer(toLoad);
            Console.WriteLine("Replaced containers");
        }
        else
        {
            Console.WriteLine("Container was not found");
        }
        
    }

    public void TransferContainer(Container containerToTransfer, Ship ship)
    {
        if (Containers.Contains(containerToTransfer))
        {
            if (ship.LoadContainer(containerToTransfer))
            {
                UnloadContainer(containerToTransfer);
                Console.WriteLine("Container was transfered");
            }
        }
        else
        {
            Console.WriteLine("Container was not found");
        }
    }

    public void Info()
    {
        double cargoWeight = 0;

        foreach (var container in Containers)
        {
            cargoWeight += (container.tareWeight + container.cargoMass);
        }
        
        Console.WriteLine($"""
                           Max speed: {maxSpeed}
                           Max weight: {maxWeight}
                           Max containers: {maxContainers}
                           Current amount of containers: {Containers.Count}
                           Current weight of cargo: {cargoWeight}
                           
                           """);
    }
}