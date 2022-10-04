using BoardLove.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardLove.API
{
    public static class Utilities
    {
        public static void CreateAndRunApp(WebApplicationBuilder builder)
        {

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BoardLove API V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");


            app.MapGet("/games", async (GameDb db) => await db.Games.ToListAsync());
            app.MapGet("/game/{id}", async (GameDb db, int id) => await db.Games.FindAsync(id));

            app.MapPost("/game", async (GameDb db, Game game) =>
            {
                await db.Games.AddAsync(game);
                await db.SaveChangesAsync();
                return Results.Created($"/game/{game.Id}", game);
            });
            app.MapPut("/game/{id}", async (GameDb db, Game update, int id) =>
            {
                var pizza = await db.Games.FindAsync(id);
                if (pizza is null) return Results.NotFound();
                pizza.Name = update.Name;
                pizza.PlayingTime = update.PlayingTime;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
            app.MapDelete("/game/{id}", async (GameDb db, int id) =>
            {
                var game = await db.Games.FindAsync(id);
                if (game is null)
                {
                    return Results.NotFound();
                }
                db.Games.Remove(game);
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            // events
            app.MapGet("/events", async (EventGameDb db) => await db.EventGames.ToListAsync());
            app.MapGet("/events/{id}", async (EventGameDb db, int id) => await db.EventGames.FindAsync(id));
            app.MapPost("/events", async (EventGameDb db, EventGame evt) =>

            {
                await db.EventGames.AddAsync(evt);
                await db.SaveChangesAsync();
                return Results.Created($"/event/{evt.Id}", evt);
            });
            app.MapPut("/events/{id}", async (EventGameDb db, EventGame evt, int id) =>
            {
                var eventGame = await db.EventGames.FindAsync(id);
                if (eventGame is null) return Results.NotFound();
                eventGame.Name = evt.Name;
                eventGame.Date = evt.Date;
                eventGame.ParticipainsId = evt.ParticipainsId;
                eventGame.Place = evt.Place;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
            app.MapDelete("/events/{id}", async (EventGameDb db, int id) =>
            {
                var game = await db.EventGames.FindAsync(id);
                if (game is null)
                {
                    return Results.NotFound();
                }
                db.EventGames.Remove(game);
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            app.Run();
        }
    }
}