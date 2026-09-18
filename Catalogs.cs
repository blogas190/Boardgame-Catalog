using System;

namespace BoardgameCatalog;

public class Catalog
{
    public Dictionary<string, Boardgame> Boardgames {get; private set;} = new();

    public void AddGame()
    {
        Console.WriteLine("Enter the game's name");
        string? gameName = Console.ReadLine();

        Console.WriteLine("Enter the game's player count. Format : x-y OR x");
        string? playerCount = Console.ReadLine();

        Console.WriteLine("Enter estimated time to finish a play session of the game. Format : x");
        int gameTime = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine("Enter the rating of the game. Format : x / 5");
        double rating = double.Parse(Console.ReadLine() ?? "0");

        if(!string.IsNullOrWhiteSpace(gameName) && !string.IsNullOrWhiteSpace(playerCount) && gameTime > 0 && rating > 0)
        {
            Boardgames.Add(gameName,new Boardgame(gameName, playerCount, gameTime, rating));
            Console.WriteLine("Game added succesfully. Press Enter to go back to the start");
            Console.ReadLine(); 
        }
    }
    
    public void RemoveGame()
    {
        Console.WriteLine("Enter the game's name you want to remove from the catalog");
        string? gameName = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(gameName))
            {
                Boardgames.Remove(gameName);
                Console.WriteLine("Game removed succesfully. Press Enter to go back to the start");
                Console.ReadLine();
            }
    }

    public Boardgame? FindGame(string game)
    {
        if(Boardgames.ContainsKey(game))
        {
            return Boardgames[game];   
        }
        return null;
    }

    public void UpdateGame()
    {
        Console.WriteLine("Enter the name of the game to which you would like to update");
        Console.WriteLine("The Games:");
        CatalogServices.DisplayAllGames(Boardgames);
        string? gameName = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(gameName))
        {
            Boardgame tempGame = FindGame(gameName);
            if(tempGame != null)
            {
                string newPlayerCount = tempGame.PlayerCount;
                int newEstimatedGameTime = tempGame.EstimatedGameTime;
                double newRating = tempGame.Rating;
                Console.WriteLine("What information would you like to update? Enter a number");
                Console.WriteLine("1. Player count");
                Console.WriteLine("2. Estimated game time");
                Console.WriteLine("3. Rating");

                string? input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the updated Player count");
                            Console.WriteLine($"Old Player count: {tempGame.PlayerCount}");
                            Console.WriteLine("Retype the information if you want to keep it");
                            newPlayerCount = Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter the updated Estimated game time");
                            Console.WriteLine($"Old Estimated game time: {tempGame.EstimatedGameTime}");
                            Console.WriteLine("Retype the information if you want to keep it");
                            newEstimatedGameTime = int.Parse(Console.ReadLine());
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Enter the updated Rating");
                            Console.WriteLine($"Old Rating: {tempGame.Rating} / 5");
                            Console.WriteLine("Retype the information if you want to keep it");
                            newRating = double.Parse(Console.ReadLine());
                            break;
                        }
                }

                Boardgame updatedGame = new Boardgame(gameName, newPlayerCount, newEstimatedGameTime, newRating);

                FindGame(gameName).UpdateInfo(updatedGame);
            }
        }
    }

    public void AddPlaySessionToGame()
    {
        Console.WriteLine("Enter the name of the game to which you would like to add a play session");
        Console.WriteLine("The Games:");
        CatalogServices.DisplayAllGames(Boardgames);
        string? gameName = Console.ReadLine();

        if(!string.IsNullOrWhiteSpace(gameName))
        {
            Console.WriteLine("Enter the date you played this session. Format : dd/MM/yyyy");
            DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date);

            Console.WriteLine("Enter the amount of time you played. Format : x");
            int gameTime = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the players that played. Format : x, y, z, ...");
            string? players = Console.ReadLine();

            Console.WriteLine("Enter who won the game");
            string? winner = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(players) && !string.IsNullOrWhiteSpace(winner) && gameTime > 0)
            {
                if(FindGame(gameName) != null)
                {
                    FindGame(gameName).AddSession(new PlaySession(date, gameTime, players, winner));
                    Console.WriteLine("Session added succesfully. Press Enter to go back to the start");
                    Console.ReadLine(); 
                } 
            }
        }
    }

    public void DisplayGameInfoInCatalog()
    {
        Console.WriteLine("Enter the name of the game you would like to view the information of");
        Console.WriteLine("The Games:");
        CatalogServices.DisplayAllGames(Boardgames);

        string? gameName = Console.ReadLine();
        if(!string.IsNullOrWhiteSpace(gameName) && FindGame(gameName) != null)
        {
            FindGame(gameName).DisplayInfo();
            FindGame(gameName).DisplayAllSessions();

            Console.WriteLine("\nPress Enter to go back to the start");
            Console.ReadLine();
        }
    }
}