using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using InventoryLibrary;

namespace InventoryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {

            while (true) 
            {
                InventoryManager.ShowMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        InventoryManager.AddProduct();
                        break;

                    case "2":
                        InventoryManager.UpdateQuantity();
                        break;

                    case "3":
                        InventoryManager.ViewInventory();
                        break;

                    case "4":
                        InventoryManager.DeleteProduct();
                        break;

                    case "5":
                        Console.WriteLine("Exiting... Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear(); 
            }

        }
    }
}