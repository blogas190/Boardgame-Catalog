using System;

namespace BoardgameCatalog;

public class UI
{
    static void Main()
    {
        Catalog catalog = new Catalog();
        while(true)
        {
            Console.WriteLine("Game Catalog");
            Console.WriteLine("\nWhat would You like to do?");
            Console.WriteLine("1. Add a game");
            Console.WriteLine("2. Remove a game");
            Console.WriteLine("3. Add a play session");
            Console.WriteLine("4. Display information about a game");
            Console.WriteLine("5. Update game info");
            string? command = Console.ReadLine();

            switch(command)
            {
                case "1":
                    {
                        catalog.AddGame();
                        break;
                    }
                case "2":
                    {
                        catalog.RemoveGame();
                        break;
                    }
                case "3":
                    {
                        catalog.AddPlaySessionToGame();
                        break;
                    }
                case "4":
                    {
                        catalog.DisplayGameInfoInCatalog();
                        break;
                    }
                case "5":
                    {
                        catalog.UpdateGame();
                        break;
                    }

            }
        }
    }
}