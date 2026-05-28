using System;
using Duniverse.Data;
using Duniverse.Models;

namespace Duniverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Booting up the Duniverse Encyclopedia...");
            
            // 1. Initialize the Repository (This automatically runs your seeders)
            DuniverseRepository repository = new DuniverseRepository();
            
            Console.WriteLine("Data loaded successfully!\n");

            // 2. Test a lookup loop
            while (true)
            {
                Console.Write("Enter an entity ID to search (or type 'exit' to quit): ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)) continue;
                if (input.ToLower() == "exit") break;

                // 3. Ask the repository for the item
                DuneEntity? result = repository.GetEntity(input);

                if (result != null)
                {
                    // 4. Print the result if found
                    Console.WriteLine("\n--- ENTRY FOUND ---");
                    Console.WriteLine($"Name: {result.Name}");
                    Console.WriteLine($"Description: {result.ShortDescription}");
                    Console.WriteLine($"History: {result.DetailedHistory}");
                }
                else
                {
                    Console.WriteLine("\n[!] Entity not found. Please check the ID and try again.\n");
                }
            }
        }
    }
}