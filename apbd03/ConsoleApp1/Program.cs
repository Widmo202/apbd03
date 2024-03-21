// See https://aka.ms/new-console-template for more information


using ConsoleApp1;
using ConsoleApp1.Containers;
using ConsoleApp1.Ships;

Dictionary<PossibleProducts,double> products = new();
products.Add(PossibleProducts.Banana,13.3);
products.Add(PossibleProducts.Chocolate,18);
products.Add(PossibleProducts.Fish,2);
products.Add(PossibleProducts.Meat,-15);
products.Add(PossibleProducts.IceCream,-18);
products.Add(PossibleProducts.FrozenPizza,-30);
products.Add(PossibleProducts.Cheese,7.2);
products.Add(PossibleProducts.Sausages,5);
products.Add(PossibleProducts.Butter,20.5);
products.Add(PossibleProducts.Eggs,19);

List<Container> containers = new();
List<Ship> ships = new();

Random r = new();

for (int i = 0; i < 3; i++)
{
    bool haz = i%2 == 1;

    string name = "";

    switch (i)
    {
        case 0:
            name = "Milk";
            break;
        case 1:
            name = "Fuel";
            break;
        case 2:
            name = "Water";
            break;
    }
    
    containers.Add(new LiquidContainer(300.0,300,10,5,haz,name,400));
}

containers.Add(new GasContainer(350,300,10,20,2,400));
containers.Add(new GasContainer(300,200,10,15,2,400));
containers.Add(new GasContainer(250,100,10,15,2,400));

containers.Add(new RefrigeratedContainer(300,300,10,5,PossibleProducts.Banana,10,products,400));
containers.Add(new RefrigeratedContainer(300,300,10,5,PossibleProducts.Sausages,10,products,400));
containers.Add(new RefrigeratedContainer(300,300,10,5,PossibleProducts.IceCream,-10,products,400));

ships.Add(new Ship(20,5000,10));
ships.Add(new Ship(35,1000,2));

foreach (var c in containers)
{
    c.Info();
}

foreach (var s in ships)
{
    s.Info();
}


ships[0].LoadContainer(containers[0]);
ships[0].LoadContainer(containers[2]);
ships[0].LoadContainer(containers[4]);
ships[0].LoadContainer(containers[6]);


ships[1].LoadContainer(containers[3]);

ships[0].ReplaceContainer(containers[1],1);

ships[0].TransferContainer(containers[2],ships[1]);
ships[0].TransferContainer(containers[4],ships[1]);

Console.WriteLine("""
                  ------------------------------------------------------
                  New info ships:

                  """);

foreach (var s in ships)
{
    s.Info();
}


Console.WriteLine("""
                  ------------------------------------------------------
                  After unloading:
                  
                  """);

containers[4].Unload();
containers[4].Info();

containers[4].Load(1000);

