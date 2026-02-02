namespace InventoryLibrary;

public static class InventoryManager
{
    static List<string> names = new();
    static List<int> ids = new();
    static List<int> quantities = new();
    static List<int> prices = new();
    public static void ShowMenu()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("========================================");
        Console.WriteLine("   INVENTORY MANAGEMENT SYSTEM          ");
        Console.WriteLine("========================================");
        Console.ResetColor();
        
        Console.WriteLine("[1] Add New Product");
        Console.WriteLine("[2] Update Product Quantity");
        Console.WriteLine("[3] View Current Inventory");
        Console.WriteLine("[4] Delete Product");
        Console.WriteLine("[5] Exit Close Program");
        Console.Write("\nChoose an option (1-4): ");
    }
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
    public static void ViewInventory()
    {
        if (names.Count == 0)
        {
            Console.WriteLine("There are no products in inventory!");
            return;
        }

        Console.BackgroundColor = ConsoleColor.Red;
        Console.WriteLine("----- Inventory -----");
        Console.ResetColor();
        for (int i = 0; i < names.Count; i++)
        {
            Console.WriteLine(
                $"Name: {names[i]}, ID: {ids[i]}, Quantity: {quantities[i]}, Price: {prices[i]}"
            );
        }
    }
    public static void UpdateQuantity()
    {
        if (ids.Count == 0)
        {
            Console.WriteLine("Inventory is empty!");
            return;
        }

        Console.Write("Enter Product ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        int index = ids.IndexOf(id);
        if (index == -1)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        Console.Write("Enter New Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int newQty))
        {
            Console.WriteLine("Invalid Quantity!");
            return;
        }

        quantities[index] = newQty;
        Console.WriteLine("Quantity updated successfully!");
    }
    public static void DeleteProduct()
    {
        if (names.Count == 0)
        {
            Console.WriteLine("There are no products in inventory!");
            return;
        }

        Console.WriteLine("Enter Product ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID!");
            return;
        }

        int index = ids.IndexOf(id);

        if (index == -1)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Write("Are you sure (y/n): ");
        string? confirm = Console.ReadLine();

        if (confirm?.ToLower() != "y")
        {
            Console.WriteLine("Product was not deleted.");
            return;
        }

        Console.ResetColor();
        names.RemoveAt(index);
        ids.RemoveAt(index);
        quantities.RemoveAt(index);
        prices.RemoveAt(index);

        Console.WriteLine("Product deleted successfully!");
    }

    public static void SaveToFile()
    {
        string filePath = "inventory.txt";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < names.Count; i++)
            {
                string line = $"{ids[i]}|{names[i]}|{quantities[i]}|{prices[i]}";
                writer.WriteLine(line);
            }
        }

        Console.WriteLine("Inventory saved to file successfully!");
    }


    public static void LoadFromFile()
    {
        string filePath = "inventory.txt";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("No saved inventory file found!");
            return;
        }

        names.Clear();
        ids.Clear();
        quantities.Clear();
        prices.Clear();

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            int id = int.Parse(parts[0]);
            string name = parts[1];
            int quantity = int.Parse(parts[2]);
            int price = int.Parse(parts[3]);

            ids.Add(id);
            names.Add(name);
            quantities.Add(quantity);
            prices.Add(price);
        }

        Console.BackgroundColor = ConsoleColor.Gray;
        Console.WriteLine("Inventory loaded from file successfully!");
        Console.ResetColor();
    }
}
