using System;

namespace BoardgameCatalog;

public class PlaySession
{
    public DateTime Date {get; private set;}
    public int GameTime {get; private set;}
    public string Players {get; private set;}
    public string Winner {get; private set;}

    public PlaySession (DateTime date, int gameTime, string allPlayers, string winner)
    {
        Date = date;
        GameTime = gameTime;
        Players = allPlayers;
        Winner = winner;
    }
}