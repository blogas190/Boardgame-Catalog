using System;

namespace BoardgameCatalog;

public static class CatalogServices
{
    public static void DisplayAllGames(Dictionary<string, Boardgame> catalog)
    {
        int index = 1;
        foreach (var game in catalog.Values)
        {
            Console.WriteLine($"\t{index}. {game.Name}");
            index++;
        }
    }
}