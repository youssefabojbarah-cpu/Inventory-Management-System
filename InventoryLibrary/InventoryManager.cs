namespace InventoryLibrary;

public static class InventoryManager
{
    static List<string> names = new();
    static List<int> ids = new();
    static List<int> quantities = new();
    static List<int> prices = new();

    public static void AddProduct()
    {
        Console.Write("Enter Name: ");
        string? name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Invalid Name!");
            return;
        }
        names.Add(name);

        Console.Write("Enter ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }
        ids.Add(id);

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid Quantity!");
            return;
        }
        quantities.Add(quantity);

        Console.Write("Enter Price: ");
        if (!int.TryParse(Console.ReadLine(), out int price))
        {
            Console.WriteLine("Invalid Price!");
            return;
        }
        prices.Add(price);

        Console.WriteLine("✅ Product added successfully!");
    }
}
