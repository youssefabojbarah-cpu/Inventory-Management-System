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
                ShowMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        InventoryManager.AddProduct();
                        break;

                    case "2":
                        Console.WriteLine("--> Updating Product...");
                        break;
                    case "3":
                        Console.WriteLine("--> Viewing Inventory...");
                        break;
                    case "4":
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
        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("========================================");
            Console.WriteLine("   INVENTORY MANAGEMENT SYSTEM          ");
            Console.WriteLine("========================================");
            Console.ResetColor();
            
            Console.WriteLine("[1] Add New Product");
            Console.WriteLine("[2] Update Product Quantity");
            Console.WriteLine("[3] View Current Inventory");
            Console.WriteLine("[4] Exit Close Program");
            Console.Write("\nChoose an option (1-4): ");
        }
    }
}