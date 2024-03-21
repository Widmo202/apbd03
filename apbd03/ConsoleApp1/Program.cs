// See https://aka.ms/new-console-template for more information


using ConsoleApp1.Containers;

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

Console.WriteLine("Hello, World!");