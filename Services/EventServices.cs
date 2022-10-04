using BoardLove.Models;

namespace BoardLove.Services;

public static class EventService
{
    static List<EventGame> EventGames { get; }
    static int nextId = 3;
    static EventService()
    {
        EventGames = new List<EventGame>
        {
            new EventGame { Id = 1, Name = "Spotkanie u staszka", Place="u staszka", Date= DateTime.Now, ParticipainsId = new int [1] },
        };
}

public static List<EventGame> GetAll() => EventGames;

public static EventGame? Get(int id) => EventGames.FirstOrDefault(p => p.Id == id);

public static void Add(EventGame eventGame)
{
    eventGame.Id = nextId++;
    EventGames.Add(eventGame);
}

public static void Delete(int id)
{
    var game = Get(id);
    if (game is null)
        return;

    EventGames.Remove(game);
}

public static void Update(EventGame eventGame)
{
    var index = EventGames.FindIndex(p => p.Id == eventGame.Id);
    if (index == -1)
        return;

    EventGames[index] = eventGame;
}
}