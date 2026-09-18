using System;

namespace BoardgameCatalog;

public class Boardgame
{
    public string Name {get; private set;}
    public string PlayerCount {get; private set;}
    public int EstimatedGameTime {get; private set;}
    public double Rating {get; private set;}

    public List<PlaySession> Sessions {get; private set;} = new();

    public int GamesPlayed {get; private set;} = 0;
    // public int WonGames {get; private set;}

    public Boardgame (string name, string playerCount, int estimatedGameTime, double rating)
    {
        Name = name;
        PlayerCount = playerCount;
        EstimatedGameTime = estimatedGameTime;
        Rating = rating;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"{Name}");
        Console.WriteLine($"\tPlayer Count: {PlayerCount}");
        Console.WriteLine($"\tEstimated Game Time: {EstimatedGameTime} min");
        Console.WriteLine($"\tRating: {Rating} / 5");
    }

    public void DisplayAllSessions()
    {
        Console.WriteLine("\tAll Sessions: ");
        int sessionNumber = 1;
        foreach (var session in Sessions)
        {
            Console.WriteLine($"\tSession {sessionNumber}");
            Console.WriteLine($"\t\tDate: {session.Date.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"\t\tGame Time: {session.GameTime} min");
            Console.WriteLine($"\t\tPlayrs: {session.Players}");
            Console.WriteLine($"\t\tWinner: {session.Winner}");
            sessionNumber++;
        }
    }

    public void AddSession(PlaySession session)
    {
        Sessions.Add(session);
        GamesPlayed++;
    }

    public void UpdateInfo(Boardgame game)
    {
        PlayerCount = game.PlayerCount;
        EstimatedGameTime = game.EstimatedGameTime;
        Rating = game.Rating;
    }

}