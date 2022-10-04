using BoardLove.Models;

namespace BoardLove.Services;

public static class GameService
{
    static List<Game> Games { get; }
    static int nextId = 3;
    static GameService()
    {
        Games = new List<Game>
        {
            new Game { Id = 1, Name = "Monopoly", MaxPlayers=4,MinPlayers=2, PlayingTime="2" },
            new Game { Id = 2, Name = "Scrabble", MaxPlayers=0,MinPlayers = 1,PlayingTime="1" }
        };
    }

    public static List<Game> GetAll() => Games;

    public static Game? Get(int id) => Games.FirstOrDefault(p => p.Id == id);

    public static void Add(Game game)
    {
        game.Id = nextId++;
        Games.Add(game);
    }

    public static void Delete(int id)
    {
        var game = Get(id);
        if (game is null)
            return;

        Games.Remove(game);
    }

    public static void Update(Game game)
    {
        var index = Games.FindIndex(p => p.Id == game.Id);
        if (index == -1)
            return;

        Games[index] = game;
    }
}